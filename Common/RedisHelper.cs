using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using ServiceStack.Redis;

namespace Common
{
    class RedisHelper
    {
        private static object lockobj = new object();
        /// <summary>
        /// 加入缓存
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="cacheKey">Key(键值命名规范：RK_字段名_表名_条件字段1_值_条件字段n_值......,键值全部小写,表名不加dbo前缀)</param>
        /// <param name="obj">对象</param>
        /// <param name="expiresAt">缓存时间(除了XianZhiAccounts的过期时间为一小时，其余的过期时间都为两天)</param>
        /// <returns>是否缓存成功</returns>
        public static bool Set<T>(string cacheKey, T obj, DateTime expiresAt)
        {
            bool result = false;
            lock (lockobj)
            {
                try
                {
                    if (IsOpenCache)
                    {
                        if (!(obj is System.Data.DataTable) || !(obj is System.Data.DataSet) || !(obj is System.Data.DataRow))
                        {
                            using (IRedisClient Redis = prcm.GetClient())
                            {
                                result = Redis.Set<T>(cacheKey, obj, expiresAt);
                            }
                        }
                    }
                }
                catch { }
            }
            return result;
        }

        /// <summary>
        /// 加入缓存（永久缓存）
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="cacheKey">Key(键值命名规范：RK_字段名_表名_条件字段1_值_条件字段n_值......,键值全部小写)</param>
        /// <param name="obj">对象</param>
        /// <returns>是否缓存成功</returns>
        private static bool Set<T>(string cacheKey, T obj)
        {
            lock (lockobj)
            {
                try
                {
                    if (!IsOpenCache) return false;
                    return Set<T>(cacheKey, obj, DateTime.Now.AddYears(100));
                }
                catch { return false; }
            }
        }

        /// <summary>
        /// 获取缓存内容
        /// </summary>
        /// <param name="cacheKey">Key</param>
        /// <returns></returns>
        public static T Get<T>(string cacheKey)
        {
            lock (lockobj)
            {
                try
                {
                    if (!IsOpenCache) return default(T);
                    using (IRedisClient Redis = prcm.GetClient())
                    {
                        return Redis.Get<T>(cacheKey);
                    }
                }
                catch
                {
                    string str = string.Empty;
                    return default(T);
                }
            }
        }


        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="cacheKey">Key</param>
        /// <returns></returns>
        public static bool Del(string cacheKey)
        {
            try
            {
                if (!IsOpenCache) return false;
                using (IRedisClient Redis = prcm.GetClient())
                {
                    return Redis.Remove(cacheKey);
                }
            }
            catch { return false; }
        }

        /// <summary>
        /// 批量删除缓存
        /// </summary>
        /// <param name="cacheKeys">Key</param>
        /// <returns></returns>
        public static void Del(List<string> cacheKeys)
        {
            try
            {
                if (!IsOpenCache) return;
                using (IRedisClient Redis = prcm.GetClient())
                {
                    Redis.RemoveAll(cacheKeys);
                }
            }
            catch { return; }
        }

        /// <summary>
        /// 清空缓存
        /// </summary>
        public static void ClearCache()
        {
            try
            {
                if (!IsOpenCache) return;
                using (IRedisClient Redis = prcm.GetClient())
                {
                    Redis.FlushAll();
                }
            }
            catch { return; }
        }



        #region 私有方法

        private static string RedisIP = ConfigHelper.GetAppSettingValue("RedisIP");
        private static string RedisPassword = ConfigHelper.GetAppSettingValue("RedisPassword");
        private static int RedisPort =Utils.StrToInt(ConfigHelper.GetAppSettingValue("RedisIP"), 6379);
        private static int DbIndex = Utils.StrToInt(ConfigHelper.GetAppSettingValue("RedisDb"), 2);

        private static PooledRedisClientManager prcm = CreateManager(
            new string[] { "" + RedisPassword + "@" + RedisIP + ":" + RedisPort + " " },
            new string[] { "" + RedisPassword + "@" + RedisIP + ":" + RedisPort + " " });

        private static PooledRedisClientManager CreateManager(string[] readWriteHosts, string[] readOnlyHosts)
        {
            // 支持读写分离，均衡负载 
            RedisClientManagerConfig clientConfig = new RedisClientManagerConfig();

            clientConfig.MaxWritePoolSize = 10000;
            clientConfig.MaxReadPoolSize = 10000;
            clientConfig.AutoStart = true;
            clientConfig.DefaultDb = DbIndex;

            PooledRedisClientManager clientManager = new PooledRedisClientManager(readWriteHosts, readOnlyHosts, clientConfig);
            return clientManager;
        }

        /// <summary>
        /// 是否使用缓存开关
        /// </summary>
        private static bool IsOpenCache
        {
            get
            {
                if (ConfigHelper.GetAppSettingValue("IsOpenCache") != "1") return false;
                return true;
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class ConfigHelper
    {

        #region 配置文件读取


        public static string GetAppSettingValue(string key)
        {
            try
            {
                return System.Configuration.ConfigurationManager.AppSettings[key];
            }
            catch
            {
                return string.Empty;
            }
        }

        //string keyWord = "TestRedis";
        //string cacheKey_keyWord = "RK_RedisCache_KeyWord_" + keyWord;
        //string cacheKey_Data = "RK_RedisCache_Data_" + keyWord;

        //RedisHelper.Set<string>(cacheKey_keyWord, "此处放缓存值", DateTime.Now.AddDays(5));//有效期

        #endregion
    }
}

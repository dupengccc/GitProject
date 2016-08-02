using Service.IService.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Service.ServiceImp.SysManage
{
    public class UserManage : RepositoryBase<Domain.SYS_USER>, IService.SysManage.IUserManage
    {
        /// <summary>
        /// 管理用户登录验证
        /// add yuangang by 2016-05-12
        /// </summary>
        /// <param name="useraccount">用户名</param>
        /// <param name="password">加密密码（AES）</param>
        /// <returns></returns>
        public string GetUserName(int userId)
        {
            var entity = this.LoadAll(p => p.ID == userId);
            if (entity != null && !entity.Any())
            {
                return "";
            }
            return entity.First().NAME;
        }

        public bool IsAdmin(int userId)
        {
            return true;
        }

        public SYS_USER UserLogin(string useraccount, string password)
        {
            var entity = this.Get(p => p.ACCOUNT == useraccount);
            if (entity != null && new Common.CryptHelper.AESCrypt().Decrypt(password)==password)
            {
                return entity;
            }
            return null;
        }
    }
}

using Service.IService.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.JsonHelper;

namespace Service.ServiceImp.SysManage
{
    public class SystemManage: RepositoryBase<Domain.SYS_SYSTEM>, ISystemManage
    {
        /// <summary>
        /// 获取系统ID、NAME
        /// </summary>
        /// <param name="systems">用户拥有操作权限的系统</param>
        /// <returns></returns>
        public dynamic LoadSystemInfo(List<string> systems)
        {
            return JsonConverter.JsonClass(this.LoadAll(p => systems.Any(e => e == p.ID)).Select(p => new { p.ID, p.NAME }).ToList());
        }

    }
}

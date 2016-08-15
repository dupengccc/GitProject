using Service.IService.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wkmvc.Controllers;
using wkmvc.Models;
using Domain;

namespace wkmvc.Areas.SysManage.Controllers
{
    public class HomeController : BaseController
    {
        #region 声明容器
        /// <summary>
        /// 用户管理
        /// add dupeng by 2016-05-16
        /// </summary>
        IModuleManage ModuleManage { get; set; }


        /// <summary>
        /// 权限管理
        /// add dupeng by 2016-05-16
        /// </summary>
        IPermissionManage PermissionManage { get; set; }

        /// <summary>
        /// 系统管理
        /// add dupeng by 2016-05-16
        /// </summary>
        ISystemManage SystemManage { get; set; }

        /// <summary>
        /// 日志记录
        /// </summary>
        log4net.Ext.IExtLog log = log4net.Ext.ExtLogManager.GetLogger("dblog");
        #endregion

        // GET: SysManage/Home
        //[UserAuthorizeAttribute(ModuleAlias = "Module", OperaAction = "View")]
        public ActionResult Index()
        {
            ViewData["Module"] = ModuleManage.GetModuleSystem(this.CurrentUser.Id, this.CurrentUser.Permissions, this.CurrentUser.System_id);
            return View(this.CurrentUser);
        }

        public ActionResult Logout()
        {
            //this.AccountService.Logout(this.CookieContext.UserToken);
            //this.CookieContext.UserToken = Guid.Empty;
            //this.CookieContext.UserName = string.Empty;
            //this.CookieContext.UserId = 0;
            return RedirectToAction("login", "Account", new { Area = "SysManage" });
           
        }


        private object GetModuleName(string name, decimal? level)
        {
            if (level > 0)
            {
                string nbsp = "&nbsp;&nbsp;";
                for (int i = 0; i < level; i++)
                {
                    nbsp += "&nbsp;&nbsp;";
                }
                name = nbsp + " |--" + name;
            }
            return name;
        }


        private object BindList(string system)
        {
            var query = this.ModuleManage.LoadAll(null);
            if (!string.IsNullOrEmpty(system))
            {
                query = query.Where(p => p.FK_BELONGSYSTEM == system);
            }
            else
            {
                query = query.Where(p => this.CurrentUser.System_id.Any(e => e.ToString() == p.FK_BELONGSYSTEM));
            }
            //递归排序
            var entity = this.ModuleManage.RecursiveModule(query.ToList())
                         .Select(p => new
                         {
                             p.ID,
                             modulename = p.NAME,
                             p.ALIAS,
                             p.MODULEPATH,
                             p.SHOWORDER,
                             p.ICON,
                             ModuleType = ((Common.Enums.enumModuleType)p.MODULETYPE).ToString(),
                             ISSHOW = p.ISSHOW == 1 ? "显示" : "隐藏",
                             p.NAME,
                             systemName = p.SYS_SYSTEM.NAME,
                             p.FK_BELONGSYSTEM
                         }
                         );
            if (!string.IsNullOrEmpty(base.keywords))
            {
                entity = entity.Where(p => p.NAME.Contains(base.keywords));
            }
            return Common.JsonHelper.JsonConverter.JsonClass(entity);
        }
    }
}
       

        /// <summary>
        /// 获取系统ID、NAME
        /// </summary>
        /// <param name="systems">用户拥有操作权限的系统</param>
        /// <returns></returns>
        //public dynamic LoadSystemInfo(List<string> systems)
        //{
        //    return Common.JsonHelper.JsonConverter.JsonClass(this.LoadAll(p => systems.Any(e => e == p.ID)).Select(p => new { p.ID, p.NAME }).ToList());
        //}
       
        /// <summary>
        /// 获取系统ID、NAME
        /// </summary>
        /// <param name="systems">用户拥有操作权限的系统</param>
        /// <returns></returns>
//            public dynamic LoadSystemInfo(List<string> systems)
//                    {
//                        return Common.JsonConverter.JsonClass(this.LoadAll(null).Select(p => new { p.ID, p.NAME }).ToList());
//                    }
//                }
//}
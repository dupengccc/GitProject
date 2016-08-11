using Service.IService.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wkmvc.Controllers;

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
        public ActionResult Index()
        {
            return View();
        }
    }
}
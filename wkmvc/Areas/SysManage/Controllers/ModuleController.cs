using Common;
using Common.JsonHelper;
using Service.IService.SysManage;
using Service.ServiceImp.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wkmvc.Controllers;
using wkmvc.Models;

namespace wkmvc.Areas.SysManage.Controllers
{
    public class ModuleController : BaseController
    {
        #region
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

        // GET: SysManage/Module
        [UserAuthorizeAttribute(ModuleAlias = "Module", OperaAction = "View")]
        public ActionResult Index()
        { 
            try
            {
                #region
                string systems = Request.QueryString["system"];
                ViewBag.Search = base.keywords;
                ViewData["System"] = systems;
                ViewData["Systemlist"] = this.SystemManage.LoadSystemInfo(this.CurrentUser.System_id);
                #endregion
                return View(BindList(systems));
            }
            catch (Exception er)
            {
                throw   er.InnerException;
            } 
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            try
            {
                return View();
            }
            catch (Exception er)
            {
                throw er.InnerException;
            }
        }



        private object GetModuleName(string name, decimal? level)
        {
            if (level > 0)
            {
                string nbsp = "&nbsp;&nbsp;&nbsp;";
                for (int i = 0; i < level; i++)
                {
                    nbsp += "&nbsp;&nbsp;&nbsp;";
                }
                name = nbsp + "|--" + name;
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
                             modulename =GetModuleName(p.NAME,p.LEVELS),
                             p.ALIAS,
                             p.MODULEPATH,
                             p.SHOWORDER,
                             p.ICON,
                             ModuleType = ((Common.Enums.enumModuleType)p.MODULETYPE).ToString(),
                             ISSHOW = p.ISSHOW ==true ? "显示" : "隐藏",
                             p.NAME,
                             SYSNAME = p.SYS_SYSTEM.NAME,
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
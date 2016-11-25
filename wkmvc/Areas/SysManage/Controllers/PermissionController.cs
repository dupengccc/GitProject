using Common.Enums;
using Domain;
using Service.IService.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wkmvc.Controllers;
using wkmvc.Models;

namespace wkmvc.Areas.SysManage.Controllers
{
    public class PermissionController : BaseController
    {
        #region 
        /// <summary>
        /// 容器
        /// </summary>
        /// <returns></returns>
        private ICodeManage CodeManage { get; set; }
      //  private IModuleManage ModuleManage { get; set; }
        private IPermissionManage PermissionManage { get; set; }
        private IRoleManage RoleManage { get; set; }
        private IRolePermissionManage RolePermissionManage { get; set; }
        private ISystemManage SystemManage { get; set; }
        private IUserPermissionManage UserPermissionManage { get; set; }
        #endregion

        // GET: SysManage/Permission
        [UserAuthorize(ModuleAlias = "Permission", OperaAction = "View")]
        public ActionResult Index()
        {
            ActionResult result;
            try
            {
                string str = base.Request.QueryString["moduleId"] ?? (base.Request["moduleId"] ?? "");
                if (!string.IsNullOrEmpty(str))
                {
                    int module_Id = int.Parse(str);
                    SYS_MODULE module = this.ModuleManage.Get(p => p.ID == module_Id);
                    IQueryable<SYS_PERMISSION> queryable = this.PermissionManage.LoadAll(p => p.MODULEID == module.ID);
                    if (!string.IsNullOrEmpty(base.keywords))
                    {
                        queryable = from p in queryable
                                    where p.NAME.Contains(this.keywords)
                                    select p;
                    }
                    List<SYS_PERMISSION> model = (from p in queryable
                                                  orderby p.SHOWORDER
                                                  select p).ToList<SYS_PERMISSION>();
                    ((dynamic)base.ViewBag).Search = base.keywords;
                    ((dynamic)base.ViewBag).Module = module;
                    return base.View(model);
                }
                result = base.View();
            }
            catch (Exception exception)
            {
                base.WriteLog(enumOperator.Select, "对模块权限按钮的管理加载主页：", exception);
                throw exception.InnerException;
            }
            return result;
        }





    }
}
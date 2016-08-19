using Service.IService.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wkmvc.Controllers;
using wkmvc.Models;
using Domain;
using System.Text;

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
            StringBuilder sb = new StringBuilder();
            var module = ModuleManage.GetModuleSystem(this.CurrentUser.Id, this.CurrentUser.Permissions, this.CurrentUser.System_id);
            foreach (var item in module.Where(p=>p.LEVELS==1).ToList())
            {
                sb.Append(BilderMenu(module, item, item.ID));
            }
            ViewData["Module"] = sb.ToString();
            return View(this.CurrentUser);
        }

        public StringBuilder BilderMenu(List<SYS_MODULE> modulelist, SYS_MODULE module, int parentId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"#\"><i class=\"{0}\"></i>"
                      + "<span class=\"nav-label\">{1}</span>"
                      + "<span class=\"fa arrow\"></span></a>", module.ICON, module.NAME);
            sb.Append("<ul class=\"nav nav - second - level\">");
            foreach (var vitem in modulelist.Where(p => p.PARENTID == parentId).ToList())
            {
                sb.Append("<li>");
                if(vitem.IsVillage==true)
                {
                    sb.Append(BilderMenu(modulelist,vitem, vitem.ID));
                }
                else
                {
                    sb.AppendFormat("<a class=\"J_menuItem\" href=\"{0}\" data-index=\"0\">{1}</a>", vitem.MODULEPATH, vitem.NAME);
                }
                sb.Append("</li >");
            }
            sb.Append("</ul>");
            sb.Append("</li>");
            return sb;
        }


        public ActionResult Logout()
        {
            Common.SessionHelper.Remove("CurrentUser");// .Logout(this.CookieContext.UserToken);
            Common.CookieHelper.ClearCookie("Cooke_rememberme");
            return RedirectToAction("login", "Account", new { Area = "SysManage" });
           
        }


    }
}
       

     
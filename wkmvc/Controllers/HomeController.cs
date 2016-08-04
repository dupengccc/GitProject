using Service.IService.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wkmvc.Controllers
{
    public class HomeController : BaseController
    {
        IModuleManage ModuleManage { get; set; }
         
        public ActionResult Index()
        {
            ViewData["Module"] = ModuleManage.GetModule(this.CurrentUser.Id,this.CurrentUser.Permissions,this.CurrentUser.Id.ToString());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
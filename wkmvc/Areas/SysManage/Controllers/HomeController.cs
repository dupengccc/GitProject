using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wkmvc.Areas.SysManage.Controllers
{
    public class HomeController : Controller
    {
        // GET: SysManage/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
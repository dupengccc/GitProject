using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wkmvc.Controllers;

namespace wkmvc.Areas.ProManage.Controllers
{
    public class ProjectController : BaseController
    {
        // GET: ProManage/Project
        public ActionResult Index()
        {
            return View();
        }
    }
}
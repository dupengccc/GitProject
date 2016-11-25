using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wkmvc.Controllers;

namespace wkmvc.Areas.ProManage.Controllers
{
    public class ProjectMissionController : BaseController
    {
        // GET: ProManage/ProjectMission
        public ActionResult Index()
        {
            return View();
        }
    }
}
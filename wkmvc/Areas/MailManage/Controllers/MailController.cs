using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wkmvc.Areas.MailManage.Controllers
{
    public class MailController : Controller
    {
        // GET: MailManage/Mail
        public ActionResult Index()
        {
            return View();
        }
    }
}
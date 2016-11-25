using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wkmvc.Controllers;

namespace wkmvc.Areas.ComManage.Controllers
{
    public class UploadController : BaseController
    {
        // GET: ComManage/Upload 
        public ActionResult Index()
        {
            return View();
        }
    }
}
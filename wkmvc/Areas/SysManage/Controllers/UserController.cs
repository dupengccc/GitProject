﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wkmvc.Controllers;

namespace wkmvc.Areas.SysManage.Controllers
{
    public class UserController : BaseController
    {
        // GET: SysManage/User
        public ActionResult Index()
        {
            return View();
        }
    }
}
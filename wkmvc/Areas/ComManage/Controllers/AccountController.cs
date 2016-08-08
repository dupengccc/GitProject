using Microsoft.AspNet.Identity;
using Service.ServiceImp.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.ServiceImp.SysManage;

namespace wkmvc.Areas.ComManage.Controllers
{
    public class AccountController : Controller
    {
        #region  声明容器
        /// <summary>
        ///  用户管理
        /// </summary>
        /// <returns></returns>
        IUserManage UserManage { get; set; }
        #endregion


        #region 基本视图
            // GET: ComManage/Account
            public ActionResult Index()
            {
                return View();
            }
        #endregion

        #region 帮助方法
              
        #endregion

        // GET: ComManage/Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComManage/Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComManage/Account/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ComManage/Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComManage/Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ComManage/Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComManage/Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using Common;
using Domain;
using Service.IService.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wkmvc.Controllers;

namespace wkmvc.Areas.SysManage.Controllers
{
    public class SystemController :BaseController
    {
        // GET: SysManage/System
        public ActionResult Index()
        {
            return View();
        }

        private IModuleManage moduleManage { get; set; }
        private ISystemManage systemManage { get; set; }

        //private PageInfo BindList(string status)
        //{
        //    IQueryable<SYS_SYSTEM> query = this.systemManage.LoadAll(p => this.CurrentUser.System_id.Any<string>(e => e == p.ID));
        //    if (!string.IsNullOrEmpty(status))
        //    {
        //        bool islogin = status == "True";
        //        query = from p in query
        //                where p.IS_LOGIN == islogin
        //                select p;
        //    }
        //    if (!string.IsNullOrEmpty(base.keywords))
        //    {
        //        base.keywords = base.keywords.ToLower();
        //        query = from p in query
        //                where p.NAME.Contains(this.keywords)
        //                select p;
        //    }
        //    query = from p in query
        //            orderby p.CREATEDATE descending
        //            select p;
        //    PageInfo<SYS_SYSTEM> info = this.systemManage.Query(query, base.page, base.pagesize);
        //  //  var enumable=info.List.Select()
        //}
    }
}
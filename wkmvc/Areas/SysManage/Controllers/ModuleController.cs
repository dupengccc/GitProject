using Common;
using Common.JsonHelper;
using Service.IService.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wkmvc.Controllers;
using wkmvc.Models;

namespace wkmvc.Areas.SysManage.Controllers
{
    public class ModuleController : BaseController
    {
        #region
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

        public ActionResult GetData(int pageIndex=1,int pagesize=10)
        {
            var products = new[] {
                new Product { ID = "1", Name = "Item 1", Price = "$1",person="22" },
                new Product { ID = "2", Name = "Item 2", Price = "$1" ,person="22" },
                new Product { ID = "3", Name = "Item 3", Price = "$1",person="22" },
                new Product { ID = "4", Name = "Item 4", Price = "$4",person="22" },
                new Product { ID = "5", Name = "Item 5", Price = "$5" ,person="22"},
                new Product { ID = "6", Name = "Item 6", Price = "$6",person="22" },
                new Product { ID = "7", Name = "Item 7", Price = "$7" ,person="22"},
                new Product { ID = "8", Name = "Item 8", Price = "$8",person="22" },
                new Product { ID = "9", Name = "Item 9", Price = "$9",person="22" },
                new Product { ID = "10", Name = "Item 10", Price = "$10",person="22" },
                new Product { ID = "11", Name = "Item 11", Price = "$11",person="22" },
                new Product { ID = "12", Name = "Item 12", Price = "$12",person="22" },
                new Product { ID = "13", Name = "Item 13", Price = "$13",person="22" },
                new Product { ID = "14", Name = "Item 14", Price = "$14" ,person="22"},
                new Product { ID = "15", Name = "Item 15", Price = "$15" ,person="22"},
                new Product { ID = "16", Name = "Item 16", Price = "$16",person="22" },
                new Product { ID = "17", Name = "Item 17", Price = "$17",person="22" },
                new Product { ID = "18", Name = "Item 18", Price = "$18" ,person="22"},
                new Product { ID = "19", Name = "Item 19", Price = "$19",person="22" },
                new Product { ID = "20", Name = "Item 20", Price = "$20" ,person="22"},
                new Product { ID = "21", Name = "Item 21", Price = "$21" ,person="22"},
                new Product { ID = "22", Name = "Item 22", Price = "$22",person="22" },
                new Product { ID = "23", Name = "Item 23", Price = "$23" ,person="22"},
                new Product { ID = "24", Name = "Item 24", Price = "$24" ,person="22"},
                new Product { ID = "25", Name = "Item 25", Price = "$25" ,person="22"},
                new Product { ID = "26", Name = "Item 26", Price = "$26" ,person="22"},
                new Product { ID = "27", Name = "Item 27", Price = "$27" ,person="22"},
                new Product { ID = "28", Name = "Item 28", Price = "$28" ,person="22"},
                new Product { ID = "29", Name = "Item 29", Price = "$29" ,person="22"},
                new Product { ID = "30", Name = "Item 30", Price = "$30",person="22" },
            };
            string jsonString = JsonHelper.ListToJson(products);
            int totalCount = products.Count();
            jsonString = "{\"total\":" + totalCount.ToString() + ",\"rows\":" + jsonString + "}";
            return Content(jsonString,"json");

        }
        private class Product
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Price { get; set; }
            public string person { get; set; }
        }
        // GET: SysManage/Module
        [UserAuthorizeAttribute(ModuleAlias = "Module", OperaAction = "View")]
        public ActionResult Index()
        { 
            try
            {
                #region
                string systems = Request.QueryString["system"];
                ViewBag.Search = base.keywords;
                ViewData["System"] = systems;
                ViewData["Systemlist"] = this.SystemManage.LoadSystemInfo(this.CurrentUser.System_id);
                #endregion
                return View(BindList(systems));
            }
            catch (Exception er)
            {
                throw   er.InnerException;
            } 
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            try
            {
                return View();
            }
            catch (Exception er)
            {
                throw er.InnerException;
            }
        }



        private object GetModuleName(string name, decimal? level)
        {
            if (level > 0)
            {
                string nbsp = "&nbsp;&nbsp;&nbsp;";
                for (int i = 0; i < level; i++)
                {
                    nbsp += "&nbsp;&nbsp;&nbsp;";
                }
                name = nbsp + "|--" + name;
            }
            return name;
        }


        private object BindList(string system)
        {
            var query = this.ModuleManage.LoadAll(null);
            if (!string.IsNullOrEmpty(system))
            {
                query = query.Where(p => p.FK_BELONGSYSTEM == system);
            }
            else
            {
                query = query.Where(p => this.CurrentUser.System_id.Any(e => e.ToString() == p.FK_BELONGSYSTEM));
            }
            //递归排序
            var entity = this.ModuleManage.RecursiveModule(query.ToList())
                         .Select(p => new
                         {
                             p.ID,
                             modulename =GetModuleName(p.NAME,p.LEVELS),
                             p.ALIAS,
                             p.MODULEPATH,
                             p.SHOWORDER,
                             p.ICON,
                             ModuleType = ((Common.Enums.enumModuleType)p.MODULETYPE).ToString(),
                             ISSHOW = p.ISSHOW == 1 ? "显示" : "隐藏",
                             p.NAME,
                             SYSNAME = p.SYS_SYSTEM.NAME,
                             p.FK_BELONGSYSTEM
                         }
                         );
                if (!string.IsNullOrEmpty(base.keywords))
                {
                    entity = entity.Where(p => p.NAME.Contains(base.keywords));
                }
            return Common.JsonHelper.JsonConverter.JsonClass(entity);
        }
    }
}
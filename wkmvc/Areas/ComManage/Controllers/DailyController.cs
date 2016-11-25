using Common;
using Common.Enums;
using Common.JsonHelper;
using Domain;
using Service.IService.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wkmvc.Controllers;
using wkmvc.Models;

namespace wkmvc.Areas.ComManage.Controllers
{
    public class DailyController : BaseController
    {
        // GET: ProManage/daily
        [UserAuthorize(ModuleAlias = "Daily", OperaAction = "Detail")]
        public ActionResult Detail(int? id)
        {
            ActionResult result;
            try
            {
                COM_DAILYS entity = new COM_DAILYS();
                if (id.HasValue && (id > 0))
                {
                    entity = this.DailyManage.Get(p => p.ID == id);
                    base.ViewData["Content"] = this.ContentManage.Get(p => (p.FK_RELATIONID == entity.FK_RELATIONID) && (p.FK_TABLE == "COM_DAILYS")) ?? new COM_CONTENT();
                }
                result = base.View(entity);
            }
            catch (Exception exception)
            {
                base.WriteLog(enumOperator.Select, "日报管理加载详情", exception);
                throw exception.InnerException;
            }
            return result;
        }

        private int GetWeek(int month)
        {
            switch (Convert.ToDateTime(string.Concat(new object[] { DateTime.Now.Year, "-", month, "-01" })).DayOfWeek.ToString())
            {
                case "Monday":
                    return 1;

                case "Tuesday":
                    return 2;

                case "Wednesday":
                    return 3;

                case "Thursday":
                    return 4;

                case "Friday":
                    return 5;

                case "Saturday":
                    return 6;

                case "Sunday":
                    return 7;
            }
            return 0;
        }

        [UserAuthorize(ModuleAlias = "Daily", OperaAction = "View")]
        public ActionResult Index()
        {
            int month = string.IsNullOrEmpty(base.Request.QueryString["month"]) ? DateTime.Now.Month : int.Parse(base.Request.QueryString["month"]);
            base.ViewData["week"] = this.GetWeek(month);
            base.ViewData["month"] = month;
            base.ViewData["DailyList"] = this.DailyManage.LoadAll(p => ((p.FK_USERID == this.CurrentUser.Id) && (p.AddDate.Year == DateTime.Now.Year)) && (p.AddDate.Month == month)).ToList<COM_DAILYS>();
            return base.View();
        }

        [ValidateInput(false), UserAuthorize(ModuleAlias = "Daily", OperaAction = "Add,Edit")]
        public ActionResult Save(COM_DAILYS entity)
        {
            bool isEdit = false;
            string str = "";
            int num = (base.Request["Content_Id"] == null) ? 0 : int.Parse(base.Request["Content_Id"].ToString());
            JsonHelper data = new JsonHelper
            {
                Msg = "日报提交成功",
                Status = "n"
            };
            try
            {
                if (entity.ID <= 0)
                {
                    str = Guid.NewGuid().ToString();
                    entity.FK_USERID = base.CurrentUser.Id;
                    entity.FK_RELATIONID = str;
                    entity.AddDate = DateTime.Now;
                    entity.LastEditDate = DateTime.Now;
                    entity.DailySubIP = Utils.GetIP();
                }
                else
                {
                    entity.LastEditDate = DateTime.Now;
                    entity.DailySubIP = Utils.GetIP();
                    str = entity.FK_RELATIONID;
                    isEdit = true;
                }
                if (!this.DailyManage.SaveOrUpdate(entity, isEdit))
                {
                    data.Msg = "提交日报失败";
                }
                else
                {
                    if (num <= 0)
                    {
                        COM_CONTENT com_content = new COM_CONTENT
                        {
                            CONTENT = base.Request["Content"],
                            FK_RELATIONID = str,
                            FK_TABLE = "COM_DAILYS",
                            CREATEDATE = DateTime.Now
                        };
                        this.ContentManage.Save(com_content);
                    }
                    else
                    {
                        COM_CONTENT com_content2 = new COM_CONTENT
                        {
                            ID = num,
                            CONTENT = base.Request["Content"],
                            FK_RELATIONID = str,
                            FK_TABLE = "COM_DAILYS",
                            CREATEDATE = DateTime.Now
                        };
                        this.ContentManage.Update(com_content2);
                    }
                    data.Status = "y";
                }
            }
            catch (Exception exception)
            {
                data.Msg = "提交日报发生内部错误";
                base.WriteLog(enumOperator.None, "保存日报发生内部错误", exception);
            }
            return base.Json(data);
        }

        [UserAuthorize(ModuleAlias = "Daily", OperaAction = "Detail")]
        public ActionResult ViewDetail(int id)
        {
            ActionResult result;
            try
            {
                COM_DAILYS entity = this.DailyManage.Get(p => p.ID == id);
                base.ViewData["Content"] = (this.ContentManage.Get(p => (p.FK_RELATIONID == entity.FK_RELATIONID) && (p.FK_TABLE == "COM_DAILYS")) == null) ? "" : this.ContentManage.Get(p => (p.FK_RELATIONID == entity.FK_RELATIONID) && (p.FK_TABLE == "COM_DAILYS")).CONTENT;
                result = base.View(entity);
            }
            catch (Exception exception)
            {
                base.WriteLog(enumOperator.Select, "日报管理加载详情", exception);
                throw exception.InnerException;
            }
            return result;
        }

        private IContentManage ContentManage { get; set; }

        private IDailyManage DailyManage { get; set; }
    }

}
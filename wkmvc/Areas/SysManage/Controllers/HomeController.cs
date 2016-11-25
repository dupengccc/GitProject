using Service.IService.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wkmvc.Controllers;
using wkmvc.Models;
using Domain;
using System.Text;
using Service.ServiceImp.SysManage;
using Common.Enums;
using Common.JsonHelper;
using System.Configuration;
using Common;

namespace wkmvc.Areas.SysManage.Controllers
{
    public class HomeController : BaseController
    {
        #region 声明容器
        /// <summary>
        /// 用户管理
        /// add dupeng by 2016-05-16
        /// </summary>
        IModuleManage ModuleManage { get; set; }

   
        /// <summary>
        /// 部门管理
        /// add dupeng by 2016-05-16
        /// </summary>
        IDepartmentManage DepartmentManage { get; set; }
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


        IMailInBoxManage MailInBoxManage { get; set; }



        IProjectTeamManage ProjectTeamManage { get; set; }


        IWorkAttendanceManage WorkAttendanceManage { get;set; }

        IUserOnlieManage UserOnlieManage { get; set; }
        /// <summary>
        /// 日志记录
        /// </summary>
        log4net.Ext.IExtLog log = log4net.Ext.ExtLogManager.GetLogger("dblog");
        #endregion


        [ValidateAntiForgeryToken]
        public ActionResult Attendance()
        {
            bool isEdit = false;
            string str = string.Empty;
            JsonHelper data = new JsonHelper
            {
                Status = "n"
            };
            try
            {
                DateTime time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + ConfigurationManager.AppSettings["OnDutyAM"]);
                DateTime time2 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + ConfigurationManager.AppSettings["OffDutyAM"]);
                DateTime time3 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + ConfigurationManager.AppSettings["OnDutyPM"]);
                DateTime time4 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + ConfigurationManager.AppSettings["OffDutyPM"]);
                COM_WORKATTENDANCE entity = this.WorkAttendanceManage.LoadAll(p => (((p.FK_UserId == this.CurrentUser.Id) && (p.CreateDate.Year == DateTime.Now.Year)) && (p.CreateDate.Month == DateTime.Now.Month)) && (p.CreateDate.Day == DateTime.Now.Day)).FirstOrDefault<COM_WORKATTENDANCE>();
                if ((entity != null) && (entity.ID > 0))
                {
                    isEdit = true;
                }
                else
                {
                    entity = new COM_WORKATTENDANCE();
                }
                if (!entity.Is_SiginAM)
                {
                    entity.FK_UserId = base.CurrentUser.Id;
                    entity.Is_SiginAM = true;
                    entity.Is_SigOutAM = false;
                    entity.SiginAMDate = DateTime.Now;
                    entity.SigOutAMDate = DateTime.Now;
                    entity.Is_SiginPM = false;
                    entity.Is_SigOutPM = false;
                    entity.SiginPM = DateTime.Now;
                    entity.SigOutPM = DateTime.Now;
                    if (DateTime.Now > time)
                    {
                        entity.IsLateAM = true;
                        TimeSpan span = (TimeSpan)(DateTime.Now - time);
                        entity.LateAMMinutes = (int)Math.Round(span.TotalMinutes);
                        str = "上午已签到：迟到" + entity.LateAMMinutes + "分钟";
                    }
                    else
                    {
                        entity.IsLateAM = false;
                        entity.LateAMMinutes = 0;
                        str = "上午已签到";
                    }
                    entity.IsEarlyOutAM = false;
                    entity.EarlyOutAMMinutes = 0;
                    entity.IsLatePM = false;
                    entity.LatePMMinutes = 0;
                    entity.IsEarlyOutPM = false;
                    entity.EarlyOutPMMinutes = 0;
                    entity.WorkHours =0;
                    entity.SigIP = Utils.GetIP();
                    entity.CreateDate = DateTime.Now;
                }
                else if (Utils.GetIP() != entity.SigIP)
                {
                    data.Msg = "同一天考勤IP不允许更换！";
                }
                else if (!entity.Is_SigOutAM)
                {
                    entity.Is_SigOutAM = true;
                    entity.SigOutAMDate = DateTime.Now;
                    entity.Is_SiginPM = false;
                    entity.Is_SigOutPM = false;
                    entity.SiginPM = DateTime.Now;
                    entity.SigOutPM = DateTime.Now;
                    if (DateTime.Now < time2)
                    {
                        entity.IsEarlyOutAM = true;
                        TimeSpan span2 = (TimeSpan)(time2 - DateTime.Now);
                        entity.EarlyOutAMMinutes = (int)Math.Round(span2.TotalMinutes);
                        str = "上午已签退：早退" + entity.EarlyOutAMMinutes + "分钟";
                    }
                    else
                    {
                        entity.IsEarlyOutAM = false;
                        entity.EarlyOutAMMinutes = 0;
                        str = "上午已签退";
                    }
                    entity.IsLatePM = false;
                    entity.LatePMMinutes = 0;
                    entity.IsEarlyOutPM = false;
                    entity.EarlyOutPMMinutes = 0;
                    entity.WorkHours = 0;
                }
                else if (!entity.Is_SiginPM)
                {
                    entity.Is_SiginPM = true;
                    entity.Is_SigOutPM = false;
                    entity.SiginPM = DateTime.Now;
                    entity.SigOutPM = DateTime.Now;
                    if (DateTime.Now > time3)
                    {
                        entity.IsLatePM = true;
                        TimeSpan span3 = (TimeSpan)(DateTime.Now - time3);
                        entity.LatePMMinutes = (int)Math.Round(span3.TotalMinutes);
                        str = "下午已签到：迟到" + entity.LatePMMinutes + "分钟";
                    }
                    else
                    {
                        entity.IsLatePM = false;
                        entity.LatePMMinutes = 0;
                        str = "下午已签到";
                    }
                    entity.IsEarlyOutPM = false;
                    entity.EarlyOutPMMinutes = 0;
                    entity.WorkHours = 0;
                }
                else
                {
                    entity.Is_SigOutPM = true;
                    entity.SigOutPM = DateTime.Now;
                    if (DateTime.Now < time4)
                    {
                        entity.IsEarlyOutPM = true;
                        TimeSpan span4 = (TimeSpan)(time4 - DateTime.Now);
                        entity.EarlyOutPMMinutes = (int)Math.Round(span4.TotalMinutes);
                        str = "下午已签退：早退" + entity.EarlyOutPMMinutes + "分钟";
                    }
                    else
                    {
                        entity.IsEarlyOutPM = false;
                        entity.EarlyOutPMMinutes = 0;
                        str = "下午已签退";
                    }
                    TimeSpan span5 = (TimeSpan)(entity.SigOutAMDate - entity.SiginAMDate);
                    TimeSpan span6 = (TimeSpan)(entity.SigOutPM - entity.SiginPM);
                    entity.WorkHours =span5.TotalHours + span6.TotalHours;
                }
                if (this.WorkAttendanceManage.SaveOrUpdate(entity, isEdit))
                {
                    data.Msg = str;
                    data.Status = "y";
                }
                else
                {
                    data.Msg = "发生内部错误，请稍后再试！";
                }
            }
            catch (Exception exception)
            {
                data.Msg = "发生内部错误，请稍后再试！";
                base.WriteLog(enumOperator.None, "考勤发生内部错误", exception);
            }
            return base.Json(data);
        }


        // GET: Sys/Default
        public ActionResult Default()
        {
            int CarriedOut = ClsDic.DicProject["进行中"];
            int CarriedOut2 = ClsDic.DicProject["延期"];
            int JoinStatus = ClsDic.DicStatus["通过"];
            base.ViewData["MissionList"] = (from p in this.ProjectTeamManage.LoadAll(p => ((p.FK_UserId == this.CurrentUser.Id) && ((p.PRO_PROJECT_STAGES.StageStatus == CarriedOut) || (p.PRO_PROJECT_STAGES.StageStatus == CarriedOut2))) && (p.JionStatus == JoinStatus))
                                            orderby p.PRO_PROJECT_STAGES.EndDate
                                            select p).ToList<PRO_PROJECT_TEAMS>();
            int MailInbox = ClsDic.DicMailType["收件箱"];
            int MailUnRead = ClsDic.DicMailReadStatus["未读"];
            base.ViewData["MailInBoxCount"] = this.MailInBoxManage.LoadListAll(p => (p.Recipient.Contains(this.CurrentUser.LogName + this.EmailDomain) && (p.ReadStatus == MailUnRead)) && (p.MailType == MailInbox)).Count;
            int month = string.IsNullOrEmpty(base.Request.QueryString["month"]) ? DateTime.Now.Month : int.Parse(base.Request.QueryString["month"]);
            base.ViewData["week"] = this.GetWeek(month);
            base.ViewData["month"] = month;
            base.ViewData["AttendanceList"] = this.WorkAttendanceManage.LoadAll(p => ((p.FK_UserId == this.CurrentUser.Id) && (p.CreateDate.Year == DateTime.Now.Year)) && (p.CreateDate.Month == month)).ToList<COM_WORKATTENDANCE>();
            return base.View(base.CurrentUser);
        }


        // GET: SysManage/Home

        public ActionResult Index()
        {
            //StringBuilder sb = new StringBuilder();
            //var module = ModuleManage.GetModuleSystem(this.CurrentUser.Id, this.CurrentUser.Permissions, this.CurrentUser.System_id);
            //foreach (var item in module.Where(p=>p.LEVELS==1).ToList())
            //{
            //    sb.Append(BilderMenu(module, item, item.ID));
            //}
            //ViewData["Module"] = sb.ToString();
            //return View(this.CurrentUser);

            base.ViewData["Module"] = this.ModuleManage.GetModuleSystem(base.CurrentUser.Id, base.CurrentUser.Permissions, base.CurrentUser.System_id);
            int CarriedOut = ClsDic.DicProject["进行中"];
            int CarriedOut2 = ClsDic.DicProject["延期"];
            int JoinStatus = ClsDic.DicStatus["通过"];
            base.ViewData["MissionList"] = (from p in this.ProjectTeamManage.LoadAll(p => ((p.FK_UserId == this.CurrentUser.Id) && ((p.PRO_PROJECT_STAGES.StageStatus == CarriedOut) || (p.PRO_PROJECT_STAGES.StageStatus == CarriedOut2))) && (p.JionStatus == JoinStatus))
                                            orderby p.PRO_PROJECT_STAGES.EndDate
                                            select p).ToList<PRO_PROJECT_TEAMS>();
            int MailInbox = ClsDic.DicMailType["收件箱"];
            int MailUnRead = ClsDic.DicMailReadStatus["未读"];
            base.ViewData["MailInBox"] = this.MailInBoxManage.LoadListAll(p => (p.Recipient.Contains(this.CurrentUser.LogName + this.EmailDomain) && (p.ReadStatus == MailUnRead)) && (p.MailType == MailInbox));
            base.ViewData["Contacts"] = this.Contacts();
            return base.View(base.CurrentUser);
        }


        private object GetDepartUsers(string departId)
        {
            List<string> departs = (from p in this.DepartmentManage.LoadAll(p => p.PARENTID == departId)
                                    orderby p.SHOWORDER
                                    select p.ID).ToList<string>();
            return (from p in (from p in base.UserManage.LoadListAll(p => (p.ID != this.CurrentUser.Id) && departs.Any<string>(e => (e == p.DPTID)))
                               orderby p.LEVELS
                               orderby p.CREATEDATE
                               select new
                               {
                                   ID = p.ID,
                                   FaceImg = string.IsNullOrEmpty(p.FACE_IMG) ? ("/Pro/Project/User_Default_Avatat?name=" + p.NAME.Substring(0, 1)) : p.FACE_IMG,
                                   NAME = p.NAME,
                                   InsideEmail = p.ACCOUNT + base.EmailDomain,
                                   LEVELS = p.LEVELS,
                                   ConnectId = (this.UserOnlieManage.LoadAll(m => m.FK_UserId == p.ID).FirstOrDefault<SYS_USER_ONLINE>() == null) ? "" : this.UserOnlieManage.LoadAll(m => m.FK_UserId == p.ID).FirstOrDefault<SYS_USER_ONLINE>().ConnectId,
                                   IsOnline = (this.UserOnlieManage.LoadAll(m => m.FK_UserId == p.ID).FirstOrDefault<SYS_USER_ONLINE>() == null) ? false : this.UserOnlieManage.LoadAll(m => m.FK_UserId == p.ID).FirstOrDefault<SYS_USER_ONLINE>().IsOnline
                               }).ToList()
                    orderby p.IsOnline
                    select p).ToList();
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

        private object Contacts() { 


               return   JsonConverter.JsonClass(from m in (from m in this.DepartmentManage.LoadAll(m => m.BUSINESSLEVEL == 1)
                                             orderby m.SHOWORDER
                                             select m).ToList<SYS_DEPARTMENT>()
                                  select new
                                  {
                                      ID = m.ID,
                                      DepartName = m.NAME,
                                      UserList = this.GetDepartUsers(m.ID)
              });
        }

        public StringBuilder BilderMenu(List<SYS_MODULE> modulelist, SYS_MODULE module, int parentId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"#\"><i class=\"{0}\"></i>"
                      + "<span class=\"nav-label\">{1}</span>"
                      + "<span class=\"fa arrow\"></span></a>", module.ICON, module.NAME);
            sb.Append("<ul class=\"nav nav - second - level\">");
            foreach (var vitem in modulelist.Where(p => p.PARENTID == parentId).ToList())
            {
                sb.Append("<li>");
                if(vitem.IsVillage==true)
                {
                    sb.Append(BilderMenu(modulelist,vitem, vitem.ID));
                }
                else
                {
                    sb.AppendFormat("<a class=\"J_menuItem\" href=\"{0}\" data-index=\"0\"><i class=\"{1}\"></i>{2}</a>", vitem.MODULEPATH,vitem.ICON,vitem.NAME);
                }
                sb.Append("</li >");
            }
            sb.Append("</ul>");
            sb.Append("</li>");
            return sb;
        }


        public ActionResult Logout()
        {
            Common.SessionHelper.Remove("CurrentUser");// .Logout(this.CookieContext.UserToken);
            Common.CookieHelper.ClearCookie("Cooke_rememberme");
            return RedirectToAction("Index", "Account", new { Area = "SysManage" });
           
        }


    }
}
       

     
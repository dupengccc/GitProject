using Common;
using Common.Enums;
using Domain;
using Service.IService;
using Service.IService.SysManage;
using Service.ServiceImp.SysManage;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Models
{

    public class CommonHelper
    {
        public ICodeAreaManage CodeAreaManage = (ContextRegistry.GetContext().GetObject("Service.CodeArea") as ICodeAreaManage);
        public ICodeManage CodeManage = (ContextRegistry.GetContext().GetObject("Service.Code") as ICodeManage);
        public IContentManage ContentManage = (ContextRegistry.GetContext().GetObject("Service.Com.Content") as IContentManage);
        public IProjectFilesManage ProjectFilesManage = (ContextRegistry.GetContext().GetObject("Service.Pro.ProjectFiles") as IProjectFilesManage);
        public IProjectStageManage ProjectStageManage = (ContextRegistry.GetContext().GetObject("Service.Pro.ProjectStage") as IProjectStageManage);
        public IUserManage UserManage = (ContextRegistry.GetContext().GetObject("Service.User") as IUserManage);

        private bool ChildModuleList(SYS_MODULE module, List<SYS_MODULE> moduleList, StringBuilder str, bool IsAppend)
        {
            List<SYS_MODULE> list = (from p in moduleList.FindAll(p => p.PARENTID == module.ID)
                                     orderby p.SHOWORDER
                                     select p).ToList<SYS_MODULE>();
            if ((list == null) || (list.Count <= 0))
            {
                return false;
            }
            if (IsAppend)
            {
                str.Append("<ul class=\"nav nav-second-level\">");
                foreach (SYS_MODULE sys_module in list)
                {
                    str.Append("<li>");
                    str.Append("<a class=\"" + (this.ChildModuleList(sys_module, moduleList, str, false) ? "" : "J_menuItem") + "\" href=\"" + (string.IsNullOrEmpty(sys_module.MODULEPATH) ? "javascript:void(0)" : sys_module.MODULEPATH) + "\" ><i class=\"" + sys_module.ICON + "\"></i> <span class=\"nav-label\">" + sys_module.NAME + "</span>" + (this.ChildModuleList(sys_module, moduleList, str, false) ? "<span class=\"fa arrow\"></span>" : "") + "</a>");
                    this.ChildModuleList(sys_module, moduleList, str, true);
                    str.Append("</li>");
                }
                str.Append("</ul>");
            }
            return true;
        }

        public string GetCodeAreaName(string codearealist)
        {
            if (string.IsNullOrEmpty(codearealist))
            {
                return string.Empty;
            }
            List<string> list = (from p in codearealist.Trim(new char[] { ',' }).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries) select p).ToList<string>();
            if ((list == null) || (list.Count <= 0))
            {
                return string.Empty;
            }
            string str = string.Empty;
            using (List<string>.Enumerator enumerator = list.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    string item = enumerator.Current;
                    str = str + this.CodeAreaManage.Get(p => p.ID == item).NAME + "&nbsp;";
                }
            }
            return str;
        }

        public string GetContentText(string FK_RELATIONID, string TableName)
        {
            if (this.ContentManage.Get(p => (p.FK_RELATIONID == FK_RELATIONID) && (p.FK_TABLE == TableName)) != null)
            {
                return Utils.DropHTML(this.ContentManage.Get(p => (p.FK_RELATIONID == FK_RELATIONID) && (p.FK_TABLE == TableName)).CONTENT);
            }
            return "";
        }

        public MvcHtmlString GetModuleMenu(SYS_MODULE module, List<SYS_MODULE> moduleList)
        {
            StringBuilder str = new StringBuilder(0x3a98);
            List<SYS_MODULE> list = (from p in moduleList.FindAll(p => (p.PARENTID == module.ID) && (p.LEVELS == 1))
                                     orderby p.SHOWORDER
                                     select p).ToList<SYS_MODULE>();
            if ((list != null) && (list.Count > 0))
            {
                foreach (SYS_MODULE sys_module in list)
                {
                    str.Append("<li data-id=\"" + module.ALIAS + "\" class=\"FirstModule\" >");
                    str.Append("<a class=\"" + (this.ChildModuleList(sys_module, moduleList, str, false) ? "" : "J_menuItem") + "\" href=\"" + (string.IsNullOrEmpty(sys_module.MODULEPATH) ? "javascript:void(0)" : sys_module.MODULEPATH) + "\" ><i class=\"" + sys_module.ICON + "\"></i> <span class=\"nav-label\">" + sys_module.NAME + "</span>" + (this.ChildModuleList(sys_module, moduleList, str, false) ? "<span class=\"fa arrow\"></span>" : "") + "</a>");
                    this.ChildModuleList(sys_module, moduleList, str, true);
                    str.Append("</li>");
                }
            }
            return new MvcHtmlString(str.ToString());
        }

        public int GetProgress(int projectId)
        {
            List<PRO_PROJECT_STAGES> source = this.ProjectStageManage.LoadListAll(p => p.FK_ProjectId == projectId);
            int num = 0;
            if ((source == null) || (source.Count <= 0))
            {
                return num;
            }
            int count = source.Count;
            int num3 = source.Where<PRO_PROJECT_STAGES>(delegate (PRO_PROJECT_STAGES p)
            {
                if (p.StageStatus != ClsDic.DicProject["已验收"])
                {
                    return (p.StageStatus == ClsDic.DicProject["已超时"]);
                }
                return true;
            }).ToList<PRO_PROJECT_STAGES>().Count;
            return ((count > 0) ? ((int)Math.Floor((double)((((double)num3) / (count * 1.0)) * 100.0))) : 0);
        }

        public List<PRO_PROJECT_FILES> GetStageFiles(int stageId, int userId)
        {
            return (from p in this.ProjectFilesManage.LoadAll(p => ((p.DocStyle == "projectstage") && (p.Fk_ForeignId == stageId)) && (p.FK_UserId == userId))
                    orderby p.UploadDate descending
                    select p).ToList<PRO_PROJECT_FILES>();
        }

        public string GetStageTeams(PRO_PROJECT_STAGES Stages)
        {
            string str = string.Empty;
            if (((Stages != null) && (Stages.PRO_PROJECT_TEAMS != null)) && (Stages.PRO_PROJECT_TEAMS.Count > 0))
            {
                using (IEnumerator<PRO_PROJECT_TEAMS> enumerator = Stages.PRO_PROJECT_TEAMS.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        PRO_PROJECT_TEAMS team = enumerator.Current;
                        if (team.JionStatus == ClsDic.DicProject["通过"])
                        {
                            str = str + "&nbsp;" + (string.IsNullOrEmpty(this.UserManage.Get(p => p.ID == team.FK_UserId).FACE_IMG) ? ("<img alt=\"image\" class=\"img-circle\" src=\"/Pro/Project/User_Default_Avatat?name=" + this.UserManage.Get(p => p.ID == team.FK_UserId).NAME.Substring(0, 1).ToUpper() + "\" data-toggle=\"tooltip\" data-placement=\"top\"  data-original-title=\"" + this.UserManage.Get(p => p.ID == team.FK_UserId).NAME + "\" />") : ("<img alt=\"image\" class=\"img-circle\" src=\"" + this.UserManage.Get(p => p.ID == team.FK_UserId).FACE_IMG + "\" data-toggle=\"tooltip\" data-placement=\"top\"  data-original-title=\"" + this.UserManage.Get(p => p.ID == team.FK_UserId).NAME + "\" />"));
                        }
                    }
                }
            }
            return str;
        }

        public string GetSurplusTime(DateTime dt)
        {
            if (dt >= DateTime.Now)
            {
                TimeSpan span = (TimeSpan)(dt - DateTime.Now);
                if (span.TotalSeconds < 60.0)
                {
                    return "<small class=\"label label-danger\"><i class=\"fa fa-clock-o\"></i> 即将超时</small>";
                }
                if (span.TotalMinutes < 60.0)
                {
                    return ("<small class=\"label label-warning\"><i class=\"fa fa-clock-o\"></i> " + ((int)Math.Round(span.TotalMinutes)) + " 分钟</small>");
                }
                if (span.TotalHours < 24.0)
                {
                    return ("<small class=\"label label-info\"><i class=\"fa fa-clock-o\"></i> " + ((int)Math.Round(span.TotalHours)) + " 小时</small>");
                }
                return ("<small class=\"label label-primary\"><i class=\"fa fa-clock-o\"></i> " + ((int)Math.Round(span.TotalDays)) + " 天</small>");
            }
            TimeSpan span2 = (TimeSpan)(DateTime.Now - dt);
            if (span2.TotalSeconds < 60.0)
            {
                return ("<small class=\"label label-danger\"><i class=\"fa fa-clock-o\"></i> 已超时 " + ((int)Math.Round(span2.TotalSeconds)) + " 秒</small>");
            }
            if (span2.TotalMinutes < 60.0)
            {
                return ("<small class=\"label label-danger\"><i class=\"fa fa-clock-o\"></i> 已超时 " + ((int)Math.Round(span2.TotalMinutes)) + " 分钟</small>");
            }
            if (span2.TotalHours < 24.0)
            {
                return ("<small class=\"label label-danger\"><i class=\"fa fa-clock-o\"></i> 已超时 " + ((int)Math.Round(span2.TotalHours)) + " 小时</small>");
            }
            return ("<small class=\"label label-danger\"><i class=\"fa fa-clock-o\"></i> 已超时 " + ((int)Math.Round(span2.TotalDays)) + " 天</small>");
        }

        public string GetSurplusTimeNoClass(DateTime dt)
        {
            if (dt >= DateTime.Now)
            {
                TimeSpan span = (TimeSpan)(dt - DateTime.Now);
                if (span.TotalSeconds < 60.0)
                {
                    return "<span class=\"text-danger\"><i class=\"fa fa-clock-o\"></i> 即将超时</span>";
                }
                if (span.TotalMinutes < 60.0)
                {
                    return ("<span class=\"text-warning\"><i class=\"fa fa-clock-o\"></i> " + ((int)Math.Round(span.TotalMinutes)) + " 分钟</span>");
                }
                if (span.TotalHours < 24.0)
                {
                    return ("<span class=\"text-info\"><i class=\"fa fa-clock-o\"></i> " + ((int)Math.Round(span.TotalHours)) + " 小时</span>");
                }
                return ("<span><i class=\"fa fa-clock-o\"></i> " + ((int)Math.Round(span.TotalDays)) + " 天</span>");
            }
            TimeSpan span2 = (TimeSpan)(DateTime.Now - dt);
            if (span2.TotalSeconds < 60.0)
            {
                return ("<span class=\"text-danger\"><i class=\"fa fa-clock-o\"></i> 已超时 " + ((int)Math.Round(span2.TotalSeconds)) + " 秒</span>");
            }
            if (span2.TotalMinutes < 60.0)
            {
                return ("<span class=\"text-danger\"><i class=\"fa fa-clock-o\"></i> 已超时 " + ((int)Math.Round(span2.TotalMinutes)) + " 分钟</span>");
            }
            if (span2.TotalHours < 24.0)
            {
                return ("<span class=\"text-danger\"><i class=\"fa fa-clock-o\"></i> 已超时 " + ((int)Math.Round(span2.TotalHours)) + " 小时</span>");
            }
            return ("<span class=\"text-danger\"><i class=\"fa fa-clock-o\"></i> 已超时 " + ((int)Math.Round(span2.TotalDays)) + " 天</span>");
        }

        public SYS_USER GetUserByAccount(string account)
        {
            return this.UserManage.Get(p => p.ACCOUNT == account);
        }

        public SYS_USER GetUserById(int id)
        {
            return this.UserManage.Get(p => p.ID == id);
        }

        public string GetUserNameByAccount(string account)
        {
            if (this.UserManage.Get(p => p.ACCOUNT == account) != null)
            {
                return this.UserManage.Get(p => p.ACCOUNT == account).NAME;
            }
            return "";
        }

        public string GetUserZW(string levels)
        {

         //   var CodeModel = this.CodeManage.Get(m => (m.CODEVALUE == "2") && (m.CODETYPE == "ZW"));
            return this.CodeManage.Get(m => (m.CODEVALUE == levels) && (m.CODETYPE == "ZW")).NAMETEXT;
        }

        public static string PrettyTime(DateTime dt)
        {
            TimeSpan span = (TimeSpan)(DateTime.Now - dt);
            if (span.TotalSeconds < 60.0)
            {
                return "刚刚";
            }
            if (span.TotalMinutes < 60.0)
            {
                return (((int)Math.Round(span.TotalMinutes)) + "分钟前");
            }
            if (span.TotalHours < 24.0)
            {
                return (((int)Math.Round(span.TotalHours)) + "小时前");
            }
            if (span.TotalDays < 60.0)
            {
                return (((int)Math.Round(span.TotalDays)) + "天前");
            }
            return "N久以前";
        }

        public string RankFoums(int rank)
        {
            switch (rank)
            {
                case 1:
                    return "<span class=\"text-danger\" style=\"padding:5px 10px;font-size:15px;\"><img src=\"/Content/images/expression/e_59.png\" />&nbsp;神功绝世</span>";

                case 2:
                    return "<span class=\"text-warning\" style=\"padding:5px 10px;font-size:15px;\"><img src=\"/Content/images/expression/e_64.png\" />&nbsp;出神入化</span>";

                case 3:
                    return "<span class=\"text-info\" style=\"padding:5px 10px;font-size:15px;\"><img src=\"/Content/images/expression/e_02.png\" />&nbsp;登峰造极</span>";

                case 4:
                    return "<span class=\"text-success\" style=\"padding:5px 10px;font-size:15px;\"><img src=\"/Content/images/expression/e_27.png\" />&nbsp;功行圆满</span>";

                case 5:
                    return "<span class=\"text-primary\" style=\"padding:5px 10px;font-size:15px;\"><img src=\"/Content/images/expression/e_37.png\" />&nbsp;已臻大成</span>";

                case 6:
                    return "<span class=\"text-default\" style=\"padding:5px 10px;font-size:15px;\"><img src=\"/Content/images/expression/e_18.png\" />&nbsp;自成一派</span>";

                case 7:
                    return "<span class=\"text-default\" style=\"padding:5px 10px;font-size:15px;\"><img src=\"/Content/images/expression/e_24.png\" />&nbsp;炉火纯青</span>";

                case 8:
                    return "<span class=\"text-default\" style=\"padding:5px 10px;font-size:15px;\"><img src=\"/Content/images/expression/e_16.png\" />&nbsp;渐入佳境</span>";

                case 9:
                    return "<span class=\"text-default\" style=\"padding:5px 10px;font-size:15px;\"><img src=\"/Content/images/expression/e_08.png\" />&nbsp;略有小成</span>";

                case 10:
                    return "<span class=\"text-default\" style=\"padding:5px 10px;font-size:15px;\"><img src=\"/Content/images/expression/e_17.png\" />&nbsp;初亏堂奥</span>";
            }
            return "<span class=\"text-default\" style=\"padding:5px 10px;font-size:15px;\"><img src=\"/Content/images/expression/e_18.png\" />&nbsp;初学乍练</span>";
        }
    }
}
   

using Common;
using Common.Enums;
using Common.JsonHelper;
using Domain;
using Microsoft.AspNet.SignalR;
using Service.IService;
using Service.IService.SysManage;
using Service.ServiceImp.SysManage;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using wkmvc.Hubs;
namespace WebPage.Hubs
{ 
    public class ChatHub : Hub
    {
        public IChatMessageManage ChatMessageManage = (ContextRegistry.GetContext().GetObject("Service.ChatMessageManage") as IChatMessageManage);
        public ICodeManage CodeManage = (ContextRegistry.GetContext().GetObject("Service.Code") as ICodeManage);
        public IDepartmentManage DepartmentManage = (ContextRegistry.GetContext().GetObject("Service.Department") as IDepartmentManage);
        public IUserManage UserManage = (ContextRegistry.GetContext().GetObject("Service.User") as IUserManage);
        public IUserOnlieManage UserOnlineManage = (ContextRegistry.GetContext().GetObject("Service.UserOnlie") as IUserOnlieManage);

        private string GetMessageType(int type)
        {
            if (type == ClsDic.DicMessageType["广播"])
            {
                return "public";
            }
            if (type == ClsDic.DicMessageType["群组"])
            {
                return "group";
            }
            return "private";
        }

        private SYS_DEPARTMENT GetUserDepart(string departId)
        {
            int? nullable4;
            SYS_DEPARTMENT sys_department = this.DepartmentManage.Get(p => p.ID == departId);
            if (sys_department == null)
            {
                return null;
            }
            string ParentId = sys_department.PARENTID;
            SYS_DEPARTMENT sys_department2 = new SYS_DEPARTMENT();
            int? bUSINESSLEVEL = sys_department.BUSINESSLEVEL;
            Label_0170:
            nullable4 = bUSINESSLEVEL;
            if ((nullable4.GetValueOrDefault() >= 1) && nullable4.HasValue)
            {
                sys_department2 = this.DepartmentManage.Get(p => p.ID == ParentId);
                if (string.IsNullOrEmpty(sys_department2.PARENTID))
                {
                    return sys_department2;
                }
                ParentId = sys_department2.PARENTID;
                bUSINESSLEVEL -= 1;
                goto Label_0170;
            }
            return sys_department2;
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            SYS_USER_ONLINE UserOnline = this.UserOnlineManage.LoadListAll(p => p.ConnectId == this.Context.ConnectionId).FirstOrDefault<SYS_USER_ONLINE>();
            UserOnline.ConnectId = base.Context.ConnectionId;
            UserOnline.OfflineDate = new DateTime?(DateTime.Now);
            UserOnline.IsOnline = false;
            this.UserOnlineManage.Update(UserOnline);
            SYS_USER sys_user = this.UserManage.Get(p => p.ID == UserOnline.FK_UserId);
            ((dynamic)base.Clients.All).UserLogOutNotice(sys_user.NAME + "：离线了!");
            ((dynamic)base.Clients.All).ContactsNotice(JsonConverter.Serialize(UserOnline, false));
            return base.OnDisconnected(true);
        }

        public void Register(string account, string password)
        {
            //var selector ;
            //var func2 ;
            try
            {
                SYS_USER User = this.UserManage.Get(p => p.ACCOUNT == account);
                if ((User != null) && (User.PASSWORD == password))
                {
                    ParameterExpression expression3;
                    SYS_USER_ONLINE entity = this.UserOnlineManage.LoadListAll(p => p.SYS_USER.ID == User.ID).FirstOrDefault<SYS_USER_ONLINE>();
                    entity.ConnectId = base.Context.ConnectionId;
                    entity.OnlineDate = DateTime.Now;
                    entity.IsOnline = true;
                    entity.UserIP = Utils.GetIP();
                    this.UserOnlineManage.Update(entity);
                    int num = int.Parse(ConfigurationManager.AppSettings["HistoryDays"]);
                    DateTime dtHistory = DateTime.Now.AddDays((double)-num);
                    IQueryable<SYS_CHATMESSAGE> queryable = this.ChatMessageManage.LoadAll(p => p.MessageDate > dtHistory);
                
                    if (User.ID == ClsDic.DicRole["超级管理员"])
                    {
                        ((dynamic)base.Clients.All).UserLoginNotice("超级管理员：" + User.NAME + " 上线了!");
                        var list = (from p in queryable
                                    orderby p.MessageDate
                                    select p).ToList<SYS_CHATMESSAGE>().Select(
                                         p=>new {
                                              UserName= this.UserManage.Get(m => m.ID == p.FromUser).NAME,
                                              UserFace = string.IsNullOrEmpty(this.UserManage.Get(m => m.ID == p.FromUser).FACE_IMG) ? ("/Pro/Project/User_Default_Avatat?name=" + this.UserManage.Get(m => m.ID == p.FromUser).NAME.Substring(0, 1)) : this.UserManage.Get(m => m.ID == p.FromUser).FACE_IMG,
                                              MessageType = this.GetMessageType(p.MessageType),
                                              FromUser = p.FromUser,
                                              MessageContent = p.MessageContent,
                                              MessageDate = p.MessageDate.GetDateTimeFormats('D')[1].ToString() + " - " + p.MessageDate.ToString("HH:mm:ss"),
                                              ConnectId = this.UserOnlineManage.LoadListAll(m => m.SYS_USER.ID == p.FromUser).FirstOrDefault<SYS_USER_ONLINE>().ConnectId
                                         }
                                  ).ToList();
                                ((dynamic)base.Clients.Client(base.Context.ConnectionId)).addHistoryMessageToPage(JsonConverter.Serialize(list, false));
                    }
                    else
                    {
                        SYS_DEPARTMENT Depart = this.GetUserDepart(User.DPTID);
                        if ((Depart != null) && !string.IsNullOrEmpty(Depart.ID))
                        {
                            base.Groups.Add(base.Context.ConnectionId, Depart.ID);
                            ((dynamic)base.Clients.All).UserLoginNotice(Depart.NAME + " - " + this.CodeManage.Get(m => (m.CODEVALUE == User.LEVELS) && (m.CODETYPE == "ZW")).NAMETEXT + "：" + User.NAME + " 上线了!");
                            int typeOfpublic = ClsDic.DicMessageType["广播"];
                            int typeOfgroup = ClsDic.DicMessageType["群组"];
                            int typeOfprivate = ClsDic.DicMessageType["私聊"];
                            var list2 = (from p in queryable
                                         where (((p.MessageType == typeOfpublic) || (p.FromUser == User.ID)) || ((p.MessageType == typeOfgroup) && (p.ToGroup == Depart.ID))) || ((p.MessageType == typeOfprivate) && (p.ToGroup == User.ID.ToString()))
                                         orderby p.MessageDate
                                         select p).ToList<SYS_CHATMESSAGE>().Select(
                                            p => new
                                            {
                                                UserName = this.UserManage.Get(m => m.ID == p.FromUser).NAME,
                                                UserFace = string.IsNullOrEmpty(this.UserManage.Get(m => m.ID == p.FromUser).FACE_IMG) ? ("/Pro/Project/User_Default_Avatat?name=" + this.UserManage.Get(m => m.ID == p.FromUser).NAME.Substring(0, 1)) : this.UserManage.Get(m => m.ID == p.FromUser).FACE_IMG,
                                                MessageType = this.GetMessageType(p.MessageType),
                                                FromUser = p.FromUser,
                                                MessageContent = p.MessageContent,
                                                MessageDate = p.MessageDate.GetDateTimeFormats('D')[1].ToString() + " - " + p.MessageDate.ToString("HH:mm:ss"),
                                                ConnectId = this.UserOnlineManage.LoadListAll(m => m.SYS_USER.ID == p.FromUser).FirstOrDefault<SYS_USER_ONLINE>().ConnectId
                                            }
                                         ).ToList();
                            ((dynamic)base.Clients.Client(base.Context.ConnectionId)).addHistoryMessageToPage(JsonConverter.Serialize(list2, false));
                        }
                    }
                    ((dynamic)base.Clients.All).ContactsNotice(JsonConverter.Serialize(entity, false));
                }
            }
            catch (Exception exception)
            {
                ((dynamic)base.Clients.Client(base.Context.ConnectionId)).UserLoginNotice("出错了：" + exception.Message);
                throw exception.InnerException;
            }
        }

        public void Send(string message, string groupId)
        {
            try
            {
                SYS_USER_ONLINE sys_user_online = this.UserOnlineManage.LoadListAll(p => p.ConnectId == this.Context.ConnectionId).FirstOrDefault<SYS_USER_ONLINE>();
                if (string.IsNullOrEmpty(groupId))
                {
                    SYS_CHATMESSAGE entity = new SYS_CHATMESSAGE
                    {
                        FromUser = sys_user_online.FK_UserId,
                        MessageType = ClsDic.DicMessageType["广播"],
                        MessageContent = message,
                        MessageDate = DateTime.Now,
                        MessageIP = Utils.GetIP()
                    };
                    this.ChatMessageManage.Save(entity);
                    Message message2 = new Message
                    {
                        ConnectId = sys_user_online.ConnectId,
                        UserName = sys_user_online.SYS_USER.NAME,
                        UserFace = string.IsNullOrEmpty(sys_user_online.SYS_USER.FACE_IMG) ? ("/Pro/Project/User_Default_Avatat?name=" + sys_user_online.SYS_USER.NAME.Substring(0, 1)) : sys_user_online.SYS_USER.FACE_IMG,
                        MessageDate = DateTime.Now.GetDateTimeFormats('D')[1].ToString() + " - " + DateTime.Now.ToString("HH:mm:ss"),
                        MessageContent = message,
                        MessageType = "public",
                        UserId = sys_user_online.SYS_USER.ID
                    };
                    ((dynamic)base.Clients.All).addNewMessageToPage(JsonConverter.Serialize(message2, false));
                }
                else
                {
                    SYS_CHATMESSAGE sys_chatmessage2 = new SYS_CHATMESSAGE
                    {
                        FromUser = sys_user_online.FK_UserId,
                        MessageType = ClsDic.DicMessageType["群组"],
                        MessageContent = message,
                        MessageDate = DateTime.Now,
                        MessageIP = Utils.GetIP(),
                        ToGroup = groupId
                    };
                    this.ChatMessageManage.Save(sys_chatmessage2);
                    Message message4 = new Message
                    {
                        ConnectId = sys_user_online.ConnectId,
                        UserName = sys_user_online.SYS_USER.NAME,
                        UserFace = string.IsNullOrEmpty(sys_user_online.SYS_USER.FACE_IMG) ? ("/Pro/Project/User_Default_Avatat?name=" + sys_user_online.SYS_USER.NAME.Substring(0, 1)) : sys_user_online.SYS_USER.FACE_IMG,
                        MessageDate = DateTime.Now.GetDateTimeFormats('D')[1].ToString() + " - " + DateTime.Now.ToString("HH:mm:ss"),
                        MessageContent = message,
                        MessageType = "group",
                        UserId = sys_user_online.SYS_USER.ID
                    };
                    ((dynamic)base.Clients.Group(groupId, new string[0])).addNewMessageToPage(JsonConverter.Serialize(message4, false));
                    SYS_DEPARTMENT userDepart = this.GetUserDepart(sys_user_online.SYS_USER.DPTID);
                    if (userDepart == null)
                    {
                        ((dynamic)base.Clients.Client(base.Context.ConnectionId)).addNewMessageToPage(JsonConverter.Serialize(message4, false));
                    }
                    else if (userDepart.ID != groupId)
                    {
                        ((dynamic)base.Clients.Client(base.Context.ConnectionId)).addNewMessageToPage(JsonConverter.Serialize(message4, false));
                    }
                }
            }
            catch (Exception exception)
            {
                ((dynamic)base.Clients.Client(base.Context.ConnectionId)).addSysMessageToPage("系统消息：消息发送失败，请稍后再试！");
                throw exception.InnerException;
            }
        }

        public void SendSingle(string clientId, string message)
        {
            try
            {
                if (string.IsNullOrEmpty(clientId))
                {
                    ((dynamic)base.Clients.Client(base.Context.ConnectionId)).addSysMessageToPage("系统消息：用户不存在！");
                }
                else
                {
                    SYS_USER_ONLINE sys_user_online = this.UserOnlineManage.LoadListAll(p => p.ConnectId == this.Context.ConnectionId).FirstOrDefault<SYS_USER_ONLINE>();
                    SYS_USER_ONLINE sys_user_online2 = this.UserOnlineManage.LoadListAll(p => p.ConnectId == clientId).FirstOrDefault<SYS_USER_ONLINE>();
                    if (sys_user_online2 == null)
                    {
                        ((dynamic)base.Clients.Client(base.Context.ConnectionId)).addSysMessageToPage("系统消息：用户不存在！");
                    }
                    else
                    {
                        SYS_CHATMESSAGE entity = new SYS_CHATMESSAGE
                        {
                            FromUser = sys_user_online.FK_UserId,
                            MessageType = ClsDic.DicMessageType["私聊"],
                            MessageContent = message,
                            MessageDate = DateTime.Now,
                            MessageIP = Utils.GetIP(),
                            ToGroup = sys_user_online.SYS_USER.ID.ToString()
                        };
                        this.ChatMessageManage.Save(entity);
                        Message message2 = new Message
                        {
                            ConnectId = sys_user_online.ConnectId,
                            UserName = sys_user_online.SYS_USER.NAME,
                            UserFace = string.IsNullOrEmpty(sys_user_online.SYS_USER.FACE_IMG) ? ("/Pro/Project/User_Default_Avatat?name=" + sys_user_online.SYS_USER.NAME.Substring(0, 1)) : sys_user_online.SYS_USER.FACE_IMG,
                            MessageDate = DateTime.Now.GetDateTimeFormats('D')[1].ToString() + " - " + DateTime.Now.ToString("HH:mm:ss"),
                            MessageContent = message,
                            MessageType = "private",
                            UserId = sys_user_online.SYS_USER.ID
                        };
                        if (sys_user_online2.IsOnline)
                        {
                            ((dynamic)base.Clients.Client(clientId)).addNewMessageToPage(JsonConverter.Serialize(message2, false));
                        }
                        ((dynamic)base.Clients.Client(base.Context.ConnectionId)).addNewMessageToPage(JsonConverter.Serialize(message2, false));
                    }
                }
            }
            catch (Exception exception)
            {
                ((dynamic)base.Clients.Client(base.Context.ConnectionId)).addSysMessageToPage("系统消息：消息发送失败，请稍后再试！");
                throw exception.InnerException;
            }
        }
    }
}

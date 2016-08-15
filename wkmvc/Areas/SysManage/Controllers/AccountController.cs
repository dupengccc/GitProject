using Service.IService.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Common.JsonHelper;
using Common;
using wkmvc.Controllers;
using Models;

namespace wkmvc.Areas.SysManage.Controllers
{
    public class AccountController : BaseController
    {
        #region 声明容器
        /// <summary>
        /// 用户管理
        /// add yuangang by 2016-05-16
        /// </summary>
        IUserManage UserManage { get; set; }
        /// <summary>
        /// 日志记录
        /// </summary>
        log4net.Ext.IExtLog log = log4net.Ext.ExtLogManager.GetLogger("dblog");
        #endregion

        #region 基本视图
        public ActionResult login()
        {
            return View();
        }
        #endregion

        #region 登录验证
        /// <summary>
        /// 登录验证
        /// add dupeng by 2016-05-16
        /// </summary>
        // [ValidateAntiForgeryToken]
        public ActionResult PostLogin(Domain.SYS_USER item)
        {


            var code = Request.Form["code"];
            var json = new JsonHelper() { Msg = "登录成功", Status = "n" };
            try
            {
                if (!string.IsNullOrEmpty(SessionHelper.Get("code")))
                {
                    if (!string.IsNullOrEmpty(code) && SessionHelper.Get("code").ToLower() == code.ToLower())
                    {
                        //调用登录验证接口 返回用户实体类
                        var users = UserManage.UserLogin(item.ACCOUNT.Trim(), item.PASSWORD.Trim());
                        if (users != null)
                        {
                            //是否锁定
                            if (users.ISCANLOGIN == 1)
                            {
                                json.Msg = "用户已锁定，禁止登录，请联系管理员进行解锁";
                                log.Warn(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
                                return Json(json);
                            }
                            json.Status = "y";
                            var Account = UserManage.GetAccountByUser(users);
                            SessionHelper.SetSession("CurrentUser", Account);
                            string cookie = "{\"id\":\""+ Account.Id+ "\",\"username\":\"" + Account.LogName + "\",\"password\":\"" + Account.PassWord + "\",\"ToKen\":\"" + Session.SessionID + "\"}";
                            CookieHelper.SetCookie("Cooke_rememberme", new Common.CryptHelper.AESCrypt().Encrypt(cookie),null);
                            var sysuser = UserManage.Get(p => p.ID == users.ID);
                            sysuser.LastLoginIP = Utils.GetIP();
                            UserManage.Update(sysuser);
                            json.ReUrl = "sys/Home/Index";
                            log.Info(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
                        }
                        else
                        {
                            json.Msg = "用户名或密码不正确";
                            log.Error(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
                        }

                    }
                    else
                    {
                        json.Msg = "验证码错误";
                        log.Error(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
                    }
                }
                else
                {
                    json.Msg = "验证码已经过期!请刷新验证码";
                    log.Error(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
                }
            }
            catch (Exception e)
            {
                json.Msg = e.Message;
                log.Error(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
            }
       
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region  生成随机码
        public FileContentResult ValidateCode()
        {
            string code = string.Empty;
            System.IO.MemoryStream ms = new verify_code().Create(out code);
            SessionHelper.SetSession("code", code);
            Response.ClearContent();//清空输出流
            return File(ms.ToArray(), @"image/png");
        }
        #endregion

    }

}
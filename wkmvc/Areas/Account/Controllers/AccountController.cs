using Common.JsonHelper;
using log4net.Ext;
using Models;
using Service.IService.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wkmvc.Controllers;

namespace wkmvc.Areas.Account.Controllers
{
    public class AccountController : BaseController
    {
        /// <summary>
        /// 容器
        /// </summary>
        /// <returns></returns>
        IUserManage UserManage { get; set; }
        ExtLogImpl log;

        /// <summary>
        /// 视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Login(Domain.SYS_USER item)
        {
            var json = new JsonHelper() {Msg="登录成功",Status="n" };
            try
            {
                var code = Request.Form["code"];
                var users = UserManage.UserLogin(item.NAME, item.PASSWORD);
                if (users != null)
                {
                    if (users.ISCANLOGIN == 1)
                    {
                        json.Msg = "用户已经锁定,禁止登录,请联系管理员,解锁";
                        return Json(json);
                    }
                    json.Status = "y";
                    json.Msg = "用户登录成功了";
                    return Json(json);
                }
                else
                {
                    json.Status = "n";
                    json.Msg = "用户或密码不正确";
                    return Json(json);
                }
            }
            catch (Exception er)
            {
                json.Status = "n";
                json.Msg = "登录异常";
                return Json(json);

            }
        }

        #region  生成随机码
        public FileContentResult ValidateCode()
        {
            string code = string.Empty;
            System.IO.MemoryStream ms = new verify_code().Create(out code);
            Session["code"] = code;
            Response.ClearContent();//清空输出流
            return File(ms.ToArray(), @"image/png");
        }
        #endregion


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace Web.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            if (base.IsLogOn)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Register()
        {
            if (base.IsLogOn)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        
        [HttpPost]
        public void RegisterSubmit(FormCollection form)
        {
            XCLShouCang.BLL.UserInfo bll = new XCLShouCang.BLL.UserInfo();
            XCLShouCang.Model.UserInfo model = new XCLShouCang.Model.UserInfo();
            Models.Login.RegisterModel viewModel = new Models.Login.RegisterModel();
            viewModel.UserName = (form["txtUserName"]??"").Trim();
            viewModel.Pwd = form["txtPwd"]??"";
            viewModel.ConfirmPwd = form["txtConfirmPwd"];
            viewModel.Email = (form["txtEmail"] ?? "").Trim();
            ValidateModel(viewModel);
            model.UserName = viewModel.UserName;
            model.Email = viewModel.Email;
            model.Pwd = XCLNetTools.StringHander.StringUtil.str_md5(viewModel.Pwd);
            if (bll.AddUserInfo(model) > 0)
            {
                XCLNetTools.Message.Log.WriteMessage(string.Format(@"恭喜您，注册成功！<a href=""{0}"">【马上登录】</a>", Url.Action("Index", "Login")));
            }
            else
            {
                XCLNetTools.Message.Log.WriteMessage("注册失败，请重试！");
            }
        }

        [HttpPost]
        public void LogOnSubmit(FormCollection form)
        {
            try
            {
                XCLShouCang.BLL.UserInfo bll = new XCLShouCang.BLL.UserInfo();
                XCLShouCang.Model.UserInfo model = new XCLShouCang.Model.UserInfo();
                Models.Login.LogOnModel viewModel = new Models.Login.LogOnModel();
                viewModel.UserName = (form["txtUserName"] ?? "").Trim();
                viewModel.Pwd = form["txtPwd"];
                ValidateModel(viewModel);
                if (bll.IsExists(viewModel.UserName, XCLNetTools.StringHander.StringUtil.str_md5(viewModel.Pwd)))
                {
                    var userInfo = bll.GetModel(viewModel.UserName);
                    base.SetLogInfo(1, userInfo);

                    XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel()
                    {
                        IsRefresh = true,
                        IsSuccess = true,
                        Message = "登录成功！"
                    };
                    XCLNetTools.Message.Log.WriteMessage(msgModel);
                }
                else
                {
                    XCLNetTools.Message.Log.WriteMessage("用户名或密码错误！");
                }
            }
            catch
            {
                XCLNetTools.Message.Log.WriteMessage("登录失败，请重试！");
            }
        }

        public ActionResult LogOut()
        {
            base.SetLogInfo(0,null);
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 第三方登录
        /// </summary>
        [HttpPost]
        public ActionResult LoginByThird()
        {
            string thirdLoginType = XCLNetTools.StringHander.FormHelper.GetString("ThirdLoginType");
            string thirdLoginToken = XCLNetTools.StringHander.FormHelper.GetString("ThirdLoginToken");
            string nickName=XCLNetTools.StringHander.FormHelper.GetString("NickName");
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            if (!string.IsNullOrEmpty(thirdLoginType) && !string.IsNullOrEmpty(thirdLoginToken))
            {
                XCLShouCang.BLL.UserInfo bll = new XCLShouCang.BLL.UserInfo();
                XCLShouCang.Model.UserInfo uModel = null;
                if (bll.IsExistsThirdLogin(thirdLoginType, thirdLoginToken))
                {
                    //使用该账号
                    uModel = bll.GetModelByThirdLogin(thirdLoginType, thirdLoginToken);
                    base.SetLogInfo(1, uModel);
                    msgModel.IsSuccess = true;
                }
                else
                { 
                    //系统自动创建新账号
                    uModel = new XCLShouCang.Model.UserInfo();
                    uModel.UserName = XCLNetTools.StringHander.RandomHelper.GenerateStringId();
                    uModel.NickName = nickName;
                    uModel.ThirdLoginToken = thirdLoginToken;
                    uModel.ThirdLoginType = thirdLoginType;
                    long resultID=bll.AddUserInfo(uModel);
                    if (resultID > 0)
                    {
                        base.SetLogInfo(1,bll.GetModel(resultID));
                        msgModel.IsSuccess = true;

                    }
                }
            }
            return Json(msgModel);
        }

        public ActionResult QQLoginCallBack()
        {
            return View("~/Views/Login/QQLoginCallBack.cshtml");
        }
    }
}

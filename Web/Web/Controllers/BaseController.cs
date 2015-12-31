using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        public static readonly string CurrentUserModelSessionName = "CurrentUserModelSession";
        public static readonly string UserLoginCookieName = "UserLoginCookie";

        private XCLShouCang.Model.UserInfo _currentUserModel = null;
        /// <summary>
        /// 当前用户 UserInfo Model
        /// </summary>
        public XCLShouCang.Model.UserInfo CurrentUserModel
        {
            get 
            {
                var tempModel=Session[BaseController.CurrentUserModelSessionName] as XCLShouCang.Model.UserInfo;
                return null == tempModel ? this._currentUserModel : tempModel;
            }
            set
            {
                Session[BaseController.CurrentUserModelSessionName] = value;
                this._currentUserModel = value;
            }
        }

        /// <summary>
        /// 当前用户视图model
        /// </summary>
        public XCLShouCang.Model.v_UserInfo V_CurrentUserModel
        {
            get 
            {
                return new XCLShouCang.BLL.v_UserInfo().GetModel(this.CurrentUserModel.UserID);    
            }
        }

        /// <summary>
        /// 是否已登录
        /// </summary>
        public bool IsLogOn
        {
            get { return null != this.CurrentUserModel; }
        }

        /// <summary>
        /// 当前页面操作类型
        /// </summary>
        public Common.CommonHelper.HandleType CurrentHandleType
        {
            get
            {
                Common.CommonHelper.HandleType type = Common.CommonHelper.HandleType.ADD;
                Enum.TryParse(XCLNetTools.StringHander.FormHelper.GetString("HandleType").ToUpper(), out type);
                return type;
            }
        }

        /// <summary>
        /// 拦截action
        /// </summary>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //先登录，如果登录成功，则赋值相关实体；如果登录失败，则判断此action是否必须登录，如果必须登录，则跳转到登录页
            this.LogOn();
            if (this.IsLogOn)
            {
                ViewBag.CurrentUserModel = this.CurrentUserModel;
                ViewBag.IsLogOn = this.IsLogOn;
                ViewBag.CurrentHandleType = this.CurrentHandleType;
            }
            else
            {
                object[] attrs = filterContext.ActionDescriptor.GetCustomAttributes(typeof(Web.Filter.MustLoginAttribute), true);
                if (null != attrs && attrs.Length > 0)
                {
                    filterContext.Result = RedirectToAction("Index", "Login");
                }
            }
        }

        /// <summary>
        /// 每个action之前登录操作
        /// </summary>
        private void LogOn()
        {
            //先判断在session中存不存在，若不存在，则重新使用cookie进行登录。
            XCLShouCang.Model.UserInfo tempUserModel = Session[BaseController.CurrentUserModelSessionName] as XCLShouCang.Model.UserInfo;
            if (null != tempUserModel)
            {
                return;
            }

            string userInfoCookie = XCLNetTools.StringHander.Common.GetCookies(BaseController.UserLoginCookieName);
            userInfoCookie = string.IsNullOrEmpty(userInfoCookie) ? Convert.ToString(Session[BaseController.UserLoginCookieName]) : userInfoCookie;

            if (!string.IsNullOrEmpty(userInfoCookie))
            {
                string userInfo = "";
                try
                {
                    userInfo = XCLNetTools.StringHander.DESEncrypt.Decrypt(userInfoCookie);
                    if (!string.IsNullOrEmpty(userInfo))
                    {
                        string[] userArr = userInfo.Split('|');
                        if (null != userArr && userArr.Length == 2)
                        {
                            XCLShouCang.BLL.UserInfo bll = new XCLShouCang.BLL.UserInfo();
                            Web.Models.Login.LogOnModel logOnModel = new Models.Login.LogOnModel();
                            logOnModel.UserName = userArr[0];
                            logOnModel.Pwd = userArr[1];
                            if (bll.IsExists(logOnModel.UserName, logOnModel.Pwd))
                            {
                                this.CurrentUserModel = bll.GetModel(logOnModel.UserName);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 设置登录与退出的相关信息（session/cookie...）
        /// </summary>
        /// <param name="type">0:退出/1:登录</param>
        public void SetLogInfo(int type,XCLShouCang.Model.UserInfo userInfo)
        {
            switch (type)
            { 
                    //退出
                case 0:
                    XCLNetTools.StringHander.Common.DelCookies(BaseController.UserLoginCookieName);
                    Session.Remove(BaseController.CurrentUserModelSessionName);
                    Session.Remove(BaseController.UserLoginCookieName);
                    break;
                    //登录
                case 1:
                    this.CurrentUserModel = userInfo;
                    string loginStr = XCLNetTools.StringHander.DESEncrypt.Encrypt(string.Format("{0}|{1}", this.CurrentUserModel.UserName, this.CurrentUserModel.Pwd));
                    XCLNetTools.StringHander.Common.SetCookies(BaseController.UserLoginCookieName, loginStr, 30);
                    Session[BaseController.UserLoginCookieName] = loginStr;
                    break;
            }
        }
    }
}

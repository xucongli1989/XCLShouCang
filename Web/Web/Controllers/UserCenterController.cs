using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UserCenterController : BaseController
    {

        [Web.Filter.MustLogin]
        [HttpGet]
        public ActionResult UserInfoUpdate()
        {
            return View("~/Views/UserAdmin/UserInfoUpdate.cshtml");
        }

        [HttpPost]
        [Web.Filter.MustLogin]
        public void UserInfoUpdate(FormCollection form)
        {
            Web.Models.UserCenter.UserInfoUpdateModel viewModel = new Models.UserCenter.UserInfoUpdateModel();
            viewModel.UserName = form["txtUserName"] ?? "";
            viewModel.Email = form["txtEmail"] ?? "";
            viewModel.Pwd = form["txtPwd"] ?? "";
            ValidateModel(viewModel);
            XCLShouCang.BLL.v_UserInfo vBLL=new XCLShouCang.BLL.v_UserInfo();
            XCLShouCang.BLL.UserInfo bll = new XCLShouCang.BLL.UserInfo();
            XCLShouCang.Model.UserInfo model = bll.GetModel(base.CurrentUserModel.UserID);
            model.Email = viewModel.Email;
            model.UserName = viewModel.UserName;
            if (!string.Equals(viewModel.UserName, base.CurrentUserModel.UserName,StringComparison.CurrentCultureIgnoreCase) && bll.IsExists(viewModel.UserName))
            {
                XCLNetTools.Message.Log.WriteMessage("该用户名已被占用，修改失败！");
                return;
            }
            if (!string.IsNullOrEmpty(viewModel.Pwd))
            {
                model.Pwd = XCLNetTools.StringHander.StringUtil.str_md5(viewModel.Pwd);
            }
            model.UpdateName = base.CurrentUserModel.UserName;
            model.UpdateTime = DateTime.Now;
            if (bll.Update(model))
            {
                base.SetLogInfo(1,model);
                XCLNetTools.Message.Log.WriteMessage("修改成功！");
            }
            else
            {
                XCLNetTools.Message.Log.WriteMessage("修改失败，请重试！");
            }
        }

    }
}

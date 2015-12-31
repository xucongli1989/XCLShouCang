using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class WebShareRelationController : BaseController
    {
        [Web.Filter.MustLogin]
        public void SetShare()
        {
            Web.Models.WebShareRelation.WebShareRelationModel viewModel = new Models.WebShareRelation.WebShareRelationModel();
            viewModel.IsShare = XCLNetTools.StringHander.FormHelper.GetInt("ckIsShare") == 1;
            viewModel.AccessPwd = XCLNetTools.StringHander.FormHelper.GetString("txtSharePwd");
            viewModel.WebTypeRootID = base.V_CurrentUserModel.RootWebTypeID;

            XCLShouCang.BLL.WebShareRelation bll = new XCLShouCang.BLL.WebShareRelation();
            XCLShouCang.Model.WebShareRelation model = new XCLShouCang.Model.WebShareRelation();
            model.AccessPwd = viewModel.AccessPwd;
            model.FK_WebTypeRootID = viewModel.WebTypeRootID;

            model.FK_WebTypeRootID = base.V_CurrentUserModel.RootWebTypeID;
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            if (bll.SetShare(model,viewModel.IsShare))
            {
                msgModel.IsSuccess = true;
                msgModel.Message = "设置成功！";
            }
            else
            {
                msgModel.IsSuccess = false;
                msgModel.Message = "操作失败，请重试！";
            }
            XCLNetTools.Message.Log.WriteMessage(msgModel);
        }
    }
}

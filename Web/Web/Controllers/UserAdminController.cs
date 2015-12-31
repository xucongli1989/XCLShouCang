using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;
using System.Net;

namespace Web.Controllers
{
    public class UserAdminController : BaseController
    {

        [Web.Filter.MustLogin]
        public ActionResult WebTypeList()
        {
            long parentWebTypeID = XCLNetTools.StringHander.FormHelper.GetLong("parentWebTypeID");
            parentWebTypeID = parentWebTypeID > 0 ? parentWebTypeID : base.V_CurrentUserModel.RootWebTypeID;

            Web.Models.WebType.WebTypeListModel model = new Models.WebType.WebTypeListModel();
            model.ParentWebTypeID = parentWebTypeID;
            //select
            model.WebTypeOptionStr= Web.Common.CommonHelper.GetWebTypeOptionStr(base.CurrentUserModel.UserID, parentWebTypeID);
            //数据绑定
            XCLShouCang.BLL.WebShareRelation relationBLL = new XCLShouCang.BLL.WebShareRelation();
            XCLShouCang.Model.WebShareRelation relationModel = null;
            XCLShouCang.BLL.WebType webTypeBLL = new XCLShouCang.BLL.WebType();
            XCLShouCang.BLL.v_WebType bll=new XCLShouCang.BLL.v_WebType();
            model.WebTypeList = bll.GetModelList(parentWebTypeID, base.CurrentUserModel.UserID);

            model.WebShareRelationModel = new Models.WebShareRelation.WebShareRelationModel();
            if (relationBLL.IsExistWebTypeRootID(base.V_CurrentUserModel.RootWebTypeID))
            {
                relationModel = relationBLL.GetModelByWebTypeRootID(base.V_CurrentUserModel.RootWebTypeID);
                if (null != relationModel)
                {
                    model.WebShareRelationModel.AccessPwd = relationModel.AccessPwd;
                    model.WebShareRelationModel.IsShare = true;
                }
            }

            return View("~/Views/UserAdmin/WebTypeList.cshtml", model);
        }

        [Web.Filter.MustLogin]
        public ActionResult WebURLInput()
        {
            XCLShouCang.BLL.WebType webTypeBLL = new XCLShouCang.BLL.WebType();
            Web.Models.WebType.WebTypeInputModel viewModel = new Models.WebType.WebTypeInputModel();
            viewModel.ParentID = XCLNetTools.StringHander.FormHelper.GetLong("ParentID");
            viewModel.WebTypeOptionStr = Web.Common.CommonHelper.GetWebTypeOptionStr(base.CurrentUserModel.UserID, viewModel.ParentID);
            return View("~/Views/UserAdmin/WebURLInput.cshtml",viewModel);
        }

        [Web.Filter.MustLogin]
        public void WebURLOutPut()
        {
            StringBuilder strHTML = new StringBuilder();

            #region 生成html文件
            strHTML.AppendFormat(@"
            <!DOCTYPE NETSCAPE-Bookmark-file-1>
            <!-- 该文件由系统自动生成，可以直接导入到浏览器中.  by:XCL-->
            <META HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=UTF-8"">
            <TITLE>Bookmarks</TITLE>
            <H1>Bookmarks</H1>
            ");

            XCLShouCang.BLL.WebType bll = new XCLShouCang.BLL.WebType();
            var webTypeList = bll.GetListByUserID(base.CurrentUserModel.UserID);

            Action<long> GetWebType_Action = null;
            GetWebType_Action = (long parentID) =>
            {
                var currentFileFolderList = webTypeList.Where(k => k.ParentID == parentID && k.IsFolder == 1).ToList();
                var currentFileList = webTypeList.Where(k => k.ParentID == parentID && k.IsFolder == 0).ToList();
                bool isEmpty = (null == currentFileFolderList || currentFileFolderList.Count == 0) && (null == currentFileList || currentFileList.Count == 0);
                if (!isEmpty)
                {
                    strHTML.Append("<DL><p>");
                }

                //文件夹
                if (null != currentFileFolderList && currentFileFolderList.Count > 0)
                {
                    currentFileFolderList = currentFileFolderList.OrderBy(k => k.Sort).ToList();
                    foreach (var m in currentFileFolderList)
                    {
                        strHTML.AppendFormat(@"<DT><H3 ADD_DATE=""0"" LAST_MODIFIED=""0"">{0}</H3>", m.TypeName);
                        GetWebType_Action(m.WebTypeID);
                    }
                }
                //文件
                if (null != currentFileList && currentFileList.Count > 0)
                {
                    currentFileList = currentFileList.OrderBy(k => k.Sort).ToList();
                    foreach (var m in currentFileList)
                    {
                        strHTML.AppendFormat(@"<DT><A HREF=""{0}"" ADD_DATE=""0"" ICON=""{1}"">{2}</A>", m.TypeURL, m.IcoURL, m.TypeName);
                    }
                }

                if (!isEmpty)
                {
                    strHTML.Append("</DL><p>");
                }
            };

            GetWebType_Action(base.V_CurrentUserModel.RootWebTypeID);
            #endregion


            #region 导出html文件
            DateTime dtNow = DateTime.Now;
            string dir = string.Format("~/Upload/Temp/{0}/{1}/",dtNow.Year, dtNow.Month);
            string fileName = string.Format("{0}BookMarks_{1}.html",dir , Guid.NewGuid());
            string fullPath = Server.MapPath(fileName);
            XCLNetTools.FileHandler.FileDirectory.MakeDirectory(Server.MapPath(dir));
            XCLNetTools.FileHandler.FileDirectory.CreateTextFile(fullPath);
            XCLNetTools.FileHandler.FileDirectory.AppendText(fullPath, strHTML.ToString(), System.Text.Encoding.UTF8);
            XCLNetTools.FileHandler.ComFile.DownLoadFile(fullPath,"我的收藏（可直接导入到浏览器）.html", true);
            #endregion

        }

        [Web.Filter.MustLogin]
        public ActionResult MyHome()
        {
            return View("~/Views/UserAdmin/MyHome.cshtml");
        }

        [Web.Filter.MustLogin]
        public ActionResult GetMyWebTypeList()
        {
            Web.Models.WebType.MyWebTypeShowModel viewModel = new Web.Models.WebType.MyWebTypeShowModel();
            if (base.IsLogOn)
            {
                viewModel.ParentID = XCLNetTools.StringHander.FormHelper.GetLong("parentID");
                viewModel.ParentID = viewModel.ParentID > 0 ? viewModel.ParentID : base.V_CurrentUserModel.RootWebTypeID;

                XCLShouCang.BLL.WebType webTypeBLL = new XCLShouCang.BLL.WebType();
                XCLShouCang.BLL.v_WebType vBLL = new XCLShouCang.BLL.v_WebType();
                System.Text.StringBuilder str = new System.Text.StringBuilder();
                List<XCLShouCang.Model.v_WebType> lst = vBLL.GetModelList(viewModel.ParentID, base.CurrentUserModel.UserID);
                if (null != lst && lst.Count > 0)
                {
                    viewModel.FolderList = lst.Where(k => k.IsFolder == 1).ToList();
                    viewModel.FileList = lst.Where(k => k.IsFolder == 0).ToList();
                }
            }
            return View("~/Views/UserAdmin/GetMyWebTypeList.cshtml", viewModel);
        }
    }
}

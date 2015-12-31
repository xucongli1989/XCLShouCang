using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Text.RegularExpressions;

namespace Web.Controllers
{
    public class WebTypeAddController : BaseController
    {
        [Web.Filter.MustLogin]
        public ActionResult Index()
        {
            XCLShouCang.BLL.WebType webTypeBLL = new XCLShouCang.BLL.WebType();
            XCLShouCang.Model.WebType webTypeModel = null;
            Web.Models.WebType.WebTypeAddModel viewModel = new Models.WebType.WebTypeAddModel();
            viewModel.WebTypeID = XCLNetTools.StringHander.FormHelper.GetLong("WebTypeID");
            viewModel.ParentID = XCLNetTools.StringHander.FormHelper.GetLong("ParentID");
            viewModel.IsFolder = XCLNetTools.StringHander.FormHelper.GetInt("IsFolder");

            var parentModel=webTypeBLL.GetModel(base.CurrentUserModel.UserID, viewModel.ParentID);
            viewModel.ParentModel = parentModel;

            switch (base.CurrentHandleType)
            { 
                case Common.CommonHelper.HandleType.ADD:
                    break;
                case Common.CommonHelper.HandleType.UPDATE:
                    //修改
                    webTypeModel = webTypeBLL.GetModel(base.CurrentUserModel.UserID, viewModel.WebTypeID);
                    if (null != webTypeModel)
                    {
                        viewModel.IcoURL = webTypeModel.IcoURL;
                        viewModel.IsFolder = webTypeModel.IsFolder;
                        viewModel.ParentID = webTypeModel.ParentID;
                        viewModel.TypeDescription = webTypeModel.TypeDescription;
                        viewModel.TypeName = webTypeModel.TypeName;
                        viewModel.TypeURL = webTypeModel.TypeURL;
                        viewModel.WebTypeID = webTypeModel.WebTypeID;
                    }
                    break;
            }

            return View("~/Views/UserAdmin/WebTypeAdd.cshtml", viewModel);
        }

        [Web.Filter.MustLogin]
        public ActionResult Show()
        {
            long webTypeID = XCLNetTools.StringHander.FormHelper.GetLong("WebTypeID");
            XCLShouCang.BLL.WebType bll = new XCLShouCang.BLL.WebType();
            XCLShouCang.Model.WebType model = bll.GetModel(base.CurrentUserModel.UserID, webTypeID);
            return View("~/Views/UserAdmin/WebTypeShow.cshtml",model);
        }

        #region 分类操作

        [HttpPost]
        [ValidateInput(false)]
        [Web.Filter.MustLogin]
        public void Add(FormCollection form)
        {
            Web.Models.WebType.WebTypeAddModel viewModel = new Models.WebType.WebTypeAddModel()
            {
                IcoURL = (form["txtIcoURL"] ?? "").Trim(),
                IsFolder = XCLNetTools.StringHander.Common.GetInt(form["IsFolder"]),
                ParentID = XCLNetTools.StringHander.Common.GetLong(form["ParentID"]),
                TypeDescription = (form["txtTypeDescription"] ?? "").Trim(),
                TypeName = (form["txtTypeName"] ?? "").Trim(),
                TypeURL = (form["txtTypeURL"] ?? "").Trim(),
                WebTypeID = XCLNetTools.StringHander.Common.GetLong(form["WebTypeID"])
            };
            if (viewModel.IsFolder == 1)
            {
                viewModel.IcoURL = string.Empty;
            }
            else
            {
                if (string.IsNullOrEmpty(viewModel.IcoURL))
                {
                    viewModel.IcoURL = Web.Common.CommonHelper.DefaultIcoURL;
                }
                else
                {
                    viewModel.IcoURL = viewModel.IcoURL.Length > 1000 ? Web.Common.CommonHelper.DefaultIcoURL : viewModel.IcoURL;
                }
            }
            ValidateModel(viewModel);

            XCLShouCang.BLL.WebType bll = new XCLShouCang.BLL.WebType();
            XCLShouCang.Model.WebType model = null;
            switch (base.CurrentHandleType)
            { 
                case Common.CommonHelper.HandleType.ADD:
                    model = new XCLShouCang.Model.WebType();
                    model.ParentID = viewModel.ParentID;
                    model.TypeName = viewModel.TypeName;
                    model.IcoURL = viewModel.IcoURL;
                    model.TypeDescription = viewModel.TypeDescription;
                    model.TypeURL = viewModel.TypeURL;
                    model.CreatorName = base.CurrentUserModel.UserName;
                    model.CreateTime = DateTime.Now;
                    model.FK_UserID = base.CurrentUserModel.UserID;
                    model.IsDel = 0;
                    model.IsReadOnly = 0;
                    model.Sort = 0;
                    model.IsFolder = viewModel.IsFolder;

                    var parentModel=bll.GetModel(base.CurrentUserModel.UserID, model.ParentID);
                    if (null == parentModel || parentModel.IsFolder != 1)
                    {
                        XCLNetTools.Message.Log.WriteMessage("父对象必须为有效的收藏夹，本次添加失败，请重试！");
                        break;
                    }

                    model.IsShare = parentModel.IsShare;

                    if (bll.Add(model) > 0)
                    {
                        XCLNetTools.Message.Log.WriteMessage("添加成功！");
                    }
                    else
                    {
                        XCLNetTools.Message.Log.WriteMessage("添加失败，请重试！");
                    }
                    break;
                case Common.CommonHelper.HandleType.UPDATE:
                    model = bll.GetModel(base.CurrentUserModel.UserID, viewModel.WebTypeID);
                    if (model.ParentID == 0)
                    {
                        XCLNetTools.Message.Log.WriteMessage("不允许更改根目录！");
                        break;
                    }
                    model.ParentID = viewModel.ParentID;
                    model.TypeName = viewModel.TypeName;
                    model.IcoURL = viewModel.IcoURL;
                    model.TypeDescription = viewModel.TypeDescription;
                    model.TypeURL = viewModel.TypeURL;
                    model.UpdateName = base.CurrentUserModel.UserName;
                    model.UpdateTime = DateTime.Now;
                    if (bll.Update(model))
                    {
                        XCLNetTools.Message.Log.WriteMessage("修改成功！");
                    }
                    else
                    {
                        XCLNetTools.Message.Log.WriteMessage("修改失败，请重试！");
                    }
                    break;
            }
        }

        [HttpPost]
        [Web.Filter.MustLogin]
        public void Del(FormCollection form)
        {
            string webTypeIDStr = form["ckWebTypeID"] ?? "";
            if (!string.IsNullOrEmpty(webTypeIDStr))
            {
                List<long> ids = webTypeIDStr.Split(',').ToList().ConvertAll(k => XCLNetTools.StringHander.Common.GetLong(k));
                long typeid = XCLNetTools.StringHander.Common.GetLong(form["selParentID"]);
                XCLShouCang.BLL.WebType bll = new XCLShouCang.BLL.WebType();
                bll.DeleteAll(ids, base.CurrentUserModel.UserID, base.CurrentUserModel.UserName, true);
                XCLNetTools.Message.Log.WriteMessage(new XCLNetTools.Message.MessageModel()
                {
                    IsRefresh = true,
                    IsSuccess = true,
                    Message = "删除成功！"
                });
            }
            else
            {
                XCLNetTools.Message.Log.WriteMessage("请选择要删除的数据！");
            }
        }

        [HttpPost]
        [Web.Filter.MustLogin]
        public void Input(FormCollection form)
        {
            Web.Models.WebType.WebTypeInputModel viewModel = new Models.WebType.WebTypeInputModel() {
               ParentID = XCLNetTools.StringHander.Common.GetLong(form["selParentID"]),
               UploadFileName=form["hdUploadSuccessPath"]
            };
            ValidateModel(viewModel);
            XCLShouCang.BLL.WebType bll = new XCLShouCang.BLL.WebType();
            XCLShouCang.Model.WebType model = null;
            List<XCLShouCang.Model.WebType> lst = new List<XCLShouCang.Model.WebType>();
            DateTime dtNow = DateTime.Now;

            var parentModel = bll.GetModel(base.CurrentUserModel.UserID, viewModel.ParentID);
            if (null == parentModel || parentModel.IsFolder != 1)
            {
                XCLNetTools.Message.Log.WriteMessage("父对象必须为有效的收藏夹，本次导入失败，请重试！");
                return;
            }

            Regex reg = new Regex(@"(<dt>)|(<p>)|(\n)|(\r)",RegexOptions.IgnoreCase);
            string strFile= System.IO.File.ReadAllText(Server.MapPath(viewModel.UploadFileName), System.Text.Encoding.UTF8);
            strFile = reg.Replace(strFile, "");
            strFile = new Regex(@">\s+<").Replace(strFile, "><");

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(strFile);

            Action<HtmlAgilityPack.HtmlNode,string> GetNodeItems = null;
            GetNodeItems = (HtmlAgilityPack.HtmlNode rootNode,string parentGuid) => {
                //收藏夹
                HtmlAgilityPack.HtmlNodeCollection folderNodeList = rootNode.SelectNodes("h3");
                if (null != folderNodeList && folderNodeList.Count > 0)
                {
                    foreach (var m in folderNodeList)
                    {
                        model = new XCLShouCang.Model.WebType();
                        model.CreateTime = dtNow;
                        model.CreatorName = base.CurrentUserModel.UserName;
                        model.FK_UserID = base.CurrentUserModel.UserID;
                        model.IsDel = 0;
                        model.IsFolder = 1;
                        model.IsReadOnly = 0;
                        model.WebTypeGid = Guid.NewGuid().ToString("N");
                        model.ParentGid = parentGuid;
                        model.IsShare = parentModel.IsShare;
                        model.Sort = 0;
                        model.TypeDescription = "";
                        model.TypeName = m.InnerText;
                        lst.Add(model);
                        //m的子项
                        var nextNode = m.NextSibling;
                        if (null != nextNode && string.Equals(nextNode.Name, "dl", StringComparison.CurrentCultureIgnoreCase))
                        {
                            GetNodeItems(nextNode, model.WebTypeGid);
                        }
                    }
                }


                //收藏项
                HtmlAgilityPack.HtmlNodeCollection nodeList = rootNode.SelectNodes("a");
                if (null != nodeList && nodeList.Count > 0)
                {
                    foreach (var m in nodeList)
                    {
                        model = new XCLShouCang.Model.WebType();
                        model.CreateTime = dtNow;
                        model.CreatorName = base.CurrentUserModel.UserName;
                        model.FK_UserID = base.CurrentUserModel.UserID;
                        model.IcoURL = null == m.Attributes["ICON"] ? "" : m.Attributes["ICON"].Value;
                        if (string.IsNullOrEmpty(model.IcoURL))
                        {
                            model.IcoURL = Web.Common.CommonHelper.DefaultIcoURL;
                        }
                        else
                        {
                            model.IcoURL = model.IcoURL.Length > 1000 ? Web.Common.CommonHelper.DefaultIcoURL : model.IcoURL;
                        }
                        model.IsDel = 0;
                        model.IsFolder = 0;
                        model.IsReadOnly = 0;
                        model.ParentGid = parentGuid;
                        model.IsShare = parentModel.IsShare;
                        model.Sort = 0;
                        model.TypeDescription = "";
                        model.TypeName = m.InnerText;
                        model.TypeURL = null == m.Attributes["HREF"] ? "" : m.Attributes["HREF"].Value;
                        lst.Add(model);
                    }
                }
            };

            string rootGuid = Guid.NewGuid().ToString("N");
            GetNodeItems(doc.DocumentNode.ChildNodes["dl"], rootGuid);

            if (bll.BulkInputAdd(lst, rootGuid, viewModel.ParentID))
            {
                XCLNetTools.Message.Log.WriteMessage(string.Format("您已成功导入【{0}】条收藏！",lst.Count));
            }
            else
            {
                XCLNetTools.Message.Log.WriteMessage("抱歉，导入失败了，请重试！");
            }
        }

        #endregion

    }
}

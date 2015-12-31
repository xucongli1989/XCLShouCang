using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace Web.Controllers.CommonController
{
    public class CommonController : BaseController
    {
        //
        // GET: /Common/

        [Web.Filter.MustLogin]
        [HttpPost]
        public void UploadFile(FormCollection form)
        {
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();

            HttpPostedFileBase file = Request.Files["UploadData"];
            string path = form["uploadPath"];
            if (string.IsNullOrEmpty(path) || null == file)
            {
                XCLNetTools.Message.Log.WriteMessage("您没有选择任何文件！");
                return;
            }
            //扩展名校验
            string ext = XCLNetTools.FileHandler.ComFile.GetExtName(file.FileName);
            string[] validExt = { "HTML", "HTM", "JPG", "JPEG" };
            if (string.IsNullOrEmpty(ext) || !validExt.Contains(ext.ToUpper()))
            {
                XCLNetTools.Message.Log.WriteMessage("您选择的文件禁止上传，请选择其它文件！");
                return;
            }
            if (ext.ToUpper().Contains("HTM"))
            {
                ext = "txt";
            }
            try
            {
                DateTime dtNow = DateTime.Now;
                string dir = string.Format("~/{0}/{1}/{2}/", path.TrimEnd('/').TrimStart('/'), dtNow.Year, dtNow.Month);
                string fullName = string.Format("{0}{1}.{2}", dir, Guid.NewGuid(), ext);
                string dirPath = Server.MapPath(dir);
                string fullNamePath = Server.MapPath(fullName);

                XCLNetTools.FileHandler.ComFile.GetSaveDirectory(dirPath);
                file.SaveAs(fullNamePath);
                if (System.IO.File.Exists(fullNamePath))
                {
                    msgModel.Message = fullName;
                    msgModel.IsSuccess = true;
                    XCLNetTools.Message.Log.WriteMessage(msgModel);
                }
                else
                {
                    msgModel.IsSuccess = false;
                    XCLNetTools.Message.Log.WriteMessage(msgModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 收藏地址转发
        /// </summary>
        public ActionResult GoURL(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                XCLNetTools.StringHander.Common.ResponseClearWrite("您的链接地址不存在，请核实地址是否正确！");
                return null;
            }
            return RedirectPermanent(url);
        }

        public JsonResult GetSearchJsonResult(string keyWord)
        {
            List<XCLShouCang.Model.Custom.WebTypeSearch> resultLst = null;
            keyWord = keyWord.Trim();
            if (!string.IsNullOrEmpty(keyWord))
            {
                XCLShouCang.Model.Custom.WebTypeSearch searchModel = new XCLShouCang.Model.Custom.WebTypeSearch();
                searchModel.FK_UserID = base.CurrentUserModel.UserID;
                searchModel.TypeName = keyWord;
                searchModel.TypeURL = keyWord;
                XCLShouCang.BLL.WebType bll = new XCLShouCang.BLL.WebType();
                resultLst=bll.GetSearchList(searchModel,8);
            }
            if (null == resultLst)
            {
                resultLst = new List<XCLShouCang.Model.Custom.WebTypeSearch>();
            }
            return Json(resultLst,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search()
        {
            return View("~/Views/Common/Search.cshtml");
        }

        [Web.Filter.MustLogin]
        public ActionResult Host()
        {
            string path = Server.MapPath("~/Resources/Doc/googleHost.txt");
            string[] googleHostArray= System.IO.File.ReadAllLines(path,System.Text.Encoding.Default);
            ViewBag.GoogleHost = string.Join("<br/>",googleHostArray);
            return View("~/Views/Common/Host.cshtml");
        }

        public ActionResult About()
        {
            return View("~/Views/Common/About.cshtml");
        }

        public ActionResult ToUse()
        {
            return View("~/Views/Common/ToUse.cshtml");
        }

        public ActionResult Comment()
        {
            return View();
        }
    }
}

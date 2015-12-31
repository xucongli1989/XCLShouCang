using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Web.Common
{
    public class CommonHelper
    {
        /// <summary>
        /// 页面操作类型
        /// </summary>
        public enum HandleType
        {
            ADD,
            DEL,
            UPDATE,
            INPUT,
            OUTPUT
        }

        /// <summary>
        /// 第三方登录网站枚举
        /// </summary>
        public enum ThirdLoginTypeEnum
        { 
            QQ,
            Sina
        }

        /// <summary>
        /// 网站根路径
        /// </summary>
        public static readonly string RootURL=XCLNetTools.StringHander.Common.RootURL;

        /// <summary>
        /// 网站基本信息
        /// </summary>
        public static readonly Web.Models.Common.WebInfoModel WebInfo = new Models.Common.WebInfoModel()
        {
                Description = XCLNetTools.XML.ConfigClass.GetConfigString("Description"),
                SimpleDescription = XCLNetTools.XML.ConfigClass.GetConfigString("SimpleDescription"),
                KeyWords = XCLNetTools.XML.ConfigClass.GetConfigString("KeyWords"),
                Title = XCLNetTools.XML.ConfigClass.GetConfigString("Title"),
                WebName = XCLNetTools.XML.ConfigClass.GetConfigString("WebName"),
                WebURL = XCLNetTools.XML.ConfigClass.GetConfigString("WebURL").Split(',').ToList(),
                AdminEmail = XCLNetTools.XML.ConfigClass.GetConfigString("AdminEmail"),
                CopyRight = XCLNetTools.XML.ConfigClass.GetConfigString("CopyRight").Replace("{Year}",DateTime.Now.Year.ToString()),
                WebMainURL = XCLNetTools.XML.ConfigClass.GetConfigString("WebMainURL")
        };

        /// <summary>
        /// 默认的ico图标
        /// </summary>
        public static readonly string DefaultIcoURL = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAuklEQVQ4ja1Ryw6DMAxz0ET/jvEDXOCb6I3BCuMb2wvZgYEIfUxisxSpbizXaYAfQUcyjiPHhFVVUay3wxjD1lqvtNZsjAmaZ0eyLKvGWrfXhqK4YxienokwYI5OAAAoyxJ9PwjRTSZYABCIjuOu53l+7Tdd9+CmqckziCWo60bwaZpSCSScc4IrpYTOMyACKLEwIqQNPrK4wylpFmtcMvi2xpAuOELqD84JAmsk5Lm6moDRtjr9/L/xBhR/dxOXZyszAAAAAElFTkSuQmCC"; 

        #region 菜单导航
        public static string GetMenuStr(long userID)
        {
            StringBuilder str = new StringBuilder();
            XCLShouCang.BLL.WebType bll = new XCLShouCang.BLL.WebType();
            XCLShouCang.Model.WebType rootModel = bll.GetRootModel(userID);
            if (null == rootModel)
            {
                throw new Exception(string.Format("用户{0}的根类型不存在！", userID));
            }
            str.Append(@"<ul class=""nav navbar-nav"">");
            List<XCLShouCang.Model.WebType> lst = bll.GetListByUserIDAndParentID(userID, rootModel.WebTypeID);
            if (null != lst && lst.Count > 0)
            {
                foreach (var m in lst)
                {
                    if (bll.IsExistParentID(m.WebTypeID))
                    {
                        str.AppendFormat(@"<li class=""dropdown""><a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"">{0} <span class=""caret""></span></a>", m.TypeName);
                    }
                    else
                    {
                        str.AppendFormat(@"<li><a href=""#"">{0}</a>", m.TypeName);
                    }
                    GetChildMenuStr(userID, m.WebTypeID, str);
                    str.Append("</li>");
                }
            }
            str.Append("</ul>");
            return str.ToString().Replace(@"<ul class=""dropdown-menu"" role=""menu""></ul>", "");
        }

        public static void GetChildMenuStr(long userID, long parentID, StringBuilder str)
        {
            XCLShouCang.BLL.WebType bll = new XCLShouCang.BLL.WebType();
            List<XCLShouCang.Model.WebType> lst = bll.GetListByUserIDAndParentID(userID, parentID);
            str.Append(@"<ul class=""dropdown-menu"" role=""menu"">");
            if (null != lst && lst.Count > 0)
            {
                foreach (var m in lst)
                {
                    str.AppendFormat(@"<li><a href=""#"">{0}</a>", m.TypeName);
                    StringBuilder strSub = new StringBuilder();
                    GetChildMenuStr(userID, m.WebTypeID, strSub);
                    str.Append(strSub.ToString());
                    str.Append("</li>");
                }
            }
            str.Append("</ul>");
        }
        #endregion


        #region 获取分类options的树
        public static string GetWebTypeOptionStr(long userID, long seletedValue)
        {
            StringBuilder str = new StringBuilder();
            XCLShouCang.BLL.WebType bll = new XCLShouCang.BLL.WebType();
            XCLShouCang.Model.WebType rootModel = bll.GetRootModel(userID);
            if (null == rootModel)
            {
                throw new Exception(string.Format("用户{0}的根类型不存在！", userID));
            }

            str.AppendFormat(@"<option value=""{0}"" {2}>{1}</option>", rootModel.WebTypeID, rootModel.TypeName, seletedValue == rootModel.WebTypeID ? " selected='selected' " : "");
            string strLine = "";
            Action<long> GetChildWebTypeOptionStr = null;
            GetChildWebTypeOptionStr = (parentID) =>
            {
                strLine += "----";
                List<XCLShouCang.Model.WebType> lst = bll.GetFolderListByUserIDAndParentID(userID, parentID);
                if (null != lst && lst.Count > 0)
                {
                    foreach (var m in lst)
                    {
                        str.AppendFormat(@"<option value=""{0}""  {3}>{1}{2}</option>", m.WebTypeID, strLine, m.TypeName, seletedValue == m.WebTypeID ? " selected='selected' " : "");
                        GetChildWebTypeOptionStr(m.WebTypeID);
                    }
                }
                strLine = strLine.Substring(4);
            };

            GetChildWebTypeOptionStr( rootModel.WebTypeID);
            return str.ToString();
        }
        #endregion
    }
}
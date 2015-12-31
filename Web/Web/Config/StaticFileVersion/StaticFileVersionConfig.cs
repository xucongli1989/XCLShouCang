using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Web.Config.StaticFileVersion
{
    public class StaticFileVersionConfig
    {
        public static List<StaticFileVersionConfigModel> StaticFileLst
        {
            get
            {
                List<StaticFileVersionConfigModel> lst = new List<StaticFileVersionConfigModel>();
                string configPath = HttpContext.Current.Server.MapPath("~/Config/StaticFileVersion/StaticFileVersionConfig.config");
                XmlNodeList nodeList = XCLNetTools.XML.XMLHelper.GetXmlNodeListByXpath(configPath, "//Root//File");
                if (null != nodeList && nodeList.Count > 0)
                {
                    StaticFileVersionConfigModel model = null;
                    foreach (XmlNode m in nodeList)
                    {
                        model = new StaticFileVersionConfigModel();
                        model.Name = (m.Attributes["Name"]).Value.Trim();
                        model.Type = (m.Attributes["Type"]).Value.Trim();
                        model.Src = (m.Attributes["Src"]).Value.Trim();
                        model.Attr = (m.Attributes["Attr"]).Value.Trim();
                        lst.Add(model);
                    }
                }
                return lst;
            }
        }

        /// <summary>
        /// 获取文件引用
        /// </summary>
        /// <param name="Type">类型</param>
        /// <param name="Name">名字</param>
        /// <returns></returns>
        public static string GetFileUrl(string Type, string Name)
        {
            string str = "";
            bool isFind = false;
            foreach (var m in StaticFileLst)
            {
                if (string.Equals(Type, m.Type, StringComparison.OrdinalIgnoreCase) && string.Equals(Name, m.Name, StringComparison.OrdinalIgnoreCase))
                {
                    string typeStr = "";
                    switch (m.Type.ToUpper())
                    { 
                        case "JS":
                            typeStr = @"<script src=""{0}"" type=""text/javascript""  {1}></script>";
                            break;
                        case "CSS":
                            typeStr = @"<link href=""{0}"" rel=""stylesheet"" type=""text/css""  {1}/>";
                            break;
                    }
                    str = string.Format(typeStr, ReplaceEntity(m.Src).Replace("~/",Common.CommonHelper.RootURL), ReplaceEntity(m.Attr));
                    isFind = true;
                    break;
                }
            }
            if (!isFind)
            {
                throw new Exception(string.Format("静态文件【type:{0}   name:{1}】未找到！",Type,Name));
            }
            return str;
        }

        private static string ReplaceEntity(string str)
        {
            return str.Replace("&amp;", "&").Replace("&quot;", "\"");
        }
    }

    public class StaticFileVersionConfigModel
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public string Src { get; set; }

        public string Attr { get; set; }
    }

}
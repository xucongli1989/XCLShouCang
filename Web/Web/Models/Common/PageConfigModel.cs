using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Common
{
    /// <summary>
    /// 界面基本配置信息
    /// </summary>
    public class PageConfigModel
    {
        public string QQAppID { get; set; }

        public string QQAppKey { get; set; }

        public string QQStateValue { get; set; }

        public string QQLoginRedirectURL { get; set; }

        public string WebMainURL { get; set; }

        public string UserName { get; set; }

        public bool IsLogOn { get; set; }

    }
}
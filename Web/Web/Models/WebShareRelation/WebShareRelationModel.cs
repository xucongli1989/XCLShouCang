using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.WebShareRelation
{
    /// <summary>
    /// 共享设置model
    /// </summary>
    public class WebShareRelationModel
    {
        public long WebTypeRootID { get; set; }

        public bool IsShare { get; set; }

        public string AccessPwd { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.WebType
{
    public class MyWebTypeShowModel
    {
        public long ParentID { get; set; }

        public List<XCLShouCang.Model.v_WebType> FolderList { get; set; }

        public List<XCLShouCang.Model.v_WebType> FileList { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.WebType
{
    public class WebTypeListModel
    {
        public long ParentWebTypeID { get; set; }

        public string WebTypeOptionStr { get; set; }

        public List<XCLShouCang.Model.v_WebType> WebTypeList { get; set; }

        public Web.Models.WebShareRelation.WebShareRelationModel WebShareRelationModel { get; set; }
    }
}
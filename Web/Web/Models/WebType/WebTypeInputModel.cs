using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.WebType
{
    public class WebTypeInputModel
    {
        public long ParentID { get; set; }

        public string UploadFileName { get; set; }

        public string WebTypeOptionStr { get; set; }

    }
}
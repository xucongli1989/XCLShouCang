using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.WebType
{
    public class WebTypeAddModel
    {
        public XCLShouCang.Model.WebType ParentModel { get; set; }

        public long WebTypeID { get; set; }

        public long ParentID { get; set; }

        [Required]
        public string TypeName { get; set; }

        public string TypeURL { get; set; }

        private string _icoURL = string.Empty;
        public string IcoURL
        {
            get
            {
                if (!string.IsNullOrEmpty(this._icoURL))
                {
                    this._icoURL = this._icoURL.Length > 1000 ? Web.Common.CommonHelper.DefaultIcoURL : this._icoURL;
                }
                return this._icoURL;
            }
            set
            {
                this._icoURL = value;
            }
        }

        public string TypeDescription { get; set; }

        public int IsFolder { get; set; }
    }
}
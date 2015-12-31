using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCLShouCang.Model.Custom
{
    [Serializable]
    public class WebTypeSearch
    {
        public long WebTypeID
        {
            get;
            set;
        }
        public string TypeName
        {
            get;
            set;
        }
        public string TypeURL
        {
            get;
            set;
        }
        public int IsFolder
        {
            get;
            set;
        }
        public long FK_UserID
        {
            get;
            set;
        }

        public string SearchVal
        {
            get
            {
                string url = this.TypeURL;
                if (this.IsFolder == 1)
                {
                    url = string.Format("{0}UserAdmin/MyHome?parentID={1}",XCLNetTools.StringHander.Common.RootURL,this.WebTypeID);
                }
                return string.Format(@"{{  ""WebTypeID"":""{0}"",""TypeURL"":""{1}"",""IsFolder"":""{2}"" }}",this.WebTypeID,url,this.IsFolder);
            }
        }
        public string SearchName
        {
            get { return this.IsFolder==1?this.TypeName: string.Format("{0}（{1}）",this.TypeName,this.TypeURL); }
        }
    }
}

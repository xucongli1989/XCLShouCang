using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCLShouCang.Model.Custom
{
    [Serializable]
    public class WebTypeSimple
    {
        public long WebTypeID
        {
            get;
            set;
        }
        public long ParentID
        {
            get;
            set;
        }
        public string TypeName
        {
            get;
            set;
        }
    }
}

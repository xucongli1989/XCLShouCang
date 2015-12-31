using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Filter
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MustLoginAttribute : Attribute
    {
        
    }
}

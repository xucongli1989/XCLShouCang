using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Login
{
    public class LogOnModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9_]{3,16}$")]
        public string UserName { get; set; }

        [Required]
        public string Pwd { get; set; }
    }
}

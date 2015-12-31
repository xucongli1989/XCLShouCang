using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.Models.Login
{
    public class RegisterModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9_]{3,16}$")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)")]
        public string Email { get; set; }

        [Required]
        public string Pwd { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Pwd")]
        public string ConfirmPwd { get; set; }
    }
}
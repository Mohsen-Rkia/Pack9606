using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebUi.Areas.Administrator.ViewModels
{
    public class ForLoginViewModels
    {
        [Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        public string Password { get; set; }
        public bool Rememberme { get; set; }
    }
}
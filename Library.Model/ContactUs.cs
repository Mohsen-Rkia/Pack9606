using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class ContactUs
    {
        public int Id { get; set; }
        [MaxLength(200, ErrorMessage = "ایمیل نباید بیش از 200 کاراکتر باشد"), Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        [Display(Name = "ایمیل *")]
        public string EmailAddress { get; set; }
        [MaxLength(50, ErrorMessage = "نام نباید بیش از 50 کاراکتر باشد"), Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        [Display(Name = "نام *")]
        public string Name { get; set; }
        [MaxLength(100, ErrorMessage = "عنوان نباید بیش از 100 کاراکتر باشد"), Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        [Display(Name = "عنوان")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        [Display(Name = "متن پیام")]
        public string MsgText { get; set; }
    }
}

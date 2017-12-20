using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.WebUi.Areas.Administrator.ViewModels
{
    public class AddCirculationViewModels
    {
        [Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        [Display(Name = "شماره کاربری")]
        public int MemberId { get; set; }
        [Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        [Display(Name = "شماره کتاب")]
        public int BookId { get; set; }
        [Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        [Display(Name = "تاریخ تحویل کتاب")]
        public DateTime Issue_Date { get; set; }
        [Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        [Display(Name = "تعداد روز اجاره کتاب")]
        public int Day_Number { get; set; }
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime Expire_Date { get; set; }


    }
}
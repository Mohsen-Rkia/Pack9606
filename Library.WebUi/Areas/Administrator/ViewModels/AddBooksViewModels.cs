using Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.WebUi.Areas.Administrator.ViewModels
{
    public class AddBooksViewModels
    {
        public int Id { get; set; }
        [MaxLength(200,ErrorMessage ="عنوان کتاب نباید بیش از 200 کاراکتر باشد"), Required(ErrorMessage ="این فیلد نباید خالی باشد")]
        [Display(Name ="عنوان کتاب *")]
        public string Title { get; set; }
        [Display(Name = "نام نویسنده *")]
        [MaxLength(200, ErrorMessage = "نام نویسنده نباید بیش از 200 کاراکتر باشد"), Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        public string Author { get; set; }
        [Display(Name = "ناشر *")]
        [MaxLength(200, ErrorMessage = "عنوان ناشر نباید بیش از 200 کاراکتر باشد"), Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        public string Publisher { get; set; }
        [Display(Name = "شماره دسته (حتما باید ایجاد شود) *")]
        [Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        public int CategoryId { get; set; }
        [Display(Name = "سال انتشار *")]
        [StringLength(4,MinimumLength = 4, ErrorMessage = "سال انتشار نباید بیش از 4 کاراکتر عددی باشد"), Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        public string EditionYear { get; set; }
        [Display(Name = "شماره سریال")]
        [MaxLength(50, ErrorMessage = "سال انتشار نباید بیش از 4 کاراکتر عددی باشد")]
        public string Series { get; set; }
        [Display(Name = "شماره تماس ناشر")]
        [RegularExpression(@"(\+98|0)?9\d{9}",ErrorMessage ="شماره تماس صحیح نمی باشد")]
        public string PublisherCallNumber { get; set; }
        [Display(Name = "تعداد صفحات کتاب")]
        public string NumberOfPage { get; set; }
        [Display(Name = "شماره ISBN")]
        public string Isbn { get; set; }
        [Display(Name ="توضیحات")]
        public string Notes { get; set; }
        [Display(Name = "وضعیت")]
        public Status Status { get; set; }
        [Display(Name = "تاریخ ثبت کتاب در سایت")]
        public DateTime? AddDate { get; set; }
        [Display(Name = "تصویر")]
        public HttpPostedFileBase CoverFile { get; set; }
    }
    public enum Status
    {
        [Display(Name ="موجود")]
        Available,
        [Display(Name = "ناموجود")]
        NotAvailable

    }
}
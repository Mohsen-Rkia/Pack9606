using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class RequestBook
    {
        public int Id { get; set; }
        [Display(Name = "شماره کاربری *")]
        public int MemberId { get; set; }
        [MaxLength(100, ErrorMessage = "عنوان کتاب نباید بیش از 100 کاراکتر باشد"), Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        [Display(Name = "عنوان کتاب *")]
        public string BookTitleRQ { get; set; }
        [MaxLength(50, ErrorMessage = "نام نویسنده نباید بیش از 50 کاراکتر باشد")]
        [Display(Name = "نام نویسنده *")]
        public string AuthorBookRQ { get; set; }
        [MaxLength(50, ErrorMessage = "نام ناشر نباید بیش از 50 کاراکتر باشد")]
        [Display(Name = "نام ناشر *")]
        public string PublisherBookRQ { get; set; }
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime? RequestDate { get; set; }
        [MaxLength(500, ErrorMessage = "توضیحات نباید بیش از 500 کاراکتر باشد")]
        [Display(Name = "توضیحات *")]
        public string Note { get; set; }
        public virtual Member Member { get; set; }
    }
}

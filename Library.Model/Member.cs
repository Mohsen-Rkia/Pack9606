using Library.Model.Toolsbox;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Member
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "نام نباید بیش از 50 کاراکتر باشد"), Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        [Display(Name = "نام *")]
        public string Name { get; set; }
        [Display(Name = "نام خانوادگی *")]
        [MaxLength(50, ErrorMessage = "نام خانوادگی نباید بیش از 50 کاراکتر باشد")]
        public string LastName { get; set; }
        [MaxLength(200, ErrorMessage = "ایمیل نباید بیش از 50 کاراکتر باشد"), Required(ErrorMessage = "این فیلد نباید خالی باشد"), Index(IsUnique =true)]
        [Display(Name = "ایمیل *")]
        public string Email { get; set; }
        [MaxLength(50, ErrorMessage = "نام کاربری نباید بیش از 50 کاراکتر باشد"), Required(ErrorMessage = "این فیلد نباید خالی باشد"), Index(IsUnique =true)]
        [Display(Name = "نام کاربری *")]
        public string UserName { get; set; }
        [NotMapped,ScaffoldColumn(true)]
        public string Password
        {
            get
            {
                return this.PasswordHash;
            }
            set
            {
                this.PasswordHash = UserHelper.CalculateMD5Hash(value);
            }
        }
        [MaxLength(100),ScaffoldColumn(false)]
        public string PasswordHash { get; set; }
        public virtual ICollection<Circulation> Circulation_I { get; set; }
        public virtual ICollection<RequestBook> Request_I { get; set; }
    }
}

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
        [MaxLength(50),Required]
        public string Name { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(100),Required, Index(IsUnique =true)]
        public string Email { get; set; }
        [MaxLength(50),Required, Index(IsUnique =true)]
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
        public List<Books> Book_I { get; set; }
        public List<Circulations> Circulation_I { get; set; }
    }
}

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
        [MaxLength(100)]
        public string PasswordHash { get; set; }
        public List<Books> Book_I { get; set; }
    }
}

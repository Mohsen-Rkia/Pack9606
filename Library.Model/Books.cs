using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Books
    {
        public int Id { get; set; }
        [MaxLength(200),Required]
        public string Title { get; set; }
        [MaxLength(100),Required]
        public string Author { get; set; }
        [MaxLength(100),Required]
        public string Publisher { get; set; }
        public Member Member_I { get; set; }
    }
}

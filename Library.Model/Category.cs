using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(50),Required]
        public string Category_Name { get; set; }
        public List<Books> Books_I { get; set; }
    }
}

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
        [Display(Name = "نام دسته *")]
        [MaxLength(50),Required]
        public string Name { get; set; }
        public int BookId { get; set; }
        public virtual ICollection<Book> Books_I { get; set; }
    }
}

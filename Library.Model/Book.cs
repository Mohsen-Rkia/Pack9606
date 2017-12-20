using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int CategoryId { get; set; }
        public string EditionYear { get; set; }
        public string Series { get; set; }
        public string PublisherCallNumber { get; set; }
        public string NumberOfPage { get; set; }
        public string Isbn { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public DateTime? AddDate { get; set; }
        public string Cover { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Circulation> Circulatin_I { get; set; }
        public virtual ICollection<Cover> Covers { get; set; }
    }
}

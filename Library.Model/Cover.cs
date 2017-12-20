using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Cover
    {
        public int Id { get; set; }
        public byte[] CoverData { get; set; }
        public string OriginalFileName { get; set; }
        public string MimeType { get; set; }
        public double CoverSize { get; set; }
        public virtual Book Book { get; set; }
        public int BookId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Circulations
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int BooksId { get; set; }
        public DateTime Issue_Date { get; set; }
        public DateTime Expire_Date { get; set; }
        public DateTime Return_Date { get; set; }
        public Member Member_I { get; set; }
        public List<Books> Books_I { get; set; }
    }
}

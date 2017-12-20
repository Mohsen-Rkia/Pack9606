namespace Library.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LibraryDBs : DbContext
    {
        public LibraryDBs()
            : base("LibraryDBs")
        {
           
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Circulation> Circulations { get; set; }
        public DbSet<Cover> Covers { get; set; }
        public DbSet<ContactUs> ContactUss { get; set; }
        public DbSet<RequestBook> RequestBooks { get; set; }

    }

    

}
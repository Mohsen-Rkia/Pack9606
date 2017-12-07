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
        public DbSet<Books> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Circulations> Circulations { get; set; }

    }

    

}
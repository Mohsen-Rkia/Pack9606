namespace Library.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Publisher = c.String(),
                        CategoryId = c.Int(nullable: false),
                        EditionYear = c.String(),
                        Series = c.String(),
                        PublisherCallNumber = c.String(),
                        NumberOfPage = c.String(),
                        Isbn = c.String(),
                        Notes = c.String(),
                        Status = c.String(),
                        AddDate = c.DateTime(),
                        Cover = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Circulations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        Issue_Date = c.DateTime(nullable: false),
                        Day_Number = c.Int(nullable: false),
                        Expire_Date = c.DateTime(),
                        Return_Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 200),
                        UserName = c.String(nullable: false, maxLength: 50),
                        PasswordHash = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.RequestBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        BookTitleRQ = c.String(nullable: false, maxLength: 100),
                        AuthorBookRQ = c.String(maxLength: 50),
                        PublisherBookRQ = c.String(maxLength: 50),
                        RequestDate = c.DateTime(),
                        Note = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoverData = c.Binary(),
                        OriginalFileName = c.String(),
                        MimeType = c.String(),
                        CoverSize = c.Double(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(nullable: false, maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 50),
                        Subject = c.String(nullable: false, maxLength: 100),
                        MsgText = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CirculationBooks",
                c => new
                    {
                        Circulation_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Circulation_Id, t.Book_Id })
                .ForeignKey("dbo.Circulations", t => t.Circulation_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Circulation_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Covers", "BookId", "dbo.Books");
            DropForeignKey("dbo.RequestBooks", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Circulations", "MemberId", "dbo.Members");
            DropForeignKey("dbo.CirculationBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.CirculationBooks", "Circulation_Id", "dbo.Circulations");
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropIndex("dbo.CirculationBooks", new[] { "Book_Id" });
            DropIndex("dbo.CirculationBooks", new[] { "Circulation_Id" });
            DropIndex("dbo.Covers", new[] { "BookId" });
            DropIndex("dbo.RequestBooks", new[] { "MemberId" });
            DropIndex("dbo.Members", new[] { "UserName" });
            DropIndex("dbo.Members", new[] { "Email" });
            DropIndex("dbo.Circulations", new[] { "MemberId" });
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropTable("dbo.CirculationBooks");
            DropTable("dbo.ContactUs");
            DropTable("dbo.Covers");
            DropTable("dbo.RequestBooks");
            DropTable("dbo.Members");
            DropTable("dbo.Circulations");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
        }
    }
}

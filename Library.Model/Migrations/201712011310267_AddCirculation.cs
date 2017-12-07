namespace Library.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCirculation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Circulations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        BooksId = c.Int(nullable: false),
                        Issue_Date = c.DateTime(nullable: false),
                        Expire_Date = c.DateTime(nullable: false),
                        Return_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.CirculationsBooks",
                c => new
                    {
                        Circulations_Id = c.Int(nullable: false),
                        Books_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Circulations_Id, t.Books_Id })
                .ForeignKey("dbo.Circulations", t => t.Circulations_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Books_Id, cascadeDelete: true)
                .Index(t => t.Circulations_Id)
                .Index(t => t.Books_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Circulations", "MemberId", "dbo.Members");
            DropForeignKey("dbo.CirculationsBooks", "Books_Id", "dbo.Books");
            DropForeignKey("dbo.CirculationsBooks", "Circulations_Id", "dbo.Circulations");
            DropIndex("dbo.CirculationsBooks", new[] { "Books_Id" });
            DropIndex("dbo.CirculationsBooks", new[] { "Circulations_Id" });
            DropIndex("dbo.Circulations", new[] { "MemberId" });
            DropTable("dbo.CirculationsBooks");
            DropTable("dbo.Circulations");
        }
    }
}

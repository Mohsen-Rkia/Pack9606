namespace Library.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Library4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category_Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryBooks",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Books_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Books_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Books_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Books_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryBooks", "Books_Id", "dbo.Books");
            DropForeignKey("dbo.CategoryBooks", "Category_Id", "dbo.Categories");
            DropIndex("dbo.CategoryBooks", new[] { "Books_Id" });
            DropIndex("dbo.CategoryBooks", new[] { "Category_Id" });
            DropTable("dbo.CategoryBooks");
            DropTable("dbo.Categories");
        }
    }
}

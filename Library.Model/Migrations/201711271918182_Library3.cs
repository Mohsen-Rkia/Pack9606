namespace Library.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Library3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Author = c.String(nullable: false, maxLength: 100),
                        Publisher = c.String(nullable: false, maxLength: 100),
                        Member_I_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Member_I_Id)
                .Index(t => t.Member_I_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Member_I_Id", "dbo.Members");
            DropIndex("dbo.Books", new[] { "Member_I_Id" });
            DropTable("dbo.Books");
        }
    }
}

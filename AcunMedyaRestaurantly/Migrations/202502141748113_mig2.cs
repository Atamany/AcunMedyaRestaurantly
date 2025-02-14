namespace AcunMedyaRestaurantly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_CategoryId1", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_CategoryId1" });
            DropColumn("dbo.Products", "Category_CategoryId");
            DropColumn("dbo.Products", "Category_CategoryId1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Category_CategoryId1", c => c.Int());
            AddColumn("dbo.Products", "Category_CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Category_CategoryId1");
            AddForeignKey("dbo.Products", "Category_CategoryId1", "dbo.Categories", "CategoryId");
        }
    }
}

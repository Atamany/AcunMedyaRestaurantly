namespace AcunMedyaRestaurantly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductCategoryID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            AddColumn("dbo.Products", "Category_CategoryId1", c => c.Int());
            AlterColumn("dbo.Products", "Category_CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Category_CategoryId1");
            AddForeignKey("dbo.Products", "Category_CategoryId1", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_CategoryId1", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_CategoryId1" });
            AlterColumn("dbo.Products", "Category_CategoryId", c => c.Int());
            DropColumn("dbo.Products", "Category_CategoryId1");
            CreateIndex("dbo.Products", "Category_CategoryId");
            AddForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}

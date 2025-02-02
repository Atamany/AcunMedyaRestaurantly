namespace AcunMedyaRestaurantly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Guncelleme : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Chefs", "Name", c => c.String());
            AlterColumn("dbo.Chefs", "Title", c => c.String());
            AlterColumn("dbo.Chefs", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Chefs", "ImageUrl", c => c.Int(nullable: false));
            AlterColumn("dbo.Chefs", "Title", c => c.Int(nullable: false));
            AlterColumn("dbo.Chefs", "Name", c => c.Int(nullable: false));
        }
    }
}

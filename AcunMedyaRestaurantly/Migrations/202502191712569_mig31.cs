namespace AcunMedyaRestaurantly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig31 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Time = c.DateTime(nullable: false),
                        Icon = c.String(),
                        IconColor = c.String(),
                        isRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notifications");
        }
    }
}

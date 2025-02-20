namespace AcunMedyaRestaurantly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Price = c.Byte(nullable: false),
                        Message1 = c.String(),
                        Message2 = c.String(),
                        Message3 = c.String(),
                        Message4 = c.String(),
                        Message5 = c.String(),
                    })
                .PrimaryKey(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}

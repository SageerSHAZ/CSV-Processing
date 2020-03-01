namespace Cars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Manufacturer = c.String(),
                        Name = c.String(),
                        Displacement = c.Double(nullable: false),
                        Cylinders = c.Int(nullable: false),
                        City = c.Int(nullable: false),
                        Highway = c.Int(nullable: false),
                        Combined = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cars");
        }
    }
}

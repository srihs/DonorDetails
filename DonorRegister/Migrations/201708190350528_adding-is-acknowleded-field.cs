namespace DonorRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingisacknowlededfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donations", "isAcknowleded", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donations", "isAcknowleded");
        }
    }
}

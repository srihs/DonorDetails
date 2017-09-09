namespace DonorRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingprefix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donors", "Prefix", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donors", "Prefix");
        }
    }
}

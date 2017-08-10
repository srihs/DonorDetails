namespace DonorRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class membership : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donations", "MembershipNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donations", "MembershipNo");
        }
    }
}

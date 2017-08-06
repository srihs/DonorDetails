namespace DonorRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donors", "MembershipNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donors", "MembershipNo", c => c.String());
        }
    }
}

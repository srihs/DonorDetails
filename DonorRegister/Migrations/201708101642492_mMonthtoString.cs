namespace DonorRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mMonthtoString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donations", "Month", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donations", "Month", c => c.Int(nullable: false));
        }
    }
}

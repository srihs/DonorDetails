namespace DonorRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Donors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        UserCrteated = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        Donor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Donors", t => t.Donor_Id)
                .Index(t => t.Donor_Id);
            
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MembershipNo = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        Initials = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        AddressLine3 = c.String(),
                        Telephone = c.String(),
                        MobileNo = c.String(),
                        Email = c.String(),
                        Facebook = c.String(),
                        IMO = c.String(),
                        Comments = c.String(),
                        UserCrteated = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donations", "Donor_Id", "dbo.Donors");
            DropIndex("dbo.Donations", new[] { "Donor_Id" });
            DropTable("dbo.Donors");
            DropTable("dbo.Donations");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace DonorRegister
{
    public class Donor : BaseClass
    {
        public int Id { get; set; }
        public string MembershipNo { get; set; }
        public DateTime? StartDate { get; set; }
        public string Initials { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Telephone { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string IMO { get; set; }
        public string Comments { get; set; }
        public virtual ICollection<Donation> DonationList { get; set; }

    }

    //public class Donation : BaseClass
    //{
    //    public Donor Donor { get; set; }
    //    public double Amount { get; set; }
    //    public int Month { get; set; }
    //    public int Year { get; set; }
    //}


    public class DonorDbContext : DbContext
    {
        public DonorDbContext()
            : base("DbConnection")
        {
        }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }

        
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorRegister
{
    public class Donation : BaseClass
    {
        public int Id { get; set; }
        public Donor Donor { get; set; }
        public double Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }

    //public class DonationDbContext : DbContext
    //{
    //    //public DonationDbContext()
    //    //    : base("DbConnection")
    //    //{
    //    //}
    //    public DbSet<Donation> Donations { get; set; }
    //}
}

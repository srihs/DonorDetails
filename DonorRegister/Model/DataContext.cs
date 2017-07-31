using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorRegister.Model
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DonorRegistery")
        { }

        public DbSet<Donor> Donor { get; set; }
    }
}

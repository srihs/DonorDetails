using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorRegister
{
    public class Donation : BaseClass
    {
        [Key]
        public int Id { get; set; }
        public int DonorId { get; set; }
        public double Amount { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public string MembershipNo { get; set; }
    }


}

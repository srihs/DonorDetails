using System;


namespace DonorRegister.Model
{
    public class Donor : BaseClass
    {
        public int Id { get; set; }
        public string MembershipNo { get; set; }
        public DateTime StartDate { get; set; }
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


    }
}

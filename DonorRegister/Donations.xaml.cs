using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DonorRegister
{
    /// <summary>
    /// Interaction logic for Donations.xaml
    /// </summary>
    public partial class Donations : MetroWindow
    {

        #region
        DonorDbContext dbContext;
        List<Donation> objDonorListDonation;
        Donor objDonor;

        #endregion
        public Donations()
        {
            InitializeComponent();
            dbContext = new DonorDbContext();

            try
            {
                List<Donor> objDonorList = dbContext.Donors.ToList<Donor>();
                objDonorListDonation = new List<Donation>();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                objDonor = new Donor();
                objDonor = dbContext.Donors.SingleOrDefault(donor=>donor.MembershipNo==txtMemberNo.Text);
                if (objDonor != null)
                {

                    Donation objDonation = new Donation();
                    objDonation.DonorId = objDonor.Id;
                    objDonation.Amount = Double.Parse(txtAmount.Text);
                    objDonation.Month = dtpDonationDate.SelectedDate.Value.Month;
                    objDonation.Year = dtpDonationDate.SelectedDate.Value.Year;
                    objDonation.DateCreated = System.DateTime.Now;

                    objDonorListDonation.Add(objDonation);

                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

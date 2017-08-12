using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
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
            dtpDonationDate.SelectedDate = System.DateTime.Now.Date;

            try
            {
                //List<Donor> objDonorList = dbContext.Donors.ToList<Donor>();
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
                if (objDonorListDonation != null)
                {
                    foreach (Donation donation in objDonorListDonation)
                    {
                        dbContext = new DonorDbContext();
                        dbContext.Donations.Add(donation);
                        dbContext.SaveChanges();
                    }

                    MessageBox.Show("Record saved", "Saved");
                    objDonorListDonation = null;
                    dgDonations.ItemsSource = null;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (objDonorListDonation == null)
                    objDonorListDonation = new List<Donation>();

                if (txtMemberNo.Text == string.Empty || txtAmount.Text == string.Empty)
                {
                    txtAmount.BorderBrush = Brushes.Red;
                    txtMemberNo.BorderBrush = Brushes.Red;
                    return;
                }
                objDonor = new Donor();
                objDonor = dbContext.Donors.SingleOrDefault(donor => donor.MembershipNo == txtMemberNo.Text);
                if (objDonor != null)
                {

                    Donation objDonation = new Donation();
                    objDonation.DonorId = objDonor.Id;
                    objDonation.Amount = Double.Parse(txtAmount.Text);
                    objDonation.Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dtpDonationDate.SelectedDate.Value.Month);
                    objDonation.Year = dtpDonationDate.SelectedDate.Value.Year;
                    objDonation.MembershipNo = objDonor.MembershipNo;
                    objDonation.DateCreated = System.DateTime.Now;
                    objDonorListDonation.Add(objDonation);
                    txtMemberNo.Clear();
                    txtAmount.Clear();
                }

                dgDonations.ItemsSource = objDonorListDonation;
                dgDonations.Items.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDgDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                objDonorListDonation.RemoveAt(dgDonations.SelectedIndex);
                dgDonations.ItemsSource = objDonorListDonation;
                dgDonations.Items.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

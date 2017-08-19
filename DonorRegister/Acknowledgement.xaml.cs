using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Acknowledgement.xaml
    /// </summary>
    public partial class Acknowledgement : MetroWindow
    {
        #region - Private Variables-
        DonorDbContext dbContext;
        List<Donation> objDonorListDonation;
        Donor objDonor;

        #endregion

        public Acknowledgement()
        {
            InitializeComponent();
            dbContext = new DonorDbContext();
            dtpDonationDate.SelectedDate = DateTime.Now;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (Donation objDonation in objDonorListDonation)
                {
                    dbContext.Donations.Attach(objDonation);
                    dbContext.Entry(objDonation).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();

                }

                MessageBox.Show("Record updated", "Saved");
                dgDonations.ItemsSource = null;
                rbNotSent.IsChecked = false;
                rbSent.IsChecked = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void cbSelect_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //setting search parameters
                string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dtpDonationDate.SelectedDate.Value.Month);
                int year = dtpDonationDate.SelectedDate.Value.Year;
                bool isAcknowledged = false;

                //checking for sent/not sent data
                if (rbSent.IsChecked == true)
                    isAcknowledged = true;
                if (rbNotSent.IsChecked == true)
                    isAcknowledged = false;


                //var donationList = null;
                var donationList = dbContext.Donations.Where(x => x.isAcknowleded == isAcknowledged && x.Month == month && x.Year == year);
                objDonorListDonation = donationList.ToList<Donation>();

                if (objDonorListDonation.Count <= 0)
                    MessageBox.Show("No records Found.");
                else
                    dgDonations.ItemsSource = objDonorListDonation;
                dgDonations.Items.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }



    }
}


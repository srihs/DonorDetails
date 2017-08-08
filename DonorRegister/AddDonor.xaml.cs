using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
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
using System.Linq.Expressions;

namespace DonorRegister
{
    /// <summary>
    /// Interaction logic for AddDonor.xaml
    /// </summary>
    public partial class AddDonor : MetroWindow
    {
        #region -Private Properties -
        DonorDbContext dbContext;
        Donor objDonor;
        #endregion


        public AddDonor()
        {
            InitializeComponent();
            LoadMemberNumber();
            txtFistName.BorderBrush = Brushes.Red;
            txtLastName.BorderBrush = Brushes.Red;
            txtAddressLine1.BorderBrush = Brushes.Red;
            dtpStartDate.SelectedDate = System.DateTime.Now.Date;


        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }


        private void LoadMemberNumber()
        {
            try
            {
                dbContext = new DonorDbContext();
                var query = from donors in dbContext.Donors
                            orderby donors.Id descending
                            select donors;

                var donor = query.First();
                int nextId = donor.Id + 1;

                txtMemberNo.Text = "BW00" + nextId.ToString();

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

                //Validate Data
                if (txtFistName.Text == string.Empty)
                {
                    txtFistName.BorderBrush = Brushes.Red;
                    return;

                }
                if (txtLastName.Text == string.Empty)
                {
                    txtLastName.BorderBrush = Brushes.Red;
                    return;

                }

                if (txtAddressLine1.Text == string.Empty)
                {
                    txtAddressLine1.BorderBrush = Brushes.Red;
                    return;
                }

                //creating the object to hold the data
                objDonor = new Donor();

                //assigning data to Donor's properties
                objDonor.StartDate = dtpStartDate.SelectedDate;
                objDonor.Initials = txtInitials.Text;
                objDonor.Name = txtFistName.Text;
                objDonor.Surname = txtLastName.Text;
                objDonor.AddressLine1 = txtAddressLine1.Text;
                objDonor.AddressLine2 = txtAddressLine2.Text;
                objDonor.AddressLine3 = txtAddressLine3.Text;
                objDonor.Telephone = txtTelephone.Text;
                objDonor.MobileNo = txtMobile.Text;
                objDonor.Email = txtEmail.Text;
                objDonor.Facebook = txtFacebook.Text;
                objDonor.IMO = txtIMo.Text;
                objDonor.Comments = txtComment.Text;
                objDonor.DateCreated = System.DateTime.Now;





                dbContext = new DonorDbContext();
                dbContext.Donors.Add(objDonor);
                dbContext.SaveChanges();
                MessageBox.Show("Record saved", "Saved");


                foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                {
                    tb.Clear();
                }
                LoadMemberNumber();
                dtpStartDate.SelectedDate = System.DateTime.Now.Date;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

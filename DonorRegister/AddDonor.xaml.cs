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
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //creating the object to hold the data
                objDonor = new Donor();

                //assigning data to Donor's properties
                objDonor.MembershipNo = txtMemberNo.Text;
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
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

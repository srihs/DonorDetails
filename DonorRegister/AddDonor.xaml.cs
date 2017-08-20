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
        bool editMode;
        #endregion

        #region -Private Methods-
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

        private void LoadDonor(Donor objDonor)
        {
            try
            {
                if (objDonor != null)
                {
                    //assigning data to Donor's properties
                    dtpStartDate.SelectedDate = objDonor.StartDate;
                    txtMemberNo.Text = objDonor.MembershipNo;
                    txtInitials.Text = objDonor.Initials;
                    txtFistName.Text = objDonor.Name;
                    txtLastName.Text = objDonor.Surname;
                    txtAddressLine1.Text = objDonor.AddressLine1;
                    txtAddressLine2.Text = objDonor.AddressLine2;
                    txtAddressLine3.Text = objDonor.AddressLine3;
                    txtTelephone.Text = objDonor.Telephone;
                    txtMobile.Text = objDonor.MobileNo;
                    txtEmail.Text = objDonor.Email;
                    txtFacebook.Text = objDonor.Facebook;
                    txtIMo.Text = objDonor.IMO;
                    txtComment.Text = objDonor.Comments;
                    objDonor.LastModified = System.DateTime.Now;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void LoadMemberNumber()
        {
            try
            {
                // querying the db to determine the last ID
                dbContext = new DonorDbContext();
                var query = from donors in dbContext.Donors
                            orderby donors.MembershipNo descending
                            select donors;

                var donor = query.First();
                string membershipNo = donor.MembershipNo.Replace("BW", "");

                //adding 1 to create the next membership Number
                int nextId = int.Parse(membershipNo) + 1;

                //setting sequnce to be 5 digits
                txtMemberNo.Text = "BW" + nextId.ToString("D5");
                dbContext = null;
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void ClearForm()
        {
            foreach (TextBox tb in FindVisualChildren<TextBox>(this))
            {
                tb.Clear();
            }
            LoadMemberNumber();
            dtpStartDate.SelectedDate = System.DateTime.Now.Date;
        }
        #endregion

        public AddDonor()
        {
            InitializeComponent();
            LoadMemberNumber();
            txtFistName.BorderBrush = Brushes.Red;
            txtLastName.BorderBrush = Brushes.Red;
            txtAddressLine1.BorderBrush = Brushes.Red;
            dtpStartDate.SelectedDate = System.DateTime.Now.Date;
            editMode = false;

        }

        public AddDonor(int Id)
        {
            editMode = true;
            InitializeComponent();
            txtFistName.BorderBrush = Brushes.Red;
            txtLastName.BorderBrush = Brushes.Red;
            txtAddressLine1.BorderBrush = Brushes.Red;
            dtpStartDate.SelectedDate = System.DateTime.Now.Date;
            if (editMode)
            {
                objDonor = new Donor();
                dbContext = new DonorDbContext();

                objDonor = dbContext.Donors.Find(Id);

                LoadDonor(objDonor);
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

                if (!editMode)
                {
                    //creating the object to hold the data.  this is only if the edit mode is set to false
                    objDonor = new Donor();
                    objDonor.DateCreated = System.DateTime.Now;
                }

                //assigning data to Donor's properties
                objDonor.StartDate = dtpStartDate.SelectedDate;
                objDonor.MembershipNo = txtMemberNo.Text;
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

                dbContext.Donors.Add(objDonor);
                if (!editMode)
                {
                    dbContext.SaveChanges();
                    MessageBox.Show("Record saved", "Saved");


                }
                else
                {
                    dbContext.Donors.Attach(objDonor);
                    dbContext.Entry(objDonor).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                    MessageBox.Show("Record updated", "Saved");

                }

                ClearForm();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // setting up the edit mode
                editMode = true;

                Search objSearch = new Search("ADD");
                objSearch.Show();
                this.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }
    }
}

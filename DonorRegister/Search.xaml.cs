using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : MetroWindow
    {
        #region -Private Properties-

        List<Donor> objDonorList;
        DonorDbContext dbContext;
        BackgroundWorker worker;
        bool hasParameters = false;
        string memebershipNo = string.Empty;
        string firstName = string.Empty;
        Donor objDonor;
        string formOperation;
        #endregion


        public Search()
        {
            InitializeComponent();
            dbContext = new DonorDbContext();
        }

        public Search(string operation)
        {
            InitializeComponent();
            dbContext = new DonorDbContext();
            formOperation = operation;
        }



        private void txtMemberNo_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                #region -Private Variables for the method-
                
                List<Donor> objSearchResultList = new List<Donor>();
                #endregion
                objDonorList = new List<Donor>();

                //if no text entered, retrive all parameters
                if (txtMemberNo.Text == string.Empty && txtFistName.Text == string.Empty)
                {
                    hasParameters = false;

                }

                if (txtMemberNo.Text != string.Empty)
                {
                    memebershipNo = txtMemberNo.Text;

                    hasParameters = true;
                }

                if (txtFistName.Text != string.Empty)
                {
                    hasParameters = true;
                    firstName = txtFistName.Text;


                }

                worker = new BackgroundWorker();
                worker.DoWork += (o, ea) =>
                {
                    objSearchResultList = GenerateSearchResults(hasParameters, memebershipNo, firstName);
                    //use the Dispatcher to delegate the listOfStrings collection back to the UI
                    Dispatcher.Invoke((Action)(() => dgSearchResults.ItemsSource = objSearchResultList));


                };

                worker.RunWorkerCompleted += (o, ea) =>
                {
                    //work has completed. you can now interact with the UI
                    busyIndicator.IsBusy = false;
                };
                //set the IsBusy before you start the thread
                busyIndicator.IsBusy = true;
                worker.RunWorkerAsync();

                //dgSearchResults.ItemsSource = objSearchResultList;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private List<Donor> GenerateSearchResults(bool hasParameters, string memebershipNo, string firstName)
        {

            if (!hasParameters)
                objDonorList = dbContext.Donors.ToList<Donor>();
            else
            {
                if (memebershipNo != string.Empty)
                {
                    var matches = from m in dbContext.Donors
                                  where m.MembershipNo.Contains(memebershipNo)
                                  select m;

                    objDonorList = matches.ToList<Donor>();
                }

                if (firstName != string.Empty)
                {
                    var matches = from m in dbContext.Donors
                                  where m.Name.Contains(firstName)
                                  select m;

                    objDonorList = matches.ToList<Donor>();
                }
            }



            return objDonorList;
        }

        private void btnDgSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                objDonor = new Donor();
                objDonor=  objDonorList[dgSearchResults.SelectedIndex];
                
                if(formOperation=="ADD")
                {
                    AddDonor objAddDonor = new AddDonor(objDonor.Id);
                    objAddDonor.Show();
                    this.Close();
                }


                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

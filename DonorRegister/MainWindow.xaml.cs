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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddDonor objAddDonor = new AddDonor();
                objAddDonor.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnDonation_Click(object sender, RoutedEventArgs e)
        {
            Donations objDonation = new Donations();
            objDonation.Show();
        }
    }
}

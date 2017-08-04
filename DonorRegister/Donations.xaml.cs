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
    /// Interaction logic for Donations.xaml
    /// </summary>
    public partial class Donations : MetroWindow
    {

        #region
        DonorDbContext dbContext;


        #endregion
        public Donations()
        {
            InitializeComponent();
            dbContext = new DonorDbContext();

            try
            {
                List<Donor> objDonorList = dbContext.Donors.ToList<Donor>();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

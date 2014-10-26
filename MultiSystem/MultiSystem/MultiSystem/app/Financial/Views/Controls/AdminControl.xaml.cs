using MultiSystem.app.Financial.Controllers.AdminController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultiSystem.app.Financial.Views.Controls
{
    /// <summary>
    /// Interaction logic for AdminControl.xaml
    /// </summary>
    public partial class AdminControl : UserControl
    {
        public AdminControl()
        {
            InitializeComponent();
            this.customizeWindow();
            tittleWelcomeAdminFinancial.Content = ("BIENVENIDO "+AdminSingleton.Singleton.getAdmin().nameAdmin + " " + AdminSingleton.Singleton.getAdmin().lastNameAdmin).ToUpper();
        }

        private void customizeWindow() 
        {
            if (AdminSingleton.Singleton.getAdmin().idTypeAdmin == 1)
            {
                optionsForSuperAdminFinancial.Visibility = Visibility.Visible;
            }
            else 
            {
                optionsForSuperAdminFinancial.Visibility = Visibility.Hidden;
            }
        }

        private void closeSessionFinancial(object sender, System.Windows.RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            Thread.Sleep(1000);
            System.Windows.Forms.Application.Restart();
        }
    }
}

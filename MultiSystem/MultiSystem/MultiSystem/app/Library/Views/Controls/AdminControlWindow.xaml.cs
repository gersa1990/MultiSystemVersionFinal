using MultiSystem.app.Core.System.Screen;
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

namespace MultiSystem.app.Library.Views.Controls
{
    /// <summary>
    /// Interaction logic for AdminControlWindow.xaml
    /// </summary>
    public partial class AdminControlWindow : UserControl
    {
         private Screener screen;

         public AdminControlWindow()
         {
            InitializeComponent();
            this.customizeWindow();
            screen = new Screener();
            this.Width = this.MinWidth = screen.fullWidth - 190;
            this.Height = this.MinHeight = screen.fullHeight - 130;
         }

        private void customizeWindow() 
        {
            if (AdminSingleton.Singleton.getAdmin().idTypeAdmin == 1)
            {
                optionsForSuperAdmin.Visibility = Visibility.Visible;
            }
            else 
            {
                optionsForSuperAdmin.Visibility = Visibility.Hidden;
            }

            tittleWelcomeAdminLibrary.Content = ("BIENVENIDO: " + AdminSingleton.Singleton.getAdmin().nameAdmin +" "+ AdminSingleton.Singleton.getAdmin().lastNameAdmin).ToUpper();

        }

        public void closeSession(object sender, System.Windows.RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            Thread.Sleep(1000);
            System.Windows.Forms.Application.Restart();
        }
    }
}

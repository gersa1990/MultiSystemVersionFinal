using MultiSystem.app.Financial.Controllers.AdminController;
using MultiSystem.app.Financial.views.Login;
using MultiSystem.app.Financial.Views.Main;
using MultiSystem.app.Library.Controllers;
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

namespace MultiSystem.app.Financial.Views.Controls
{
    /// <summary>
    /// Interaction logic for AdminGralWindowFinancial.xaml
    /// </summary>
    public partial class AdminGralWindowFinancial : Window
    {
        private LoginFinancial loginFinancial;
        private HomeFinancialView homeView;
        private AdminController controllerAdmin;

        public AdminGralWindowFinancial(LoginFinancial loginFinancial)
        {
            // TODO: Complete member initialization
            this.loginFinancial = loginFinancial;
            InitializeComponent();
            //controllerAdmin.
            //adminTurnFinancial.ItemsSource = 
        }

        private void setDataAdminFinancial(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.

            if (this.checkValidations()) 
            {
                Admin admin = AdminSingleton.Singleton.getAdmin();
                admin.nameAdmin = nameUserFinancial.Text;
                admin.lastNameAdmin = lastNameUserFinancial.Text;

                
            }

            

            //homeView = new HomeFinancialView(admin); List<Dictionary<string, string>>
            //homeView.Show();
        }

        private void closeWindowFinancial(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private bool checkValidations() 
        {
            String errors = "";
            bool isHandlered = true;

            if (nameUserFinancial.Text.Equals("")) 
            {
                isHandlered = false;
                errors += "\n Nombre es requerido. *";
            }
            if (lastNameUserFinancial.Text.Equals("")) 
            {
                isHandlered = false;
                errors += "\n Apellidos son requeridos. *";
            }

            return isHandlered;
        }
    }
}

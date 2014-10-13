using MultiSystem.app.Financial.Controllers.AdminController;
using MultiSystem.app.Financial.Controllers.TypesAdmin;
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
        //private AdminController controllerAdmin;
        private TypeOfAdminsController typeControllerAdmin;
        private MainWindow mainWindow;

        public AdminGralWindowFinancial(LoginFinancial loginFinancial, MainWindow mainWindow)
        {
            typeControllerAdmin = new TypeOfAdminsController();
            this.loginFinancial = loginFinancial;
            this.mainWindow = mainWindow;
            InitializeComponent();
            this.customizeWindow();
        }

        private void customizeWindow() 
        {
            adminTurnFinancial.ItemsSource = typeControllerAdmin.getTypesOfAdmin();
            adminTurnFinancial.SelectedIndex = 0;
        }

        private void setDataAdminFinancial(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.checkValidations()) 
            {
                Admin admin = AdminSingleton.Singleton.getAdmin();
                admin.nameAdmin = nameUserFinancial.Text;
                admin.lastNameAdmin = lastNameUserFinancial.Text;
                admin.idTypeAdmin = ((WorkItem)adminTurnFinancial.SelectedItem).Key;

                AdminSingleton.Singleton.saveAdmin(admin);
                List<Dictionary<string, string>> listAdminDict = new List<Dictionary<string, string>>();
                
                Dictionary<string, string> dictAux = new Dictionary<string, string>();
                dictAux.Add("idAdmin", admin.idAdmin+"");
                dictAux.Add("nameAdmin", admin.nameAdmin);
                dictAux.Add("lastNameAdmin", admin.lastNameAdmin);
                dictAux.Add("userAdmin", admin.userAdmin);
                dictAux.Add("passwordAdmin", admin.passwordAdmin);
                dictAux.Add("idTypeAdmin", admin.idTypeAdmin+"");
                listAdminDict.Add(dictAux);

                this.Close();
                homeView = new HomeFinancialView(listAdminDict);
                homeView.Show();

                loginFinancial.Close();
                mainWindow.Close();
            }
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

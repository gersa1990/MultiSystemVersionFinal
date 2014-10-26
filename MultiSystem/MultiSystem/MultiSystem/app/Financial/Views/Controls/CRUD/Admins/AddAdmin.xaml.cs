using MultiSystem.app.Financial.Controllers.AdminController;
using MultiSystem.app.Financial.Views.Controls.PrivateSection;
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

namespace MultiSystem.app.Financial.Views.Controls.PrivateAdminSection.CRUD
{
    /// <summary>
    /// Interaction logic for AddAdmin.xaml
    /// </summary>
    public partial class AddAdmin : Window
    {
        private AddAdminPrivateSection addAdminPrivateSection;
        //private List<WorkItem> listOfTypesAdmin = new List<WorkItem>();
        private AdminControllerFinancial controllerAdmin = new AdminControllerFinancial();

        public AddAdmin(AddAdminPrivateSection addAdminPrivateSection)
        {
            this.addAdminPrivateSection = addAdminPrivateSection;
            InitializeComponent();
            selectAdmin.ItemsSource = controllerAdmin.getAllTypesAdmin();
            selectAdmin.SelectedIndex = 0;
        }

        private void closeWindowAdmin(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private void addAdminToBD(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.checkValidations()) 
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("nameAdmin", nameAdmin.Text);
                parameters.Add("lastNameAdmin", lastNameAdmin.Text);
                parameters.Add("userAdmin", userAdmin.Text);
                parameters.Add("passwordAdmin",passAdmin.Text);
               // parameters.Add("turnAdmin",turnAdmin.Text);
                parameters.Add("idTypeAdmin", ((WorkItem)selectAdmin.SelectedItem).Key+"");

                int added = controllerAdmin.addAdmin(parameters);

                if (added != 0) 
                {
                    this.Close();
                    addAdminPrivateSection.customizeWindow();
                }
            }
        }

        private bool checkValidations() 
        {
            bool isHandlered = true;
            String errors = "";

            if (nameAdmin.Text.Equals("")) 
            {
                errors += "Nombre es requerido. ";
                isHandlered = false;
            }
            else if (lastNameAdmin.Text.Equals("")) 
            {
                errors += "\n Nombre es requerido. ";
                isHandlered = false;
            }
            else if (turnAdmin.Text.Equals("")) 
            {
                errors += "\n Turno es requerido. ";
                isHandlered = false;
            }
            else if (userAdmin.Text.Equals(""))
            {
                errors += "\n Usuario es requerido. ";
                isHandlered = false;
            }
            else if (passAdmin.Text.Equals(""))
            {
                errors += "\n Contraseña es requerida. ";
                isHandlered = false;
            }

            if (isHandlered)
            {
                return true;
            }
            else 
            {
                MessageBox.Show("Se produjeron los siguientes errores: \n"+errors);
            }

            return isHandlered;
        }
    }
}

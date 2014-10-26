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
    /// Interaction logic for EditAdmin.xaml
    /// </summary>
    public partial class EditAdmin : Window
    {
        private AddAdminPrivateSection addAdminPrivateSection;
        private Admin admin;
        private AdminControllerFinancial controllerAdmin;
        private List<WorkItem> listOfWorkItems = new List<WorkItem>();

        public EditAdmin(AddAdminPrivateSection addAdminPrivateSection, Admin admin)
        {
            // TODO: Complete member initialization
            this.addAdminPrivateSection = addAdminPrivateSection;
            this.admin = admin;
            InitializeComponent();
            controllerAdmin = new AdminControllerFinancial();
            listOfWorkItems = controllerAdmin.getAllTypesAdmin();
            selectAdminEditFinancial.ItemsSource = listOfWorkItems;

            this.cuztomizeWindow();
                
        }

        private void cuztomizeWindow() 
        {
            

            for (int i = 0; i < listOfWorkItems.Count; i++)
            {
                if (listOfWorkItems.ElementAt(i).Key == this.admin.idTypeAdmin)
                {
                    selectAdminEditFinancial.SelectedIndex = i;
                }
            }

            nameAdminEdit2.Text = this.admin.nameAdmin;
            lastNameAdminEdit2.Text = this.admin.lastNameAdmin;
            userAdminEdit2.Text = this.admin.userAdmin;
            passAdminEdit2.Text = this.admin.passwordAdmin;
            turnAdminEdit2.Text = this.admin.workingHours;
        }

        private void editAdminToBD(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.checkValidations()) 
            {
                Dictionary<string, string> setParameters = new Dictionary<string, string>();
                setParameters.Add("nameAdmin", '"'+nameAdminEdit2.Text+'"');
                setParameters.Add("lastNameAdmin", '"'+lastNameAdminEdit2.Text + '"');
                setParameters.Add("userAdmin",  '"'+userAdminEdit2.Text+'"' );
                setParameters.Add("passwordAdmin",   '"'+passAdminEdit2.Text +'"');
                setParameters.Add("idTypeAdmin", ((WorkItem)selectAdminEditFinancial.SelectedItem).Key + "");
               // setParameters.Add("turnAdmin", '"' + turnAdminEdit2.Text + '"');

                Dictionary<string, string> whereParameters = new Dictionary<string, string>();
                whereParameters.Add("idAdmin", this.admin.idAdmin+"");

                int adminUpdated = controllerAdmin.updateAdmin(setParameters, whereParameters);

                if(adminUpdated != 0)
                {
                    this.Close();
                    addAdminPrivateSection.customizeWindow();
                }
            }
        }

        private void closeWindowAdminEdit(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private bool checkValidations()
        {
            bool isHandlered = true;
            String errors = "";

            if (nameAdminEdit2.Text.Equals(""))
            {
                errors += "Nombre es requerido. ";
                isHandlered = false;
            }
            else if (lastNameAdminEdit2.Text.Equals(""))
            {
                errors += "\n Apellidos es requerido. ";
                isHandlered = false;
            }
            else if (turnAdminEdit2.Text.Equals(""))
            {
                errors += "\n Turno es requerido. ";
                isHandlered = false;
            }
            else if (userAdminEdit2.Text.Equals(""))
            {
                errors += "\n Usuario es requerido. ";
                isHandlered = false;
            }
            else if (passAdminEdit2.Text.Equals(""))
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
                MessageBox.Show("Se produjeron los siguientes errores: \n" + errors);
            }

            return isHandlered;
        }
    }
}

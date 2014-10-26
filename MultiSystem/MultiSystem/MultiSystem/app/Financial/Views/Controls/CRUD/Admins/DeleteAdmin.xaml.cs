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
    /// Interaction logic for DeleteAdmin.xaml
    /// </summary>
    public partial class DeleteAdmin : Window
    {
        private AddAdminPrivateSection addAdminPrivateSection;
        private Admin admin;
        private AdminControllerFinancial controllerAdmin;

        public DeleteAdmin(AddAdminPrivateSection addAdminPrivateSection, Admin admin)
        {
            // TODO: Complete member initialization
            this.addAdminPrivateSection = addAdminPrivateSection;
            this.admin = admin;
            controllerAdmin = new AdminControllerFinancial();
            InitializeComponent();
            adminnistratorToDeleteFinancial.Content = admin.nameAdmin + " " + admin.lastNameAdmin;
        }

        private void deleteAdmin(object sender, System.Windows.RoutedEventArgs e)
        {
            Dictionary<string, string> whereParameters = new Dictionary<string, string>();
            whereParameters.Add("idAdmin", this.admin.idAdmin+"");
            int deleted = controllerAdmin.deleteAdminFinancial(whereParameters);

            if (deleted != 0) 
            {
                this.Close();
                addAdminPrivateSection.customizeWindow();
            }
        }

        private void closeWindowDeleteAdmin(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

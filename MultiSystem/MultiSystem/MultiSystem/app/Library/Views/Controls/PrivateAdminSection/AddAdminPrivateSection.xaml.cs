using MultiSystem.app.Financial.Controllers.AdminController;
using MultiSystem.app.Library.Controllers;
using MultiSystem.app.Library.Views.Controls.PrivateAdminSection.CRUD;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultiSystem.app.Library.Views.Controls.PrivateAdminSection
{
    /// <summary>
    /// Interaction logic for AddAdminPrivateSection.xaml
    /// </summary>
    public partial class AddAdminPrivateSection : UserControl
    {
        public AdminController controllerAdmin;
        private List<Admin> listOfAdmins = new List<Admin>();
        private Admin adminSelected = new Admin();

        public AddAdminPrivateSection()
        {
            controllerAdmin = new AdminController();
            InitializeComponent();
            this.customizeWindow();
        }

        public void customizeWindow() 
        {
            dataGridAdmins.ItemsSource = listOfAdmins = controllerAdmin.getAllAdmins();
            gridSelectedAdmins.Visibility = Visibility.Hidden;
        }

        private void deleteAdmins(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteAdmin adminEdit = new DeleteAdmin(this, (Admin)dataGridAdmins.SelectedItem);
            adminEdit.Show();
        }

        private void editAdmins(object sender, System.Windows.RoutedEventArgs e)
        {
            EditAdmin adminEdit = new EditAdmin(this, (Admin)dataGridAdmins.SelectedItem);
            adminEdit.Show();
        }


        private void OnAutoGeneratingColumnadmin(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor).DisplayName;

            List<string> hidenColumns = new List<string> { "idAdmin" , "idTypeAdmin" };

            if (hidenColumns.Contains(e.PropertyName, StringComparer.OrdinalIgnoreCase))
            {
                e.Column.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void selectRowAdmin(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int idSelected = 0;

            try
            {
                this.adminSelected = (Admin)dataGridAdmins.SelectedItem;
                idSelected = this.adminSelected.idAdmin;
            }
            catch (Exception exc)
            {
                idSelected = -1;
                Console.WriteLine("Exception: "+exc.ToString());
            }
            finally 
            {
                if (idSelected != -1) 
                {
                    this.adminSelected = (Admin)dataGridAdmins.SelectedItem;
                    gridSelectedAdmins.Visibility = Visibility.Visible;
                }
            }
        }

        private void addAdmin(object sender, System.Windows.RoutedEventArgs e)
        {
            AddAdmin adminAdd = new AddAdmin(this);
            adminAdd.Show();
        }
    }
}

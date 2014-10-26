using MultiSystem.app.Financial.Controllers.AdminController;
using MultiSystem.app.Financial.Views.Controls.PrivateAdminSection.CRUD;
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

namespace MultiSystem.app.Financial.Views.Controls.PrivateSection
{
    /// <summary>
    /// Interaction logic for AddAdminPrivateSection.xaml
    /// </summary>
    public partial class AddAdminPrivateSection : UserControl
    {
        private AdminControllerFinancial adminController;
        List<Admin> listOfAdminsFinancial;
        private Admin adminSelected;
        public AddAdminPrivateSection()
        {
            adminController = new AdminControllerFinancial();
            InitializeComponent();
            this.customizeWindow();
        }

        public void customizeWindow()
        {
            listOfAdminsFinancial = adminController.getAllAdmins();
            dataGridAdminsFinancial.ItemsSource = listOfAdminsFinancial;
            this.selectRowAdminFinancia(null,null);
        }

        private void OnAutoGeneratingColumnFinancialAdmin(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor).DisplayName;

            List<string> hidenColumns = new List<string> { "idAdmin", "idTypeAdmin" };

            if (hidenColumns.Contains(e.PropertyName, StringComparer.OrdinalIgnoreCase))
            {
                e.Column.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void deleteAdminsFinancial(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteAdmin adminEdit = new DeleteAdmin(this, (Admin)dataGridAdminsFinancial.SelectedItem);
            adminEdit.Show();
        }

        private void editAdminsFinancial(object sender, System.Windows.RoutedEventArgs e)
        {
            EditAdmin adminEdit = new EditAdmin(this, (Admin)dataGridAdminsFinancial.SelectedItem);
            adminEdit.Show();
        }

        private void addAdminFinancial(object sender, System.Windows.RoutedEventArgs e)
        {
            AddAdmin adminAdd = new AddAdmin(this);
            adminAdd.Show();
        }

        private void selectRowAdminFinancia(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int idSelected = 0;

            try
            {
                this.adminSelected = (Admin)dataGridAdminsFinancial.SelectedItem;
                idSelected = this.adminSelected.idAdmin;
            }
            catch (Exception exc)
            {
                idSelected = -1;
                Console.WriteLine("Exception: " + exc.ToString());
            }
            finally
            {
                if (idSelected != -1)
                {
                    this.adminSelected = (Admin)dataGridAdminsFinancial.SelectedItem;
                    gridSelectedAdminsFinancial.Visibility = Visibility.Visible;
                }
                else 
                {
                    gridSelectedAdminsFinancial.Visibility = Visibility.Hidden;
                }
            }
        }

        
    }
}

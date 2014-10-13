using MultiSystem.app.Core.System.Screen;
using MultiSystem.app.Financial.Controllers;
using MultiSystem.app.Financial.Views.Controls.ServicesCRUD;
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

namespace MultiSystem.app.Financial.Views.Controls
{
    /// <summary>
    /// Interaction logic for EditService.xaml
    /// </summary>
    public partial class EditService : UserControl
    {
        private ServicesFinancialController servicesController;
        private List<Service> listOfServices = new List<Service>();
        private Screener screen;
        public EditService()
        {
            servicesController = new ServicesFinancialController();
            InitializeComponent();
            screen = new Screener();
            this.Width = this.MinWidth = screen.fullWidth - 190;
            this.Height = this.MinHeight = screen.fullHeight - 130;
            this.performanceServicesDB();
        }

        public void performanceServicesDB() 
        {
            
            listOfServices = servicesController.getAllServices();
            dataServices.ItemsSource = listOfServices;
        }

        private void selectRow(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;

            try
            {
                Service service = ((Service)dataServices.SelectedItem);

                if (service.idService != 0)
                {
                    EditServiceAction editActionService = new EditServiceAction(this, service);
                    editActionService.Show();
                }
            }
            catch
            {
                
            }
        }

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor).DisplayName;

            List<string> hidenColumns = new List<string> { "idServiceData" };

            if (hidenColumns.Contains(e.PropertyName, StringComparer.OrdinalIgnoreCase))
            {
                e.Column.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void searchServiceField(object sender, KeyEventArgs e)
        {
            this.performanceServicesDB();
            string token = searchService.Text;

            var results = from Service service in listOfServices
                          where service.descriptionPrice.ToLower().Contains(token.ToLower()) || 
                                service.keyPrice.ToLower().Contains(token.ToLower())
                          select service;

            dataServices.ItemsSource = results;
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MultiSystem.app.Core.System.Screen;
using MultiSystem.app.Financial.Controllers;
using System.ComponentModel;
using MultiSystem.app.Library.Views.PopUp;
using MultiSystem.app.Financial.Controllers.BillingController;
using MultiSystem.app.Financial.Views.ModalView;

namespace MultiSystem.app.Financial.Views.Controls
{
    /// <summary>
    /// Interaction logic for RegisterService.xaml
    /// </summary>
    public partial class RegisterService : UserControl
    {
		private Screener screen;
        private ServicesFinancialController controllerFinancial;
        private List<Service> listOfServices;
		
        public RegisterService()
        {
			
            controllerFinancial = new ServicesFinancialController();
            listOfServices = new List<Service>();

            screen = new Screener();
            this.Width = this.MinWidth = screen.fullWidth - 190;
            this.Height = this.MinHeight = screen.fullHeight - 130;
            InitializeComponent();
            this.getServicesAsyncronus();
            this.showServicesAdded();
        }

        private void getServicesAsyncronus() 
        {
            listOfServices = controllerFinancial.getAllServices();
            dataServicesFounded.ItemsSource = listOfServices;
        }
		
		private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor).DisplayName;

            List<string> hidenColumns = new List<string> { "idService", "reasonDiscount" };

            if (hidenColumns.Contains(e.PropertyName, StringComparer.OrdinalIgnoreCase))
            {
                e.Column.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void searchServiceAction(object sender, System.Windows.Input.KeyEventArgs e)
        {

            this.getServicesAsyncronus();

        	string token = searchServiceField.Text;

            var results = from Service bill in listOfServices
                          
                          where bill.keyPrice.ToLower().Contains(token.ToLower()) || 
                                bill.descriptionPrice.ToLower().Contains(token.ToLower())

                          select bill;

            dataServicesFounded.ItemsSource = results;
        }

        private void addService(object sender, System.Windows.RoutedEventArgs e)
        {
        	
        }
		
		private void showPricesByRow()
		{
			Service service = ((Service)dataServicesFounded.SelectedItem);

            ModalViewHandler handlerView = new ModalViewHandler(this, service, typeOfModalView.add);
            handlerView.executeModal();
		}

        private void selectedRow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	this.showPricesByRow();
        }

        public void showServicesAdded() 
        {
            servicesAddedByPatient.ItemsSource = null;
            servicesAddedByPatient.ItemsSource = BillSingleton.Singleton.getBills();
			
			if(BillSingleton.Singleton.getBills().Count <= 0)
			{
				servicesAdded.Visibility = Visibility.Hidden;
                buttonNext.IsEnabled = false;
				
			}
			else
			{
				servicesAdded.Visibility = Visibility.Visible;
                buttonNext.IsEnabled = true;
			}
        }

        public void responseDelegateModalAdd(Bill bill)
        {
            BillSingleton.Singleton.addBill(bill);
            this.showServicesAdded();
        }

        private void selectRowForOptions(object sender, MouseButtonEventArgs e)
        {
            Bill service = ((Bill)servicesAddedByPatient.SelectedItem);
            ModalViewOptions modalOptions = new ModalViewOptions(this,service);
            modalOptions.Show();
        }

        public void performanceEditService(Bill bill)
        {
            BillSingleton.Singleton.editBill(bill);
            this.showServicesAdded();
        }

        public void performanceDeleteService(Bill bill)
        {
            BillSingleton.Singleton.deleteBill(bill);
            this.showServicesAdded();
        }

        private void goToCreateBillUser(object sender, System.Windows.RoutedEventArgs e)
        {
            BillingUser billing = new BillingUser(this);
            billing.Show();
        }
    }
}

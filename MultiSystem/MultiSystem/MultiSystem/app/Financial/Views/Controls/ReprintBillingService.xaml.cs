using MultiSystem.app.Core.System.Screen;
using MultiSystem.app.Financial.Controllers;
using MultiSystem.app.Financial.Controllers.AdminController;
using MultiSystem.app.Financial.Controllers.BillingController;
using MultiSystem.app.Financial.Controllers.Receipt;
using MultiSystem.app.Library.Views.Controls;
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
    /// Interaction logic for ReprintBillingService.xaml
    /// </summary>
    public partial class ReprintBillingService : UserControl
    {
        private List<Patient> listOfBills;
        private BillingController billingController;
        private Screener screen;

        public ReprintBillingService()
        {
            InitializeComponent();
            listOfBills = new List<Patient>();
            billingController = new BillingController();
            this.performanceServicesProvided();
            this.selectedRowForOptions(null,null);
            screen = new Screener();
            this.Width = this.MinWidth = screen.fullWidth - 190;
            this.Height = this.MinHeight = screen.fullHeight - 130;
        }

        public void performanceServicesProvided() 
        {
            try
            {
                string auxDate = DateTime.Now.Year + "_" + DateTime.Now.ToString("MM") + "_" + DateTime.Now.ToString("dd");

                if (AdminSingleton.Singleton.getAdmin().idAdmin == 5 || AdminSingleton.Singleton.getAdmin().idAdmin == 6)
                {

                }
                else 
                {  
                    listOfBills = billingController.getAllPatientForAdmin(AdminSingleton.Singleton.getAdmin().idAdmin); //billingController.getAllPatient();

                    var results = from Patient patient in listOfBills
                              where patient.auxDate.Equals(auxDate)
                              select patient;

                    dataPatientsGrid.ItemsSource = results;
                }
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc);
                System.Console.WriteLine("Ocurrio algo: :( "+editService.ToString());
            }
        }

        private void searchServiceToReprint(object sender, KeyEventArgs e)
        {
            this.performanceServicesProvided();
            string token = serviceToReprint.Text;
            string auxDate = DateTime.Now.Year + "_" + DateTime.Now.ToString("MM") + "_" + DateTime.Now.ToString("dd");

            try 
            {
                var results = from Patient patient in listOfBills
                              where patient.namePatient.ToLower().Contains(token.ToLower()) && patient.auxDate.Equals(auxDate) ||
                                    patient.lastNamePatient.ToLower().Contains(token.ToLower()) && patient.auxDate.Equals(auxDate) ||
                                    patient.folioPatient.ToLower().Contains(token.ToLower()) && patient.auxDate.Equals(auxDate)
                              select patient;

                dataPatientsGrid.ItemsSource = results;
            }
            catch 
            {

            }
        }

        private void reprintServiceAction(object sender, RoutedEventArgs e)
        {
            Patient patient = ((Patient)dataPatientsGrid.SelectedItem);
            List<Bill> listOfBillForReprint = billingController.getBillsForPatientID(patient.idServiceData);

            Receipter receipter = new Receipter(listOfBillForReprint, patient);
            receipter.createReceipt().save();
        }

        private void deleteServiceAction(object sender, RoutedEventArgs e)
        {
            Patient patient = ((Patient)dataPatientsGrid.SelectedItem);
            int deleted = billingController.deleteBillngs(patient.idServiceData);

            if (deleted != 0) 
            {
                MessageBox.Show("Servicio eliminado con éxito.");
                this.performanceServicesProvided();
            }
        }

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor).DisplayName;

            List<string> hidenColumns = new List<string> { "idServiceData","auxDate" };

            if (hidenColumns.Contains(e.PropertyName, StringComparer.OrdinalIgnoreCase))
            {
                e.Column.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void editServiceAction(object sender, RoutedEventArgs e)
        {
            Patient patient = ((Patient)dataPatientsGrid.SelectedItem);
            List<Bill> listOfBillForReprint = billingController.getBillsForPatientID(patient.idServiceData);

            EditorServices editorServices = new EditorServices(patient, listOfBillForReprint, this);
            editorServices.Show();   
        }

        private void selectedRowForOptions(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;

            int idPatient = 0;

            try
            {
                idPatient = ((Patient)dataPatientsGrid.SelectedItem).idServiceData;
            }
            catch
            {
                idPatient = -1;
            }
            finally 
            {
                if (idPatient == -1)
                {
                    editService.IsEnabled = false;
                    deleteService.IsEnabled = false;
                    reprintService.IsEnabled = false;
                    cancelServiceBtn.IsEnabled = false;
                }
                else 
                {
                    editService.IsEnabled = true;
                    deleteService.IsEnabled = true;
                    reprintService.IsEnabled = true;
                    cancelServiceBtn.IsEnabled = true;
                }
            }
        }

        private void cancelService(object sender, System.Windows.RoutedEventArgs e)
        {
            Patient patient = ((Patient)dataPatientsGrid.SelectedItem);
            MessageBox.Show("idServiceData:  "+patient.folioPatient+" "+patient.auxDate);
        }
    }
}

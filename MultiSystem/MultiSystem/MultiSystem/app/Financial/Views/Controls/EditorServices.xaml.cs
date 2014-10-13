using MultiSystem.app.Core.System.Screen;
using MultiSystem.app.Financial.Controllers;
using MultiSystem.app.Financial.Controllers.BillingController;
using MultiSystem.app.Financial.View.ModalView;
using MultiSystem.app.Financial.Views.Controls;
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
using System.Windows.Shapes;

namespace MultiSystem.app.Library.Views.Controls
{
    /// <summary>
    /// Interaction logic for EditorServices.xaml
    /// </summary>
    public partial class EditorServices : Window
    {
        private Patient patient;
        private ReprintBillingService reprintBillingService;
        private List<Bill> listOfBillForReprint;
        private Screener screen;

        public EditorServices(Patient patient, List<Bill> listOfBillForReprint, ReprintBillingService reprintBillingService)
        {
            // TODO: Complete member initialization
            this.patient = patient;
            this.listOfBillForReprint = listOfBillForReprint;
            this.reprintBillingService = reprintBillingService;
            InitializeComponent();
            servicesInList.ItemsSource = this.listOfBillForReprint;
            screen = new Screener();
            this.Width = this.MinWidth = screen.fullWidth - 190;
            this.Height = this.MinHeight = screen.fullHeight - 130;
        }

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor).DisplayName;

            List<string> hidenColumns = new List<string> { "idServiceData","idProvided","idService" };

            if (hidenColumns.Contains(e.PropertyName, StringComparer.OrdinalIgnoreCase))
            {
                e.Column.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void customizeWindow() 
        {
            tittle.Content = ("SERVICIOS DE "+this.patient.namePatient+" "+this.patient.lastNamePatient).ToUpper();
        }

        private void selectRowForEdit(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;

            try
            {
               Bill  idPatient = ((Bill)servicesInList.SelectedItem);
               ModalEditView modalEdit = new ModalEditView(this, idPatient);
               modalEdit.Show();
            }
            catch
            {
                
            }
        }

        public void performanceEditService(Bill bill)
        {
            BillingController billingController = new BillingController();
           int updated = billingController.updateBilling(bill);

           
           
            if (updated != 0) 
            {
                MessageBox.Show("updating");
                listOfBillForReprint = billingController.getBillsForPatientID(patient.idServiceData);
                servicesInList.ItemsSource = this.listOfBillForReprint;
                //reprintBillingService.performanceServicesProvided();
            }
        }
    }
}

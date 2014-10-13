using MultiSystem.app.Core.System.Screen;
using MultiSystem.app.Financial.Controllers;
using MultiSystem.app.Financial.Controllers.BillingController;
using MultiSystem.app.Financial.Controllers.Receipt;
using System;
using System.Collections.Generic;
using System.Text;
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
	/// Interaction logic for BillingUser.xaml
	/// </summary>
	public partial class BillingUser : Window
	{
        private RegisterService registerService;
		private List<Bill> listOfBillsAdded;
        private Patient patient;
        private Screener screen;

        public BillingUser(RegisterService registerService)
        {
            this.InitializeComponent();

            screen = new Screener();
            this.Width = this.MinWidth = screen.fullWidth - 190;
            this.Height = this.MinHeight = screen.fullHeight - 130;
            listOfBillsAdded = new List<Bill>();
            listOfBillsAdded = BillSingleton.Singleton.getBills();

            listOfBills.ItemsSource = listOfBillsAdded;
            this.customizeWindow();
            this.registerService = registerService;
            patient = new Patient();
        }
		
		private void customizeWindow()
		{
			if(namePatient.Text.Equals("") || lastNamePatient.Text.Equals(""))
			{
				finishBilling.IsEnabled = false;
			}
			else
			{
				finishBilling.IsEnabled = true;
			}
		}

		private void finishBillingAndCreateWorkBook(object sender, System.Windows.RoutedEventArgs e)
		{
            patient.namePatient     = namePatient.Text;
            patient.lastNamePatient = lastNamePatient.Text;
            patient.adressPatient   = adressPatient.Text;
            patient.folioPatient    = folioPatient.Text; 
            

            BillingController billingController = new BillingController();
            if (billingController.createBilling(listOfBillsAdded, patient))
            {
                Receipter receipt = new Receipter(listOfBillsAdded, patient);
                receipt.createReceipt().save();
                BillSingleton.Singleton.deleteBills();
                this.registerService.showServicesAdded();
                this.Close();
            }
            else 
            {
                MessageBox.Show("Error al tratar de facturar este paciente.");
            }
		}

		private void writeName(object sender, System.Windows.Input.KeyEventArgs e)
		{
            if (namePatient.Text.Equals("") || lastNamePatient.Text.Equals("") || adressPatient.Text.Equals("") || folioPatient.Text.Equals(""))
			{
				finishBilling.IsEnabled = false;
			}
			else
			{
				finishBilling.IsEnabled = true;
			}
		}

		private void writeLastName(object sender, System.Windows.Input.KeyEventArgs e)
		{
            if (namePatient.Text.Equals("") || lastNamePatient.Text.Equals("") || adressPatient.Text.Equals("") || folioPatient.Text.Equals(""))
			{
				finishBilling.IsEnabled = false;
			}
			else
			{
				finishBilling.IsEnabled = true;
			}
		}

        private void writeAdress(object sender, KeyEventArgs e)
        {
            if (namePatient.Text.Equals("") || lastNamePatient.Text.Equals("") || adressPatient.Text.Equals("") || folioPatient.Text.Equals(""))
            {
                finishBilling.IsEnabled = false;
            }
            else
            {
                finishBilling.IsEnabled = true;
            }
        }

        private void writeFolio(object sender, KeyEventArgs e)
        {
            if (namePatient.Text.Equals("") || lastNamePatient.Text.Equals("") || adressPatient.Text.Equals("") || folioPatient.Text.Equals(""))
            {
                finishBilling.IsEnabled = false;
            }
            else
            {
                finishBilling.IsEnabled = true;
            }
        }
	}
}
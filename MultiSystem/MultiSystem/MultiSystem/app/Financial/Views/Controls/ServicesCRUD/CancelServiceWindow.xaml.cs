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

namespace MultiSystem.app.Financial.Views.Controls.ServicesCRUD
{
    /// <summary>
    /// Interaction logic for CancelServiceWindow.xaml
    /// </summary>
    public partial class CancelServiceWindow : Window
    {
        private ReprintBillingService reprintBillingService;
        private Controllers.Patient patient;

        public CancelServiceWindow(ReprintBillingService reprintBillingService, Controllers.Patient patient)
        {
            // TODO: Complete member initialization
            this.reprintBillingService = reprintBillingService;
            this.patient = patient;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void acceptReasonCancel(object sender, System.Windows.RoutedEventArgs e)
        {
            if (reasonCanceledService.Text.Equals(""))
            {
                MessageBox.Show("Debes capturar una razon para cancelar el servicio.");
            }
            else
            {
                reprintBillingService.cancelServiceBackGround(patient, reasonCanceledService.Text);
                this.Close();
            }
        }

        private void closeWindow(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

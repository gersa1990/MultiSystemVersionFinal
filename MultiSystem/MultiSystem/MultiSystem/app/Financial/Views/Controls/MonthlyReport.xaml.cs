using MultiSystem.app.Core.System.Screen;
using MultiSystem.app.Financial.Controllers;
using MultiSystem.app.Financial.Controllers.BillingController;
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

namespace MultiSystem.app.Financial.Views.Controls
{
    /// <summary>
    /// Interaction logic for MonthlyReport.xaml
    /// </summary>
    public partial class MonthlyReport : UserControl
    {
        private BillingController billingController;
        private List<Ticket> listOfBills;
        private Screener screen;

        public MonthlyReport()
        {
            InitializeComponent();

            billingController = new BillingController();
            listOfBills = new List<Ticket>();

            screen = new Screener();
            this.Width = this.MinWidth = screen.fullWidth - 190;
            this.Height = this.MinHeight = screen.fullHeight - 130;
        }

        private void generateReportMonthly(object sender, RoutedEventArgs e)
        {
            String strDateInitial = dateInitial.Text;
            String strDateFinal = dateFinal.Text;

            

            if (strDateFinal.Equals("") || strDateInitial.Equals(""))
            {
                MessageBox.Show("Debes seleccionar la fecha inicial y final para poder generar este reporte.");
            }
            else if(!strDateInitial.Equals("") && !strDateFinal.Equals(""))
            {
                try
                {
                    string[] serializedInitial = strDateInitial.Split('/');
                    strDateInitial = serializedInitial[2] + "-" + serializedInitial[1] + "-" + serializedInitial[0];

                    string[] serializedFinal = strDateFinal.Split('/');
                    strDateFinal = serializedFinal[2] + "-" + serializedFinal[1] + "-" + serializedFinal[0];

                    listOfBills = billingController.getBillingsForMonthlyReport(strDateInitial, strDateFinal);

                   // MessageBox.Show(listOfBills+" Contiene: "+listOfBills.Count()+" Elementos ");

                    CreatorReportByMonth reportMonthly = new CreatorReportByMonth(listOfBills);
                    reportMonthly.createReportByMonth().save();

                }
                catch
                {
                    MessageBox.Show("Error al tratar de obtener los registros del día.");
                }
            }
        }
    }
}

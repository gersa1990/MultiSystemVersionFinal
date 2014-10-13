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
using MultiSystem.app.Library.Controllers;
using System.Globalization;
using MultiSystem.app.Library.Views.Controls;

namespace MultiSystem.app.Library.Views.Options
{
    /// <summary>
    /// Interaction logic for RefundBookOptions.xaml
    /// </summary>
    public partial class RefundBookOptions : Window
    {
        private RefundBooks refundBooks;
        private LoanBook loanBook;
		private BookController controllerBook;
		private int typeOfRefund;

        public RefundBookOptions()
        {
            InitializeComponent();
        }

        public RefundBookOptions(RefundBooks refundBooks, LoanBook loanBook)
        {
            InitializeComponent();
            this.refundBooks = refundBooks;
            this.loanBook = loanBook;
			this.controllerBook = new BookController();
		
			this.customMessageRefundBook();
        }
		
		private void customMessageRefundBook()
		{
			if(this.loanBook.dateLoan != "0000-00-00")
			{
				this.typeOfRefund = 1;
				containerRefundBook.Text = "DEVOLUCIÓN DE LIBRO: 'PRÉSTAMO FORANEO'\n\n";
				
				IFormatProvider culture = new System.Globalization.CultureInfo("es-MX", true);
				DateTime dt2 = DateTime.Parse(this.loanBook.dateLoan, culture, System.Globalization.DateTimeStyles.AssumeLocal);		
				
				containerRefundBook.Text += "Fecha de prestamo: "+dt2.Day+" DE "+dt2.ToString("MMMM", new CultureInfo("es-MX")).ToUpper()+" DEL "+dt2.Year+" \n\n";
			}
			else
			{
				this.typeOfRefund = 2;
				containerRefundBook.Text = "DEVOLUCIÓN DE LIBRO: 'PRÉSTAMO MISMO DÍA'\n\n";
				
				IFormatProvider culture = new System.Globalization.CultureInfo("es-MX", true);
				DateTime dt2 = DateTime.Parse(this.loanBook.petitionDay, culture, System.Globalization.DateTimeStyles.AssumeLocal);
				DateTime hour = DateTime.Parse(this.loanBook.hourLoan);
				
				containerRefundBook.Text += "Fecha de prestamo: "+dt2.Day+" DE "+dt2.ToString("MMMM", new CultureInfo("es-MX")).ToUpper()+" DEL "+dt2.Year+" a las "+hour.ToString("hh:mm tt")+" \n\n";
			}
			
			containerRefundBook.Text += "Libro:  "+this.loanBook.nameBook.ToUpper()+"\n";
			containerRefundBook.Text += "Lector:  "+this.loanBook.nameReader.ToUpper()+"\n";
			containerRefundBook.Text += "ISBN del libro:  "+this.loanBook.ISBN.ToUpper()+"\n";
		}

        private void executeRefund(object sender, System.Windows.RoutedEventArgs e)
        {
			
        }

        private void executeRefunds(object sender, System.Windows.RoutedEventArgs e)
        {
        	Dictionary<string, string> parameters 		= new Dictionary<string, string>();
			Dictionary<string, string> whereParameters	= new Dictionary<string, string>();
			
			whereParameters.Add("idLoan",this.loanBook.idLoan+"");
			
        	if(typeOfRefund==1)
			{
				string dateTime = DateTime.Now.Year+"-"+DateTime.Now.ToString("MM",CultureInfo.InvariantCulture)+"-"+DateTime.Now.ToString("dd",CultureInfo.InvariantCulture);
				parameters.Add("dateDeliveryLoan","'"+dateTime+"'");
				string hourDelivery  = DateTime.Now.ToString("HH", CultureInfo.CreateSpecificCulture("hu-HU"))+":"+DateTime.Now.ToString("mm", CultureInfo.CreateSpecificCulture("hu-HU"));
				parameters.Add("hourDeliveryLoan","'"+hourDelivery+"'");
			}else
			{
				string dateTime = DateTime.Now.Year+"-"+DateTime.Now.ToString("MM",CultureInfo.InvariantCulture)+"-"+DateTime.Now.ToString("dd",CultureInfo.InvariantCulture);
				parameters.Add("dateDeliveryLoan","'"+dateTime+"'");
				string hourDelivery  = DateTime.Now.ToString("HH", CultureInfo.CreateSpecificCulture("hu-HU"))+":"+DateTime.Now.ToString("mm", CultureInfo.CreateSpecificCulture("hu-HU"));
				parameters.Add("hourDeliveryLoan","'"+hourDelivery+"'");
			}
			
			int updated = controllerBook.executeRefundBook(parameters, whereParameters);
			
			if(updated>0)
			{
				MessageBox.Show("Se registró con éxito la devolución");
				this.Close();
				this.refundBooks.performanceBooksInBackgorund();
			}else
			{
				MessageBox.Show("Error al actualizar");
			}
        }
    }
}

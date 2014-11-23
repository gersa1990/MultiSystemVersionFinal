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
using MultiSystem.app.Library.Controllers;
using MultiSystem.app.Core.System.Screen;
using MultiSystem.app.Library.Views.Options;

namespace MultiSystem.app.Library.Views.Controls
{
    /// <summary>
    /// Interaction logic for RefundBooks.xaml
    /// </summary>
    public partial class RefundBooks : UserControl
    {

        private BookController controllerBook;
        private List<LoanBook> booksList;
        private Screener screen;

        public RefundBooks()
        {
            InitializeComponent();
            controllerBook = new BookController();
            booksList = new List<LoanBook>();

            screen = new Screener();
            this.Width = this.MinWidth = screen.fullWidth - 190;
            this.Height = this.MinHeight = screen.fullHeight - 130;

            this.searchBookField(null, null);
            this.performanceBooksInBackgorund();
            this.selectRow(null,null);
        }

        private void searchBookField(object sender, KeyEventArgs e)
        {
			try
			{
				
				this.performanceBooksInBackgorund();
				
				if(booksList.Count>0)
				{
					var results = from LoanBook book in booksList
                          where book.nameBook.ToLower().Contains(searchBooksField.Text.ToLower()) ||
                          book.nameReader.ToLower().ToString().Contains(searchBooksField.Text.ToLower()) ||
                          book.hashLoan.ToLower().ToString().Contains(searchBooksField.Text.ToLower())
                          
                          select book;

            		dataResults.ItemsSource = results;
			
					if(BookSingletonController.Singleton.isModifiedLoan == true)
					{
						this.performanceBooksInBackgorund();
						BookSingletonController.Singleton.isModifiedLoan = false;
					}
				}else
				{
					//MessageBox.Show("Al parecer no existen prestamos registrados.");
				}
				
			}catch
			{
				//MessageBox.Show("Al parecer no existen prestamos registrados.");
			}
            
        }

        public void performanceBooksInBackgorund() 
        {
            try
            {
                booksList = controllerBook.getBorrowedBooks();
                dataResults.ItemsSource = booksList;
            }
            catch 
            {
               	dataResults.ItemsSource = null;
				booksList = null;
            }
        }

        private void OnAutoGeneratingColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor).DisplayName;

            List<string> hidenColumns = new List<string> { "hourDeliveryLoan", "idBook", "idLoan","dateDeliveryLoan","dateLoan"};

            if (hidenColumns.Contains(e.PropertyName, StringComparer.OrdinalIgnoreCase))
            {
                e.Column.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void refundBookAction(object sender, RoutedEventArgs e)
        {
            int idBook = 0;

            try
            {
                idBook = ((LoanBook)dataResults.SelectedItem).idBook;
            }
            catch
            {
                MessageBox.Show("Debes seleccionar un libro para la devolución.");
                idBook = -1;
            }
            finally
            {
               
            }

            if (idBook > 0)
            {
                RefundBookOptions refundAction = new RefundBookOptions(this, (LoanBook)dataResults.SelectedItem);
                refundAction.Show();
                buttonRefund.IsEnabled = false;
            }

           
        }

        private void selectRow(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;

            int idBook = 0;

            try
            {
                idBook = ((LoanBook)dataResults.SelectedItem).idBook;
                buttonRefund.IsEnabled = true;
            }
            catch 
            {
                buttonRefund.IsEnabled = false;
            }
            finally
            {

            }

           
        }
    }
}

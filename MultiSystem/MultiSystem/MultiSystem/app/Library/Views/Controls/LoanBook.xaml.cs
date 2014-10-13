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
using System.ComponentModel;
using MultiSystem.app.Library.Controllers;
using System.Globalization;
using MultiSystem.app.Core.System.Screen;
using MultiSystem.app.Library.Views.PopUp;

namespace MultiSystem.app.Library.Views.Controls
{
    /// <summary>
    /// Interaction logic for Loan.xaml
    /// </summary>
    /// 
    public partial class Loan : UserControl
    {
        private BookController controllerBook;
        private List<Book> listOfBooks;
        private string dateToDeliveryBook;
        private string today;
        private Screener screen;
        
        public Loan()
        {
            InitializeComponent();
            controllerBook = new BookController();
            screen = new Screener();
            this.Width = this.MinWidth = screen.fullWidth - 190;
            this.Height = this.MinHeight = screen.fullHeight - 130;
            
            listOfBooks = controllerBook.getAllBooks();
            this.search(null,null);

            this.takeBokkToHouse(null,null);
            this.setValuesToComboBox();
            this.determineDateToDeliveryBook();
            this.selectedRow(null,null);
        }

        private void performanceNewSourceDB() 
        {
            listOfBooks = null;
            listOfBooks = controllerBook.getAllBooks(); 
        }

        private void search(object sender, KeyEventArgs e)
        {
            this.performanceNewSourceDB();

            var results = from Book book in listOfBooks
                          where book.nameBook.ToLower().Contains(searchBooksField.Text.ToLower())
                          select book;

            dataResults.ItemsSource = results;
        }

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor).DisplayName;

            List<string> hidenColumns = new List<string> { "idBook", "idGenere" };

            if (hidenColumns.Contains(e.PropertyName, StringComparer.OrdinalIgnoreCase))
            {
                e.Column.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void selectedRow(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;

            if (grid == null){

                containerGrid.Visibility = Visibility.Hidden;
            }
            else{
                containerGrid.Visibility = Visibility.Visible;
            }
        }

        private void takeBokkToHouse(object sender, RoutedEventArgs e)
        {
            if (radioSelectLoanAndDelivery.IsChecked == true){

                dateDeliveryLabel.Visibility = Visibility.Visible;
                dateDeliveryText.Visibility = Visibility.Visible;
            }
            else{
                dateDeliveryLabel.Visibility = Visibility.Hidden;
                dateDeliveryText.Visibility = Visibility.Hidden;
            }
        }

        private void determineDateToDeliveryBook()
        {
            DateTime _today = DateTime.Now;
            this.today = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd");

            DateTime dateForButton = DateTime.Now.AddDays(+3);
            
            string dayOfWeek = dateForButton.ToString("dddd", new CultureInfo("es-MX")).ToUpper();
            string numberDay = dateForButton.Day.ToString();
            string month = dateForButton.ToString("MMMM", new CultureInfo("es-MX")).ToUpper();
            string year = dateForButton.Year.ToString();
            string resultDate = dayOfWeek+" "+numberDay+" DE "+month+", DEL "+year;

            dateDeliveryText.Content = resultDate;

            hourLoan.SelectedIndex = dateForButton.Hour-1;
            minLoan.SelectedIndex = dateForButton.Minute;

            this.dateToDeliveryBook = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.AddDays(+3).ToString("dd");
        }

        private void setValuesToComboBox() 
        {
            for (int i = 1; i <= 24; i++)   {   hourLoan.Items.Add(i);  }
            for (int i = 1; i <= 60; i++)   {   minLoan.Items.Add(i);   }
        }

        private void saveLoan(object sender, RoutedEventArgs e)
        {
            if (nameReaderBook.Text.Equals(""))
            {
                MessageBox.Show("Debes completar todos los campos");
            }
            else {
                Dictionary<string, string> loanBook = new Dictionary<string, string>();
                string hash = controllerBook.uniqid();

                loanBook.Add("idBook",((Book)dataResults.SelectedItem).idBook+"");
                loanBook.Add("hashLoan",hash);
				loanBook.Add("petitionDay",DateTime.Now.Year + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd"));
                loanBook.Add("nameReader",nameReaderBook.Text);

                string _hourLoan = "";
                

                if (int.Parse(hourLoan.Text) < 10) 
                {
                    _hourLoan = "0" + hourLoan.Text;
                }
                else{
                    _hourLoan = hourLoan.Text;
                }
                if (int.Parse(minLoan.Text) < 10)
                {
                    _hourLoan += ":0" + minLoan.Text+":00";
                }
                else {
                    _hourLoan += ":"+minLoan.Text+":00";
                }

                loanBook.Add("hourLoan", _hourLoan);
                loanBook.Add("hourDeliveryLoan","00:00:00");

                if (radioSelectLoanAndDelivery.IsChecked == true){

                    loanBook.Add("dateLoan", this.today);
                    loanBook.Add("dateDeliveryLoan", "0000-00-00");
                }
                else {

                    loanBook.Add("dateLoan", "0000-00-00");
                    loanBook.Add("dateDeliveryLoan", "0000-00-00");
                }

                int idInserted = controllerBook.addLoanBook(loanBook);
                if (radioSelectLoanAndDelivery.IsChecked == true)
                {
                    PopUpCustom popUp = new PopUpCustom();
                    popUp.setDataForAlert("Libro prestado", "Se registró el préstamo del libro '" + ((Book)dataResults.SelectedItem).nameBook + "'. \n\n Código del préstamo: " + hash + ".\n\n Recuerda que debes entregarlo el día '" + dateDeliveryText.Content + "' ", typeOfAlertEnum.alert);
                    popUp.Show();
					BookSingletonController.Singleton.isModifiedLoan = true;
					
                }
                else 
                {
                    PopUpCustom popUp = new PopUpCustom();
                    popUp.setDataForAlert("Libro prestado", "Se registró el préstamo del libro '" + ((Book)dataResults.SelectedItem).nameBook + "'. \n\n Código del préstamo: " + hash + ".\n\n Recuerda que debes entregarlo hoy.", typeOfAlertEnum.warning);
                    popUp.Show();
					
					BookSingletonController.Singleton.isModifiedLoan = true;
                }
             }
        }
    }
}

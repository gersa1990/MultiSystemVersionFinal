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
using MultiSystem.app.Library.Views.Options;
using MultiSystem.app.Core.System.Screen;

namespace MultiSystem.app.Library.Views.Controls
{
    /// <summary>
    /// Interaction logic for EditAndDeleteBook.xaml
    /// </summary>
    public partial class EditAndDeleteBook : UserControl
    {

        private BookController bookController;
        private List<Book> listOfBooks;
        private EditBookOptions viewOptions;
        private DeleteBookOptions deleteOptions;
        private Screener screen;
        
        public EditAndDeleteBook()
        {
            InitializeComponent();
            bookController = new BookController();

            screen = new Screener();
            this.Width = this.MinWidth = screen.fullWidth - 190;
            this.Height = this.MinHeight = screen.fullHeight - 130;
            
            this.setBooksDataGrid();
            this.selectedRow(null, null);
        }

        public void setBooksDataGrid()
        {
            listOfBooks = null;
            listOfBooks = bookController.getAllBooks();
            dataBooks.ItemsSource = listOfBooks;
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

        private void editBook(object sender, RoutedEventArgs e)
        {
            //int idBook = ((Book)dataBooks.SelectedItem).idBook;

            int idBook = 0;

            try
            {
                idBook = ((Book)dataBooks.SelectedItem).idBook;
            }
            catch
            {
                MessageBox.Show("Debes seleccionar un libro a eliminar.");
                idBook = -1;
            }
            finally
            {
                //idBook = 0;
            }

            if (idBook > 0)
            {
                Dictionary<string, string> id = new Dictionary<string, string>();
                id.Add("idBook", idBook + "");
                viewOptions = new EditBookOptions(this, id);
                viewOptions.Show();
            }
            

            

            buttonEdit.IsEnabled = false;
            buttonDelete.IsEnabled = false;
        }

        private void deleteBook(object sender, RoutedEventArgs e)
        {
            int idBook = 0;

            try 
            {
                idBook = ((Book)dataBooks.SelectedItem).idBook;
            }
            catch
            {
                MessageBox.Show("Debes seleccionar un libro a eliminar.");
                idBook = -1;
            }
            finally
            {
                
            }

           


            if (idBook > 0)
            {
                deleteOptions = new DeleteBookOptions(this, (Book)dataBooks.SelectedItem);
                deleteOptions.Show();
            }
    
            

            buttonEdit.IsEnabled = false;
            buttonDelete.IsEnabled = false;
        }

        private void searchBook(object sender, KeyEventArgs e)
        {
            this.performanceNewSourceDB();

            var results = from Book book in listOfBooks
                          where book.nameBook.ToLower().Contains(searchBooksField.Text.ToLower())
                          select book;

            dataBooks.ItemsSource = results;
        }

        private void performanceNewSourceDB()
        {
            listOfBooks = null;
            listOfBooks = bookController.getAllBooks();
            dataBooks.ItemsSource = listOfBooks;
        }
        private void addBook_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            editBook();
        }

        private int editBook() 
        {
            return 0;
        }
        private void selectedRow(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;

            int idBook = 0;

            try
            {
                idBook = ((Book)dataBooks.SelectedItem).idBook;
                buttonDelete.IsEnabled = true;
                buttonEdit.IsEnabled = true;
            }
            catch 
            {
                buttonDelete.IsEnabled = false;
                buttonEdit.IsEnabled = false;
            }
            finally
            {

            }
        }
    }
}

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
using MultiSystem.app.Library.Views.Controls;

namespace MultiSystem.app.Library.Views.Options
{
    /// <summary>
    /// Interaction logic for DeleteBookOptions.xaml
    /// </summary>
    public partial class DeleteBookOptions : Window
    {
        private int idBook;
        private EditAndDeleteBook editAndDeleteBook;
        private BookController controllerBook = new BookController();
        
        public DeleteBookOptions()
        {
            InitializeComponent();
        }

        public DeleteBookOptions(EditAndDeleteBook editAndDeleteBook, Book book)
        {
            InitializeComponent();
            this.editAndDeleteBook = editAndDeleteBook;
            this.idBook = book.idBook;
            containerText.Text = "" + book.nameBook + "\n\n  Del autor: " + book.author + "\n ";
        }
            

            
        private void deleteBook(object sender, RoutedEventArgs e)
        {
            int deleted  = controllerBook.deleteBook(this.idBook);

            if (deleted > 0)
            {
                MessageBox.Show("El libro se ah eliminado con éxito.");
                editAndDeleteBook.setBooksDataGrid();
                this.Close();
            }
            else 
            {
                MessageBox.Show("Ocurrió un error al tratar de eliminarlo.");
            }
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

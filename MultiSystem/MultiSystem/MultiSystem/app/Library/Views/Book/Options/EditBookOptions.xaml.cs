using MultiSystem.app.Library.Validators;
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

namespace MultiSystem.app.Library.Views.Options
{
    /// <summary>
    /// Interaction logic for EditBookOptions.xaml
    /// </summary>
    public partial class EditBookOptions : Window
    {
        private int _noOfErrorsOnScreen = 0;
        private GenereController bookController;
        private Controls.EditAndDeleteBook editAndDeleteBook;
        private Book book = new Book();
        private BookController controllerBook = new BookController();
        private Dictionary<string, string> parameters = new Dictionary<string,string>();
        private Dictionary<string, string> whereParameters = new Dictionary<string,string>();

        public EditBookOptions()
        {
            InitializeComponent();
            
            bookController = new GenereController();
            comboGenereBook.ItemsSource = bookController.getGeneresForWorkItem();
            
            comboGenereBook.DisplayMemberPath = "Value";
            comboGenereBook.SelectedValuePath = "Key";
            comboGenereBook.SelectedIndex = 0;
        }

        public EditBookOptions(Controls.EditAndDeleteBook editAndDeleteBook, Dictionary<string, string> id)
        {
            InitializeComponent();
          
            bookController = new GenereController();
            comboGenereBook.ItemsSource = bookController.getGeneresForWorkItem();
            comboGenereBook.DisplayMemberPath = "Value";
            comboGenereBook.SelectedValuePath = "Key";
            comboGenereBook.SelectedIndex = 0;

            this.editAndDeleteBook = editAndDeleteBook;
            book = controllerBook.getBookById(id);
            this.customizeWindow(book);
        }

        private void customizeWindow(Book book)
        {

            tittle.Text = "EDITAR LIBRO";

            ISBN.Text                       = book.ISBN;
            fieldNameBook.Text              = book.nameBook;
            fieldAuthorBook.Text            = book.author;
            fieldEditorialBook.Text         = book.editorial;
            fieldEditionBook.Text           = book.edition;
            fieldPagesBook.Text             = book.pages;
            try
            {
                comboGenereBook.SelectedIndex = book.idGenere;
            }
            catch 
            {
                comboGenereBook.SelectedIndex = 0;
            }

            whereParameters.Add("idBook",book.idBook+"");
        }

        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
        }

        public void editBook(object sender, RoutedEventArgs e)
        {
            bool canEdit = true;

            parameters.Add("nameBook", "'"+fieldNameBook.Text+"'");
            parameters.Add("author","'"+fieldAuthorBook.Text+"'");
            parameters.Add("editorial", "'"+fieldEditorialBook.Text+"'");
            parameters.Add("edition","'"+fieldEditionBook.Text+"'");
            parameters.Add("pages", fieldPagesBook.Text);
            parameters.Add("ISBN","'"+ISBN.Text+"'");
            parameters.Add("idGenere",  comboGenereBook.SelectedIndex+"");
            

            try
            {
                int.Parse( fieldPagesBook.Text);
            }
            catch
            {
                MessageBox.Show("El número de páginas debe ser numérico.");
                canEdit = false;
            }

            foreach(var item in parameters)
            {
                if(item.Value.Equals(""))
                {
                    canEdit = false;
                }
            }

           if(canEdit)
           {
              int edited = controllerBook.editBook(parameters, whereParameters);

              if (edited > 0)
              {
                  MessageBox.Show("Actualizado con exito");
                  editAndDeleteBook.setBooksDataGrid();
                  this.Close();
              }
              else 
              {
                  MessageBox.Show("Ocurrió un error al actualizar.");
              }
           }
        }

        private void returnToHome(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

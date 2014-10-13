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
using MultiSystem.app.Core.System.Screen;
using MultiSystem.app.Library.Validators;
using MultiSystem.app.Library.Controllers;
using System.Collections;


namespace MultiSystem.app.Library.Views.Controls
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
	/// 
    public partial class AddBook : UserControl
    {
		private ValidatorBook validator;
		private int _noOfErrorsOnScreen = 0;
		private GenereController controller;
        private Screener screen;
        private List<WorkItem> generesBook;
        private Dictionary<string, string> parameters;
        private BookController controllerBook;
        
		public AddBook()
        {
			InitializeComponent();
			
			screen = new Screener();
			validator = new ValidatorBook();
            this.Width = this.MinWidth = screen.fullWidth-190;
            this.Height = this.MinHeight = screen.fullHeight-130;
			controller = new GenereController();
			addBokkGrid.DataContext = validator;
            generesBook = new List<WorkItem>();

            this.setGeneresBook();
            
        }
		
		private void setGeneresBook()
		{
            comboGenereBook.ItemsSource = controller.getGeneresForWorkItem();
            comboGenereBook.SelectedIndex = 0;
		}
		
		private void validation_Error(object sender, ValidationErrorEventArgs e) {
			if (e.Action == ValidationErrorEventAction.Added)
				_noOfErrorsOnScreen++;
			else
				_noOfErrorsOnScreen--;
		}
	
		private void addBook_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
			e.CanExecute = _noOfErrorsOnScreen == 0;
			e.Handled = true;
		}
	
		private void addBook_Executed(object sender, ExecutedRoutedEventArgs e) {
            saveBook();
		}

        private void saveBook() 
        {
            parameters = new Dictionary<string, string>();
            parameters.Add("nameBook",fieldNameBook.Text);
            parameters.Add("author", fieldAuthorBook.Text);
            parameters.Add("editorial", fieldEditorialBook.Text);
            parameters.Add("edition", fieldEditionBook.Text);
			parameters.Add("ISBN", ISBN.Text);
			parameters.Add("idGenere",comboGenereBook.SelectedIndex+"");
            parameters.Add("pages",fieldPagesBook.Text);

            controllerBook = new BookController();

            int id = controllerBook.addBook(parameters);

            if (id >= 1) 
            {
                BookSingletonController.Singleton.isModifiedLoan = true;
                BookSingletonController.Singleton.isModifiedForActions = true;
                MessageBox.Show("ID insertado: " + id);
            }
            
        }
    }
}

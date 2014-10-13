using MultiSystem.app.Library.Controllers;
using MultiSystem.app.Library.Views.Controls.PrivateAdminSection.CRUD;
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

namespace MultiSystem.app.Library.Views.Controls.PrivateAdminSection
{
    /// <summary>
    /// Interaction logic for addCategoryPrivateSection.xaml
    /// </summary>
    public partial class addCategoryPrivateSection : UserControl
    {

        public List<GenereBook> categoryList;
        private GenereController categoryController;
        public GenereBook selectedGenere;
        private int categoryIDAux;

        public addCategoryPrivateSection()
        {
            categoryList = new List<GenereBook>();
            selectedGenere = new GenereBook();
            categoryController = new GenereController();
            InitializeComponent();
            this.customizeWindow();
        }

        public void customizeWindow()
        {
            categoryList = categoryController.getAllGeneres();
            dataGridCategorys.ItemsSource = categoryList;
            gridSelectedCategory.Visibility = Visibility.Hidden;
        }

        private void selectRow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                categoryIDAux = ((GenereBook)dataGridCategorys.SelectedItem).idGenereBook;
            }
            catch (Exception except) 
            {
                categoryIDAux = -1;
                Console.WriteLine("Exception: "+except.ToString());
            }
            finally 
            {
                if (categoryIDAux != -1) 
                {
                    selectedGenere = (GenereBook)dataGridCategorys.SelectedItem;
                    categoryIDAux = ((GenereBook)dataGridCategorys.SelectedItem).idGenereBook;
                }
            }

            if (categoryIDAux >= 1)
            {
                gridSelectedCategory.Visibility = Visibility.Visible;
            }
            else 
            {
                gridSelectedCategory.Visibility = Visibility.Hidden;
            }
        }

        private void OnAutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor).DisplayName;

            List<string> hidenColumns = new List<string> {"idGenereBook" };

            if (hidenColumns.Contains(e.PropertyName, StringComparer.OrdinalIgnoreCase))
            {
                e.Column.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void addCategory(object sender, System.Windows.RoutedEventArgs e)
        {
            AddCategory categoryAdd = new AddCategory(this);
            categoryAdd.Show();
        }

        private void deleteCategory(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteCategory categoryDelete = new DeleteCategory(this, selectedGenere);
            categoryDelete.Show();
        }

        private void editCategory(object sender, System.Windows.RoutedEventArgs e)
        {
            EditCategory categoryEdit = new EditCategory(this, selectedGenere);
            categoryEdit.Show();
        }
    }
}

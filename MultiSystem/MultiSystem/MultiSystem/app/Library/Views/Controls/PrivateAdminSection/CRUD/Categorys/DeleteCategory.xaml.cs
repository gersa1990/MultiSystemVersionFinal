using MultiSystem.app.Library.Controllers;
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

namespace MultiSystem.app.Library.Views.Controls.PrivateAdminSection.CRUD
{
    /// <summary>
    /// Interaction logic for DeleteCategory.xaml
    /// </summary>
    public partial class DeleteCategory : Window
    {
        private addCategoryPrivateSection addCategoryPrivateSection;
        private GenereBook selectedGenere;
        private GenereController controllerGenere;

        public DeleteCategory(addCategoryPrivateSection addCategoryPrivateSection, GenereBook selectedGenere)
        {
            // TODO: Complete member initialization
            this.addCategoryPrivateSection = addCategoryPrivateSection;
            this.selectedGenere = selectedGenere;
            controllerGenere = new GenereController();
            InitializeComponent();
            nameCategoryDelete.Content = this.selectedGenere.nameGenereBook;
        }

        private void deleteCategory(object sender, System.Windows.RoutedEventArgs e)
        {
            Dictionary<string, string> whereParameters = new Dictionary<string, string>();
            whereParameters.Add("idGenereBook", this.selectedGenere.idGenereBook+"");
            int deleted = controllerGenere.deleteGenere(whereParameters);

            if (deleted != 0) 
            {
                this.Close();
                this.addCategoryPrivateSection.customizeWindow();
            }
        }

        private void closeWindowDElete(object sender, System.Windows.RoutedEventArgs e)
        {
        	this.Close();
        }
    }
}

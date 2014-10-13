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
    /// Interaction logic for EditCategory.xaml
    /// </summary>
    public partial class EditCategory : Window
    {
        private GenereController controllerGenere;
        private addCategoryPrivateSection addCategoryPrivateSection;
        private GenereBook selectedGenere;

        public EditCategory(addCategoryPrivateSection addCategoryPrivateSection, GenereBook selectedGenere)
        {
            // TODO: Complete member initialization
            this.addCategoryPrivateSection = addCategoryPrivateSection;
            this.selectedGenere = selectedGenere;
            InitializeComponent();
            controllerGenere = new GenereController();
            this.customizeWindow();
        }

        private void customizeWindow() 
        {
            nameCategoryEdit2.Text = this.selectedGenere.nameGenereBook;
            descriptionCategoryEdit2.Text = this.selectedGenere.descriptionGenereBook;
        }

        private void editCategoryToDB(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.checkValidations()) 
            {
                Dictionary<string, string> setParameters = new Dictionary<string, string>();
                setParameters.Add("nameGenereBook", '"'+nameCategoryEdit2.Text+'"');
                setParameters.Add("descriptionGenereBook", '"'+descriptionCategoryEdit2.Text+'"');

                Dictionary<string, string> whereParameters = new Dictionary<string, string>();
                whereParameters.Add("idGenereBook", "" + this.selectedGenere.idGenereBook);

                int updated = controllerGenere.editGenere(setParameters, whereParameters);

                if (updated >= 1)
                {
                    this.addCategoryPrivateSection.customizeWindow();
                    this.Close();
                }
            }
        }

        private void closeWindowEdit(object sender, System.Windows.RoutedEventArgs e)
        {
        	this.Close();
        }

        private bool checkValidations()
        {
            if (nameCategoryEdit2.Text.Equals(""))
            {
                MessageBox.Show("Nombre de la categoria es requerido. *");
                return false;
            }
            else if (descriptionCategoryEdit2
                .Text.Equals(""))
            {
                MessageBox.Show("Descripción de la categoria es requerida. *");
                return false;
            }

            return true;
        }
    }
}

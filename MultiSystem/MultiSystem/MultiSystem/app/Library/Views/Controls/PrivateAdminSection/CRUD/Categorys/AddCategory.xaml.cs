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
    /// Interaction logic for AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        private GenereController controllerGenere;
        private addCategoryPrivateSection addCategoryPrivateSection;
 

        public AddCategory(addCategoryPrivateSection addCategoryPrivateSection)
        {
            controllerGenere = new GenereController();
            this.addCategoryPrivateSection = addCategoryPrivateSection;
            InitializeComponent();
        }

        private void closeWindow(object sender, System.Windows.RoutedEventArgs e)
        {
        	this.Close();
        }

        private void addCategoryToDB(object sender, System.Windows.RoutedEventArgs e)
        {

            if (this.checkValidations()) 
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("nameGenereBook", '"'+nameCategory.Text+'"');
                dict.Add("descriptionGenereBook", '"'+descriptionCategory.Text+'"');
                int added = controllerGenere.addGenere(dict);

                if (added >= 1) 
                {
                    this.addCategoryPrivateSection.customizeWindow();
                    this.Close();
                }
            }
            
        	// TODO: Add event handler implementation here.
        }

        private bool checkValidations() 
        {
            if (nameCategory.Text.Equals("")) 
            {
                MessageBox.Show("Nombre de la categoria es requerido. *");
                return false;
            }
            else if (descriptionCategory.Text.Equals("")) 
            {
                MessageBox.Show("Descripción de la categoria es requerida. *");
                return false;
            }

            return true;
        }
    }
}

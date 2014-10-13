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

namespace MultiSystem.app.Library.Views.Controls
{
    /// <summary>
    /// Interaction logic for AdministradorGeneral.xaml
    /// </summary>
    public partial class AdministradorGeneral : UserControl
    {
        private view.Login.LoginLibrary loginLibrary;

        public AdministradorGeneral()
        {
            InitializeComponent();
        }

        public AdministradorGeneral(view.Login.LoginLibrary loginLibrary)
        {
            // TODO: Complete member initialization
            this.loginLibrary = loginLibrary;
        }

        private void setDataAdminGral(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }
    }
}

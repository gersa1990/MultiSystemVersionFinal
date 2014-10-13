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
using System.Drawing;
using MultiSystem.app.Core.System.Screen;
using MultiSystem.app.Library.view.Login;
using MultiSystem.app.Library.Controllers;
using MultiSystem.app.Biblioteca.Views;
using MultiSystem.app.Financial.views.Login;
using MultiSystem.app.Financial.Controllers;
using MultiSystem.app.Financial.Controllers.AdminController;


namespace MultiSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Screener screen = new Screener();
        private LoginControllerFinancial admin;
        private AdminController controller = new AdminController();
        public List<Dictionary<string, string>> response { get; set; }

        public MainWindow()
        {
            this.InitializeComponent();
            this.Width = this.MinWidth = screen.fullWidth;
            this.Height = this.MinHeight = screen.fullHeight + 25;

            /* BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri("pack://application:,,,/MultiSystem;component/app/Resources/Info.png");
            img.EndInit();
            imageBtnLibrary.Source = img;*/

            //ONLY FOR TEST
            //this.loginLibraryDiscrete();
        }

        private void loginLibraryDiscrete()
        {
            controller.UserName = "adminLibrary";
            controller.PasswordName = "adminLibrary";
            this.response = controller.Login();

            Admin admin = new Admin();

            foreach (var item in this.response)
            {
                foreach (var field in item)
                {

                    switch (field.Key)
                    {
                        case "idAdmin":
                            admin.idAdmin = int.Parse(field.Value);
                            break;

                        case "userNameAdmin":
                            admin.userAdmin = field.Value;
                            break;

                        case "turnAdmin":
                            admin.workingHours = field.Value;
                            break;

                        case "passAdmin":
                            admin.passwordAdmin = field.Value;
                            break;

                        case "nameAdmin":
                            {
                                admin.nameAdmin = field.Value;
                            }
                            break;

                        case "lastNameAdmin":
                            {
                                admin.lastNameAdmin = field.Value;
                            }
                            break;

                        case "descriptionAdmin":
                            {
                                admin.typeAdmin = field.Value;
                            }
                            break;
                    }
                }

                AdminSingleton.Singleton.saveAdmin(admin);
            }

            LibraryHome home = new LibraryHome(this.response);
            home.Show();
            this.Close();
        }
        //ONLY FOR TEST
        private void loginDiscreteFinancial()
        {
            admin = new LoginControllerFinancial("angel123", "angelJornada1");
            admin.sessionIgniter();
            this.Close();
        }

        private void loginFinancial(object sender, System.Windows.RoutedEventArgs e)
        {
            LoginFinancial financialObj = new LoginFinancial(this);
            financialObj.Show();
        }

        private void loginLibrary(object sender, System.Windows.RoutedEventArgs e)
        {
            LoginLibrary login = new LoginLibrary();
            login.appendChild(this);
            login.Show();
        }

        private int test()
        {
            return 1;
        }
    }
}

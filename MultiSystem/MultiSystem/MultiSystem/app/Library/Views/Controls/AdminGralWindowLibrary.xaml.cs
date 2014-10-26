using MultiSystem.app.Biblioteca.Views;
using MultiSystem.app.Financial.Controllers.AdminController;
using MultiSystem.app.Library.view.Login;
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
using System.Windows.Shapes;

namespace MultiSystem.app.Library.Views.Controls
{
    /// <summary>
    /// Interaction logic for AdminGralWindowLibrary.xaml
    /// </summary>
    public partial class AdminGralWindowLibrary : Window
    {
        private view.Login.LoginLibrary loginLibrary;
        private MainWindow windowPrivate;
        private List<Dictionary<string, string>> list;

        public AdminGralWindowLibrary(MainWindow windowPrivate, List<Dictionary<string, string>> list)
        {
            this.InitializeComponent();
            // TODO: Complete member initialization
            this.windowPrivate = windowPrivate;
            this.list = list;

            List<string> data = new List<string>();
            data.Add("Matutino");
            data.Add("Vespertino");
            data.Add("Nocturno 1");
            data.Add("Nocturno 2");
            data.Add("Jornada Acumulada 1");
            data.Add("Jornada Acumulada 2");

            adminTurnGral2.ItemsSource = data;

            adminTurnGral2.SelectedIndex = 0;

        }

        private void customizaWindow ()
        {

        }

        private void setDataAdminGralLibrary(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.validationsFormComplete()) 
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                Admin admin = new Admin();
             
                foreach (var token in this.list)
                {
                    
                    foreach (var item in token)
                    {

                        switch(item.Key)
                        {
                            case "idAdmin":
                                dict.Add("idAdmin", item.Value);
                                admin.idAdmin = int.Parse(item.Value);
                            break;

                            case "nameAdmin":
                            dict.Add("nameAdmin", nameUSerGral2.Text);
                                admin.nameAdmin = nameUSerGral2.Text;
                            break;

                            case "lastNameAdmin":
                            dict.Add("lastNameAdmin",lastNameUserGral2.Text);
                            admin.lastNameAdmin = lastNameUserGral2.Text;
                            break;

                            case "userNameAdmin":
                            dict.Add("userNameAdmin",item.Value);
                            admin.userAdmin = item.Value;
                            break;

                            case "passAdmin":
                            dict.Add("passAdmin",item.Value);
                            admin.passwordAdmin = item.Value;
                            break;

                            case "typeAdmin":
                            dict.Add("typeAdmin", item.Value);
                            break;

                            case "turnAdmin":
                            dict.Add("turnAdmin",item.Value);
                            admin.workingHours = item.Value;
                            break;

                            case "idTypeAdmin":
                            dict.Add("idTypeAdmin",item.Value);
                            admin.idTypeAdmin = int.Parse(item.Value);
                            break;

                            case "descriptionAdmin":
                            dict.Add("descriptionAdmin",item.Value);
                            admin.typeAdmin = item.Value;
                            break;
                        }
                    }
                }
                AdminSingleton.Singleton.saveAdmin(admin);

                list = new List<Dictionary<string, string>>();
                list.Add(dict);

                LibraryHome home = new LibraryHome(list);
                home.Show();
                this.Close();
                windowPrivate.Close();
            }
        }

        private void closeWindow(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        public bool validationsFormComplete() 
        {
            if (nameUSerGral2.Text.Equals("")) 
            {
                MessageBox.Show("Usuario es requerido. *");
                return false;
            }
            else if (lastNameUserGral2.Text.Equals("")) 
            {
                MessageBox.Show("Apellidos son requeridos. *");
                return false;
            }

            return true;
        }
    }
}

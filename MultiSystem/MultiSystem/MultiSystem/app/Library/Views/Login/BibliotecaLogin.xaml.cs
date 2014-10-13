using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MultiSystem.app.Library.Controllers;
using System.Runtime.InteropServices;
using MultiSystem.app.Biblioteca.Views;
using MultiSystem.app.Library.Views.Controls;
using MultiSystem.app.Financial.Controllers.AdminController;

namespace MultiSystem.app.Library.view.Login
{
	/// <summary>
	/// 
	/// </summary>
	public partial class LoginLibrary : Window
	{
		public AdminController controller;
        private List<Dictionary<string, string>> response;
        private MainWindow windowPrivate;
		private bool isChecked;
		
        public LoginLibrary()
		{
			this.InitializeComponent();
			isChecked = false;
            this.seePassword();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="mainWindow"></param>
        public void appendChild(MainWindow mainWindow)
        {
            windowPrivate = mainWindow;
            
        }

        private void actionClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Window.messageLogin.Content = "";
            controller = new AdminController();

            
            controller.UserName = userNameBookStore.Text;
            controller.PasswordName = passWordNameBookStore.Password;

            //Console.WriteLine(controller.PasswordName.Length);

            if (!controller.UserName.Equals("") && controller.PasswordName.Length > 0)
            {
                String idTypeAdmin = "0";
 
                this.response = controller.Login();
                if (response == null)
                {
                    Window.messageLogin.Content = "Usuario o contraseña incorrectos.";
                }
                else
                {
                    Admin admin = new Admin();

                    foreach (var item in this.response)
                    {
                        foreach (var field in item)
                        {

                            switch (field.Key)
                            {
                                case "idTypeAdmin":
                                    idTypeAdmin = field.Value;
                                break;

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

                    if (idTypeAdmin == "100")
                    {
                        AdminGralWindowLibrary adminGral = new AdminGralWindowLibrary(windowPrivate, this.response);
                        adminGral.Show();
                        this.Close();
                    }
                    else 
                    {
                        Window.messageLogin.Content = "Bienvenido";
                        LibraryHome home = new LibraryHome(this.response);
                        home.Show();
                        this.Close();
                        windowPrivate.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Completa todos los campos requeridos.");
            }
        }

        public void handlerAdminGralBackGround() 
        {
            Window.messageLogin.Content = "Bienvenido";
            LibraryHome home = new LibraryHome(this.response);
            home.Show();
            this.Close();
            windowPrivate.Close();
        }

        private void returnToHome(object sender, System.Windows.RoutedEventArgs e)
        {
        	this.Close();
        }

        private void writePassword(object sender, System.Windows.Input.KeyEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            passWordNameBookStore.Password = passwordDesencrypted.Text;
        }

        private void writeEncryptedPassWord(object sender, System.Windows.Input.KeyEventArgs e)
        {
            passwordDesencrypted.Text = passWordNameBookStore.Password;
        }
		
		private void seePassword()
		{
			if(isChecked)
			{
                passwordDesencrypted.Visibility = Visibility.Visible;
                passWordNameBookStore.Visibility = Visibility.Hidden;
                passwordCheckLibrary.Content = "Ocultar";
			}
			else
			{
                passwordDesencrypted.Visibility = Visibility.Hidden;
                passWordNameBookStore.Visibility = Visibility.Visible;
                passwordCheckLibrary.Content = "Ver";
			}
		}

        private void checkOrUncheckHiddenPassWord(object sender, System.Windows.RoutedEventArgs e)
        {
			if(isChecked)
			{
				isChecked = false;
			}
			else
			{
				isChecked= true;
			}
				
        	this.seePassword();
        }
    }
}
using MultiSystem.app.Financial.Controllers;
using MultiSystem.app.Financial.Controllers.Login;
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

namespace MultiSystem.app.Financial.views.Login
{
	/// <summary>
	/// Interaction logic for LoginFinancial.xaml
	/// </summary>
	public partial class LoginFinancial : Window
	{
        public MainWindow home;
        public LoginControllerFinancial2_0 __controllerLogin;

        private string user;
        private string pass;

        public LoginFinancial(MainWindow mainWindow)
        {
            this.home = mainWindow;
            this.InitializeComponent();
            this.checkOrUncheckPassword(null,null);
        }

		private void sessionIgniter(object sender, System.Windows.RoutedEventArgs e)
		{
            this.user = userNameFinancial.Text;
            this.pass = passwordFinancialNew.Password;

            if (this.user.Equals("") || this.pass.Equals(""))
            {
                MessageBox.Show("Debes completar todos los campos");
            }
            else 
            {
                __controllerLogin = new LoginControllerFinancial2_0(this.user, this.pass);

                if (__controllerLogin.sessionIgniter(this))
                {
                    this.home.Close();
                    this.Close();
                }
            }
		}

		private void cancelAction(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Close();
		}

		private void writePassWordDesencrypted(object sender, System.Windows.Input.KeyEventArgs e)
		{
            passwordFinancialNew.Password = passWordDescencrypted_.Text;
		}

		private void writePasswordEncrypted(object sender, System.Windows.Input.KeyEventArgs e)
		{
            passWordDescencrypted_.Text = passwordFinancialNew.Password;
		}

		private void checkOrUncheckPassword(object sender, System.Windows.RoutedEventArgs e)
		{
            if (checkBoxSeePassword.IsChecked == true)
            {
                passWordDescencrypted_.Visibility = Visibility.Visible;
                passwordFinancialNew.Visibility = Visibility.Hidden;
            }
            else 
            {
                passWordDescencrypted_.Visibility = Visibility.Hidden;
                passwordFinancialNew.Visibility = Visibility.Visible;
            }
		}
	}
}
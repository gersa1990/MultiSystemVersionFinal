using MultiSystem.app.Financial.Controllers.AdminController;
using MultiSystem.app.Financial.Models.Login;
using MultiSystem.app.Financial.views.Login;
using MultiSystem.app.Financial.Views.Controls;
using MultiSystem.app.Financial.Views.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MultiSystem.app.Financial.Controllers.Login
{
    public class LoginControllerFinancial2_0
    {
        private     LoginFinancialModel loginFinancialModel;
        private     HomeFinancialView homeView;

        public string user { get; set; }
        public string pass { get; set; }

        public LoginControllerFinancial2_0(string user, string pass)
        {
            
            this.user = user;
            this.pass = pass;
        }



        public bool sessionIgniter(LoginFinancial loginFinancial, MainWindow mainWindow) 
        {
            if (!this.user.Equals("") && !this.pass.Equals("")) 
            {
                loginFinancialModel = new LoginFinancialModel();
                var admin  = loginFinancialModel.getAdmin(this.user, this.pass);

                if (admin == null)
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos. Intente de nuevo.");
                }
                else 
                {
                    Admin adminObj = new Admin();

                    foreach (var token in admin) 
                    {
                        foreach (var item in token) 
                        {
                            switch (item.Key) 
                            {
                                case "idAdmin":
                                adminObj.idAdmin = int.Parse(item.Value);
                                break;

                                case "nameAdmin":
                                adminObj.nameAdmin = item.Value;
                                break;

                                case "lastNameAdmin":
                                adminObj.lastNameAdmin = item.Value;
                                break;

                                case "userAdmin":
                                adminObj.userAdmin = item.Value;
                                break;

                                case "passwordAdmin":
                                adminObj.passwordAdmin = item.Value;
                                break;

                                case "idTypeAdmin":
                                adminObj.idTypeAdmin = int.Parse(item.Value);
                                break;

                                case "typeAdmin":
                                adminObj.typeAdmin = item.Value;
                                break;

                                case "workingHours":
                                adminObj.workingHours = item.Value;
                                break;
                            }
                        }
                    }

                    AdminSingleton.Singleton.saveAdmin(adminObj);

                    if (adminObj.idTypeAdmin == 100) 
                    {
                        loginFinancial.Close();
                        AdminGralWindowFinancial adminGralView = new AdminGralWindowFinancial(loginFinancial, mainWindow);
                        adminGralView.Show();
                        return false;
                    }

                    homeView = new HomeFinancialView(admin);
                    homeView.Show();
                    return true;
                }
            }
            return false;
        }


        public bool sessionIgniter()
        {
            if (!this.user.Equals("") && !this.pass.Equals(""))
            {
                loginFinancialModel = new LoginFinancialModel();
                var admin = loginFinancialModel.getAdmin(this.user, this.pass);

                if (admin == null)
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos. Intente de nuevo.");
                }
                else
                {
                    Admin adminObj = new Admin();

                    foreach (var token in admin)
                    {
                        foreach (var item in token)
                        {
                            switch (item.Key)
                            {
                                case "idAdmin":
                                    adminObj.idAdmin = int.Parse(item.Value);
                                    break;

                                case "nameAdmin":
                                    adminObj.nameAdmin = item.Value;
                                    break;

                                case "lastNameAdmin":
                                    adminObj.lastNameAdmin = item.Value;
                                    break;

                                case "userAdmin":
                                    adminObj.userAdmin = item.Value;
                                    break;

                                case "passwordAdmin":
                                    adminObj.passwordAdmin = item.Value;
                                    break;

                                case "idTypeAdmin":
                                    adminObj.idTypeAdmin = int.Parse(item.Value);
                                    break;

                                case "typeAdmin":
                                    adminObj.typeAdmin = item.Value;
                                    break;

                                case "workingHours":
                                    adminObj.workingHours = item.Value;
                                    break;
                            }
                        }
                    }

                    AdminSingleton.Singleton.saveAdmin(adminObj);

                    homeView = new HomeFinancialView(admin);
                    homeView.Show();
                    return true;
                }
            }
            return false;
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiSystem.app.Financial.views.Login;
using MultiSystem.app.Financial.Models.Login;
using System.Windows;
using MultiSystem.app.Financial.Views.Main;
using MultiSystem.app.Financial.Controllers.AdminController;
using MultiSystem.app.Financial.Views.Controls;

namespace MultiSystem.app.Financial.Controllers
{
    partial class LoginControllerFinancial
    {
        private     LoginFinancialModel loginFinancialModel;
        private     HomeFinancialView homeView;

        public string user { get; set; }
        public string pass { get; set; }

        public LoginControllerFinancial(string user, string pass)
        {
            
            this.user = user;
            this.pass = pass;
        }



        public bool sessionIgniter(LoginFinancial loginFinancial) 
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
                        //AdminGralWindowFinancial obj = new AdminGralWindowFinancial(loginFinancial);
                        //obj.Show();
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

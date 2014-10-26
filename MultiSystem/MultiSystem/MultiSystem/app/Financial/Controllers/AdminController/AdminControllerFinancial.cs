using MultiSystem.app.Financial.Models.Admin;
using MultiSystem.app.Library.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MultiSystem.app.Financial.Controllers.AdminController
{
    public class AdminControllerFinancial
    {
        private List<Dictionary<string, string>> listOfDictionarys;
        private AdminModelFinancial adminModelFinancial; 

        public AdminControllerFinancial() 
        {
            adminModelFinancial = new AdminModelFinancial();
            listOfDictionarys = new List<Dictionary<string, string>>();
        }

        public List<Admin> getAllAdmins()
        {

            listOfDictionarys = adminModelFinancial.getAllAdmins();
            List<Admin> listOfAdmins = new List<Admin>();
            

            foreach (var token in listOfDictionarys) 
            {
                Admin admin = new Admin();
                foreach (var item in token) 
                {
                    switch (item.Key) 
                    {
                        case "idAdmin":
                            admin.idAdmin = int.Parse(item.Value);
                        break;

                        case "nameAdmin":
                            admin.nameAdmin = item.Value;
                        break;

                        case "lastNameAdmin":
                            admin.lastNameAdmin = item.Value;
                        break;

                        case "userAdmin":
                            admin.userAdmin = item.Value;
                        break;

                        case "passwordAdmin":
                            admin.passwordAdmin = item.Value;
                        break;

                        case "typeAdmin":
                            admin.typeAdmin = item.Value;
                        break;

                        case "idTypeAdmin":
                            admin.idTypeAdmin = int.Parse(item.Value);
                        break;

                        case "workingHours":
                            admin.workingHours = item.Value;
                        break;

                    }   
                }

                listOfAdmins.Add(admin);
            }
            return listOfAdmins;
        }

        public List<WorkItem> getAllTypesAdmin()
        {
            List<WorkItem> listOfItems = new List<WorkItem>();
            List<Dictionary<string, string>> listOfTypesAdmin = adminModelFinancial.getAllTypesAdmin();

            foreach(var token in listOfTypesAdmin)
            {
                WorkItem itemWork = new WorkItem();
                foreach (var item in token) 
                {
                    switch (item.Key) 
                    {
                        case "idTypeAdmin":
                            itemWork.Key = int.Parse(item.Value);
                        break;

                        case "typeAdmin":
                            itemWork.Value = item.Value;
                        break;
                    }
                }

                listOfItems.Add(itemWork);
            }

            return listOfItems;
        }

        public int addAdmin(Dictionary<string, string> parameters)
        {

            int adminAdded = adminModelFinancial.addAdmin(parameters);

            if (adminAdded != 0) 
            {
                MessageBox.Show("Agregado con exito: "+adminAdded);
            }

            return adminAdded;
        }


        public int updateAdmin(Dictionary<string, string> setParameters, Dictionary<string, string> whereParameters)
        {
            int adminUpdated = adminModelFinancial.updateAdminmodel(setParameters, whereParameters);

            return adminUpdated;
        }

        public int deleteAdminFinancial(Dictionary<string, string> whereParameters)
        {
            return adminModelFinancial.deleteAdminModelFinancial(whereParameters);
        }
    }
}

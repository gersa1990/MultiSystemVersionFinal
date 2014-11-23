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
using MultiSystem.adminModel;
using MultiSystem.Parameters;
using MultiSystem.app.Financial.Controllers.AdminController;

namespace MultiSystem.app.Library.Controllers
{
	public class AdminController
	{
        private List<ParametersLogin> fields;
        private ParametersLogin objParameter;
		private AdminModel adminModel;

        public AdminController() 
        {
            adminModel = new AdminModel();
        }
		
		private string userName = "";
		public string UserName
		{
			get 
			{
				return userName;
			}
			
			set
			{
				userName = value;
			}
		}
		
		private string passwordName = "";
		public string PasswordName
		{
			get 
			{
				return passwordName;
			}
			
			set
			{
				passwordName =  value;
			}
		}
		
		
		public List<Dictionary<string, string>> Login()
		{
            objParameter                = new ParametersLogin();
            objParameter.userName       = this.userName;
            objParameter.passWordName   = this.passwordName;

            fields = new List<ParametersLogin>();

            fields.Add(objParameter);

            return adminModel.login(fields);
		}

        public List<Admin> getAllAdmins()
        {
            List<Dictionary<string, string>> listAdmins = new List<Dictionary<string, string>>();
            List<Admin> listOfAdmins = new List<Admin>();
            adminModel = new AdminModel();
            listAdmins = adminModel.getAllAdminsModel();

            foreach (var token in listAdmins) 
            {
                Admin admin = new Admin();
                
                foreach(var item in token)
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

                        case "userNameAdmin":
                            admin.userAdmin = item.Value;
                        break;

                        case "passAdmin":
                            admin.passwordAdmin = item.Value;
                        break;

                        case "typeAdmin":
                            admin.idTypeAdmin = int.Parse(item.Value);
                        break;

                        case "descriptionAdmin":
                            admin.typeAdmin = item.Value;
                        break;

                        case "turnAdmin":
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
            List<Dictionary<string, string>> listOfTypesAdmin = new List<Dictionary<string, string>>();
            listOfTypesAdmin = adminModel.getAllTypesAdminsModel();
            List<WorkItem> listOfWorkItem = new List<WorkItem>();
            foreach (var token in listOfTypesAdmin) 
            {
                WorkItem workItem = new WorkItem();

                foreach(var item in token)
                {
                    switch (item.Key) 
                    {
                        case "idTypeAdmin":
                            workItem.Key = int.Parse(item.Value);
                        break;

                        case "descriptionAdmin":
                            workItem.Value = item.Value;
                        break;
                    }
                }

                listOfWorkItem.Add(workItem);
            }

            return listOfWorkItem;
        }

        public int addAdmin(Dictionary<string, string> parameters)
        {
            return adminModel.addAdmin(parameters);
        }

        public int updateAdmin(Dictionary<string, string> setParameters, Dictionary<string, string> whereParameters)
        {
            return adminModel.updateAdminModel(setParameters, whereParameters);
        }

        public int deleteAdmin(Dictionary<string, string> whereParameters)
        {
            return adminModel.deleteAdmin(whereParameters);
        }
    }

    public class TypesAdmin 
    {
        public int      idTypeAdmin { get; set; }

        public string   descriptionAdmin { get; set; }
    }
}
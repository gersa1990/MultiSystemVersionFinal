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
using MultiSystem.core.DB;
using MultiSystem.Parameters;

namespace MultiSystem.adminModel
{
	public class AdminModel : IDatabase
	{

		public AdminModel()
		{
			
		}
		
		public List<Dictionary<string, string>> login(List<ParametersLogin> parameters)
		{
            string query = "SELECT * FROM admins INNER JOIN typesadmin ON typesadmin.idTypeAdmin = admins.typeAdmin WHERE admins.userNameAdmin = '" + ((ParametersLogin)parameters[0]).userName + "' AND  admins.passAdmin =  '" + ((ParametersLogin)parameters[0]).passWordName+"'";
            return this.db.Query("bookStore", query).rowArray();
		}

        public List<Dictionary<string, string>> getAllAdminsModel()
        {
            return this.db.Query("bookStore","SELECT * FROM admins INNER JOIN typesadmin ON typesadmin.idTypeAdmin = admins.typeAdmin WHERE admins.typeAdmin != 1 AND admins.typeAdmin != 100 ").resultArray();
        }

        public List<Dictionary<string, string>> getAllTypesAdminsModel()
        {
            return this.db.Query("bookStore","SELECT * FROM typesadmin WHERE idTypeAdmin != 1 AND idTypeAdmin != 100 ").resultArray();
        }

        public int addAdmin(Dictionary<string, string> parameters)
        {
            return this.db.Insert("bookStore", "admins", parameters);
        }

        public int updateAdminModel(Dictionary<string, string> setParameters, Dictionary<string, string> whereParameters)
        {
            return this.db.Update("bookStore", "admins", setParameters, whereParameters);
        }

        public int deleteAdmin(Dictionary<string, string> whereParameters)
        {
            return this.db.Delete("bookStore", "admins", whereParameters);
        }
    }
}
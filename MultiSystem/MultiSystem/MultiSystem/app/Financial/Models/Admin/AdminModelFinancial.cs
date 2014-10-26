using MultiSystem.core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSystem.app.Financial.Models.Admin
{
    public class AdminModelFinancial : IDatabase
    {
        public AdminModelFinancial() 
        {

        }

        public List<Dictionary<string, string>> getAllAdmins()
        {
            return this.db.Query("financialresources", "SELECT * FROM admins INNER JOIN typeOfAdmins WHERE admins.idTypeAdmin != 1 AND admins.idTypeAdmin != 100 AND admins.idTypeAdmin = typeOfAdmins.idTypeAdmin").resultArray();
        }

        public List<Dictionary<string, string>> getAllTypesAdmin()
        {
           
            return this.db.Query("financialresources","SELECT * FROM typeofadmins WHERE typeofadmins.idTypeAdmin != 1 && typeOfAdmins.idTypeAdmin != 100 ").resultArray();
        }

        public int addAdmin(Dictionary<string, string> parameters)
        {
            return this.db.Insert("financialresources", "admins", parameters);
        }

        public int updateAdminmodel(Dictionary<string, string> setParameters, Dictionary<string, string> whereParameters)
        {
            return this.db.Update("financialresources", "admins", setParameters, whereParameters);
        }

        public int deleteAdminModelFinancial(Dictionary<string, string> whereParameters)
        {
            return this.db.Delete("financialresources","admins", whereParameters);
        }
    }
}

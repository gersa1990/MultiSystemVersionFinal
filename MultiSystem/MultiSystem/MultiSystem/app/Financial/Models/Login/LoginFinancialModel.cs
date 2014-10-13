using MultiSystem.core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSystem.app.Financial.Models.Login
{
    class LoginFinancialModel : IDatabase
    {
        public List<Dictionary<string, string>> getAdmin(string user, string pass)
        {
            return this.db.Query("financialresources", "SELECT * FROM admins INNER JOIN typeofadmins ON admins.idTypeAdmin = typeofadmins.idTypeAdmin WHERE admins.userAdmin = '"+user+"' AND passwordAdmin = '"+pass+"' ").rowArray();
        }
    }
}

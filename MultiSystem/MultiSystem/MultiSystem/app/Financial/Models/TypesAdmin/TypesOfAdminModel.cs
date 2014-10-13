using MultiSystem.core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSystem.app.Financial.Models.TypesAdmin
{
    public class TypesOfAdminModel : IDatabase 
    {

        public List<Dictionary<string, string>> getTypesAdmin()
        {
            return this.db.Query("financialresources", "SELECT * FROM typeofadmins WHERE idTypeAdmin != 1 AND idTypeAdmin != 100 ").resultArray();
        }
    }
}

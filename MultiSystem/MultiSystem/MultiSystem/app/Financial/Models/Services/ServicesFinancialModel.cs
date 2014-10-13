using MultiSystem.core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSystem.app.Financial.Models.Services
{
    class ServicesFinancialModel : IDatabase
    {
        public ServicesFinancialModel() 
        {

        }

        public List<Dictionary<string, string>> getAllServices() 
        {
            return this.db.Select("financialresources", "services").resultArray();
        }

        public int insertNewService(Dictionary<string, string> parameters)
        {
            return this.db.Insert("financialresources", "services", parameters);
        }

        public int editService(Dictionary<string, string> setParameters, Dictionary<string, string> whereParameters)
        {
            return this.db.Update("financialresources", "services", setParameters, whereParameters);
        }
    }
}

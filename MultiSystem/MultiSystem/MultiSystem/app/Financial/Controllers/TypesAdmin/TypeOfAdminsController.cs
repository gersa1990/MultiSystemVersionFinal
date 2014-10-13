using MultiSystem.app.Financial.Models.TypesAdmin;
using MultiSystem.app.Library.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSystem.app.Financial.Controllers.TypesAdmin
{
    public class TypeOfAdminsController
    {
        public TypesOfAdminModel typeOfAdminModel;

        public TypeOfAdminsController() 
        {
            typeOfAdminModel = new TypesOfAdminModel();
        }

        public List<WorkItem> getTypesOfAdmin()
        {
            List<Dictionary<string, string>> listOfTypes =  typeOfAdminModel.getTypesAdmin();
            List<WorkItem> listOfAdminsTypes = new List<WorkItem>();

            foreach (var token in listOfTypes) 
            {
                WorkItem adminType = new WorkItem();

                foreach (var item in token) 
                {
                    switch (item.Key) 
                    {
                        case "idTypeAdmin":
                            adminType.Key = int.Parse(item.Value);
                        break;

                        case "typeAdmin":
                            adminType.Value = item.Value;
                        break;
                    }
                }

                listOfAdminsTypes.Add(adminType);
            }

            return listOfAdminsTypes;
        }
    }

    public class TypeAdmin 
    {
        public TypeAdmin() 
        {

        }

        public int      idTypeAdmin     { get; set; }
        public string   typeAdmin       { get; set; }
        public string   workingHours    { get; set; }
    }
}

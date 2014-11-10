using MultiSystem.core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSystem.app.Financial.Models.BillingModel
{
    class BillingModel : IDatabase
    {
        public BillingModel() 
        {

        }

        public int addPatient(Dictionary<string, string> patientDict)
        {
            return this.db.Insert("financialresources", "servicesdata", patientDict);
        }

        public int addServiceData(Dictionary<string, string> serviceProvided)
        {
            return this.db.Insert("financialresources", "servicesprovided", serviceProvided);
        }

        public List<Dictionary<string, string>> getAllPatients()
        {
            return this.db.Select("financialresources", "servicesdata").resultArray();
        }

        public List<Dictionary<string, string>> getBillingsForId(int idServiceData)
        {
            return this.db.Query("financialresources", "SELECT * FROM servicesprovided INNER JOIN services ON services.idService = servicesprovided.idService WHERE servicesprovided.idServiceData = " + idServiceData + " ").resultArray();
        }

        


        public int deleteServiceData(Dictionary<string, string> whereParameters)
        {
            return this.db.Delete("financialresources", "servicesData", whereParameters);
        }

        public int deleteServiceProvided(Dictionary<string, string> whereParameters)
        {
            return this.db.Delete("financialresources", "servicesprovided", whereParameters);
        }

        public List<Dictionary<string, string>> getPatientsByAdmin(int idAdmin)
        {
            return this.db.Query("financialresources", "SELECT * FROM servicesData INNER JOIN servicesprovided ON servicesdata.idServiceData = servicesprovided.idServiceData WHERE servicesProvided.idAdmin = " + idAdmin + "  GROUP BY servicesdata.folioPatient ASC  ").resultArray();
        }

        public int updateBilling(Dictionary<string, string> setParameters, Dictionary<string, string> whereParameters)
        {
            return this.db.Update("financialresources", "servicesprovided", setParameters, whereParameters);
        }

        public List<Dictionary<string, string>> getBillingsForAdminID(int idAdmin)
        {
            return this.db.Query("financialresources", "SELECT * FROM servicesprovided INNER JOIN servicesData ON servicesdata.idServiceData = servicesprovided.idServiceData INNER JOIN services ON services.idService = servicesprovided.idService  WHERE servicesprovided.idAdmin = "+idAdmin+"  ").resultArray();
        }

        public List<Dictionary<string, string>> getServicesForCancel(int p)
        {
            return this.db.Query("financialresources", "SELECT * FROM servicesprovided WHERE idServiceData = "+p+"").resultArray();
        }

        public int cancelServiceModel(Dictionary<string, string> whereParameters, Dictionary<string, string> setParameters)
        {
            return this.db.Update("financialresources", "servicesprovided", setParameters, whereParameters);
        }
    }
}

using MultiSystem.core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public List<Dictionary<string, string>> getPatientsByAdmin(int idAdmin, string date)
        {
            return this.db.Query("financialresources", "SELECT * FROM servicesData INNER JOIN servicesprovided ON servicesdata.idServiceData = servicesprovided.idServiceData WHERE servicesProvided.idAdmin = " + idAdmin + " AND servicesData.dateService = '"+date+"'  GROUP BY servicesdata.folioPatient ASC  ").resultArray();
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

        public List<Dictionary<string, string>> getPatientsByAdminNocturn(int idAdmin, string auxDateYesterday, string auxDateToday)
        {
            string query = "SELECT *  FROM (SELECT servicesData.idServiceData, servicesData.dateService, servicesData.hourService, servicesdata.folioPatient, servicesdata.namePatient, servicesdata.lastNamePatient, servicesdata.adressPatient, servicesdata.auxDate, servicesprovided.idProvided, servicesprovided.idService, servicesprovided.idAdmin, servicesprovided.serviceCanceled, servicesprovided.reasonDiscount, servicesprovided.amountWithDiscount FROM servicesData INNER JOIN servicesprovided ON servicesdata.idServiceData = servicesprovided.idServiceData WHERE servicesProvided.idAdmin = 6) AS results  WHERE ( dateService = '" + auxDateYesterday + "' AND hourService > '19:00') OR ( dateService = '" + auxDateToday + "' AND hourService < '09:00')";
            return this.db.Query("financialresources", "SELECT *  FROM (SELECT servicesData.idServiceData, servicesData.dateService, servicesData.hourService, servicesdata.folioPatient, servicesdata.namePatient, servicesdata.lastNamePatient, servicesdata.adressPatient, servicesdata.auxDate, servicesprovided.idProvided, servicesprovided.idService, servicesprovided.idAdmin, servicesprovided.serviceCanceled, servicesprovided.reasonDiscount, servicesprovided.amountWithDiscount FROM servicesData INNER JOIN servicesprovided ON servicesdata.idServiceData = servicesprovided.idServiceData WHERE servicesProvided.idAdmin = 6) AS results  WHERE ( dateService = '" + auxDateYesterday + "' AND hourService > '19:00') OR ( dateService = '" + auxDateToday + "' AND hourService < '09:00')").resultArray();
        }

        public List<Dictionary<string, string>> getPatientsByAdminNocturnToday(int idAdmin, string auxDate)
        {
            return this.db.Query("financialresources", "SELECT * FROM servicesprovided INNER JOIN servicesData ON servicesdata.idServiceData = servicesprovided.idServiceData INNER JOIN services ON services.idService = servicesprovided.idService  WHERE servicesprovided.idAdmin = " + idAdmin + " AND servicesData.dateService = '"+auxDate+"'  ").resultArray();
        }

        public List<Dictionary<string, string>> getPatientsByAdminTicket(int idAdmin, string date)
        {
            return this.db.Query("financialresources", "SELECT * FROM servicesData INNER JOIN servicesprovided ON servicesdata.idServiceData = servicesprovided.idServiceData INNER JOIN services ON services.idService = servicesprovided.idService WHERE servicesProvided.idAdmin = " + idAdmin + " AND servicesData.dateService = '" + date + "'  ").resultArray();
        }

        public List<Dictionary<string, string>> getPatientsByAdminNocturnTicket(int p, string auxDateYesterday, string auxDateToday)
        {
            return this.db.Query("financialresources", "SELECT *  FROM (SELECT servicesData.idServiceData, servicesData.dateService, servicesData.hourService, servicesdata.folioPatient, servicesdata.namePatient, servicesdata.lastNamePatient, servicesdata.adressPatient, servicesdata.auxDate, services.type, services.amountPrice, services.keyPrice, servicesprovided.idProvided, servicesprovided.idService, servicesprovided.idAdmin, servicesprovided.serviceCanceled, servicesprovided.reasonDiscount, servicesprovided.amountWithDiscount FROM servicesData INNER JOIN servicesprovided ON servicesprovided.idServiceData = servicesData.idServiceData INNER JOIN services ON services.idService = servicesprovided.idService WHERE servicesProvided.idAdmin = "+p+") AS results  WHERE ( dateService = '"+auxDateYesterday+"' AND hourService > '19:00') OR ( dateService = '"+auxDateToday+"' AND hourService < '09:00')").resultArray();
        }

        public List<Dictionary<string, string>> getPatientsByAdminNocturnTodayTicket(int idAdmin, string auxDate)
        {
            return this.db.Query("financialresources", "SELECT * FROM servicesprovided INNER JOIN servicesData ON servicesdata.idServiceData = servicesprovided.idServiceData INNER JOIN services ON services.idService = servicesprovided.idService  WHERE servicesprovided.idAdmin = " + idAdmin + " AND servicesData.dateService = '"+auxDate+"'  ").resultArray();
        }

        public List<Dictionary<string, string>> getPatientsByMonthlyReport(string strDateInitial, string strDateFinal)
        {
            string query = "SELECT servicesprovided.idProvided, servicesprovided.idServiceData, servicesprovided.idService, servicesprovided.idAdmin, servicesprovided.serviceCanceled, servicesprovided.reasonDiscount, servicesprovided.amountWithDiscount, servicesdata.folioPatient, servicesdata.namePatient, servicesdata.lastNamePatient, servicesdata.adressPatient, services.type, services.keyPrice, services.amountPrice, services.descriptionPrice,  servicesprovided.serviceCanceled  FROM servicesprovided INNER JOIN servicesData ON servicesdata.idServiceData = servicesprovided.idServiceData INNER JOIN services ON services.idService = servicesprovided.idService   WHERE servicesdata.dateService BETWEEN   '" + strDateInitial + "' AND '" + strDateFinal + "'  ";

            Console.WriteLine(query);

            return this.db.Query("financialresources", "SELECT servicesprovided.idProvided, servicesprovided.idServiceData, servicesprovided.idService, servicesprovided.idAdmin, servicesprovided.serviceCanceled, servicesprovided.reasonDiscount, servicesprovided.amountWithDiscount, servicesdata.folioPatient, servicesdata.namePatient, servicesdata.lastNamePatient, servicesdata.adressPatient, services.type, services.keyPrice, services.amountPrice, services.descriptionPrice,  servicesprovided.serviceCanceled  FROM servicesprovided INNER JOIN servicesData ON servicesdata.idServiceData = servicesprovided.idServiceData INNER JOIN services ON services.idService = servicesprovided.idService   WHERE servicesdata.dateService BETWEEN   '"+strDateInitial + "' AND '" + strDateFinal + "'  ").resultArray();
        }
    }
}

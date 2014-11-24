using MultiSystem.app.Financial.Controllers.AdminController;
using MultiSystem.app.Financial.Models.BillingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MultiSystem.app.Financial.Controllers.BillingController
{
    class BillingController
    {

        /// <summary>
        /// Object for Model to create the Billing
        /// </summary>
        private BillingModel billingModel;

        public BillingController() 
        {
            billingModel = new BillingModel();
        }

  

        public List<Patient> getAllPatient() 
        {
            List<Patient> patientsFounded = new List<Patient>();
            List<Dictionary<string, string>> listOfPatients = new List<Dictionary<string, string>>();
            listOfPatients = billingModel.getAllPatients();

            Patient patient;

            foreach (var token in listOfPatients) 
            {
                patient = new Patient();

                foreach (var item in token) 
                {
                    switch (item.Key)
                    {
                        case "idServiceData":
                        patient.idServiceData = int.Parse(item.Value);
                        break;

                        case "folioPatient":
                        patient.folioPatient = item.Value;
                        break;

                        case "namePatient":
                        patient.namePatient = item.Value;
                        break;

                        case "lastNamePatient":
                        patient.lastNamePatient = item.Value;
                        break;

                        case "adressPatient":
                        patient.adressPatient = item.Value;
                        break;

                        case "dateService":
                        patient.dateService = item.Value;
                        break;

                        case "auxDate":
                        patient.auxDate = item.Value;
                        break;

                        case "hourService":
                        patient.hourService = item.Value;
                        break;
                    }
                }

                patientsFounded.Add(patient);
            }

            return patientsFounded;
        }

        /// <summary>
        /// To create billing for Patient
        /// </summary>
        /// <param name="listOfBillsAdded">List of services, required for patient</param>
        /// <param name="patient">Object type Patient, contains the Patient data</param>
        /// <returns>boll (Success => true) (Error => false) </returns>
        public bool createBilling(List<Bill> listOfBillsAdded, Patient patient)
        {
            Dictionary<string, string> patientDict = new Dictionary<string, string>();

            Admin admin = AdminSingleton.Singleton.getAdmin();

            patient.dateService = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd");
            patient.hourService = DateTime.Now.ToString("HH:mm");

            patientDict.Add("folioPatient", patient.folioPatient.ToUpper());
            patientDict.Add("namePatient",patient.namePatient.ToUpper());
            patientDict.Add("lastNamePatient", patient.lastNamePatient.ToUpper());
            patientDict.Add("adressPatient", patient.adressPatient.ToUpper());
            patientDict.Add("dateService", patient.dateService);
            patientDict.Add("hourService",patient.hourService);
            patientDict.Add("auxDate", DateTime.Now.Year + "_" +DateTime.Now.ToString("MM") + "_" + DateTime.Now.ToString("dd"));
            int idServiceData = billingModel.addPatient(patientDict);

            Dictionary<string, string> serviceProvided;

            if (idServiceData > 0)
            {
                foreach (var item in listOfBillsAdded)
                {
                    serviceProvided = new Dictionary<string, string>();

                    serviceProvided.Add("idServiceData", idServiceData + "");
                    serviceProvided.Add("idService", item.idService + "");
                    serviceProvided.Add("idAdmin", admin.idAdmin + "");
                    serviceProvided.Add("reasonDiscount", item.reasonDiscount.ToUpper());
                    serviceProvided.Add("amountWithDiscount", item.amountWithDiscount + "");

                    int serviceProvidedAdded = billingModel.addServiceData(serviceProvided);

                    if (serviceProvidedAdded <= 0)
                    {
                        return false;
                    }
                }
            }
            else 
            {
                return false;
            }

            return true;
        }

        public List<Bill> getBillsForPatientID(int p)
        {
            List<Bill> listBillings = new List<Bill>();
            Bill bill;
            List<Dictionary<string, string>> billings = new List<Dictionary<string, string>>();

            string auxDate = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd");
            int hour = DateTime.Now.Hour;

            

            billings = billingModel.getBillingsForId(p);


            if (billings.Count <= 0)
            {
                MessageBox.Show("null");
                return null;
            }

            foreach (var token in billings) 
            {
                bill = new Bill();

                foreach (var item in token) 
                {
                    switch (item.Key) 
                    {
                        case "idProvided":
                        bill.idProvided = int.Parse(item.Value);
                        break;

                        case "idService":
                        bill.idService = int.Parse(item.Value);
                        break;

                        case "reasonDiscount":
                        bill.reasonDiscount = item.Value;
                        break;
                            
                        case "amounthWithDiscount":
                        bill.amountWithDiscount = int.Parse( item.Value );
                        break;

                        case "keyPrice":
                        bill.keyPrice = item.Value;
                        break;

                        case "serviceCanceled":
                        bill.serviceCanceled = int.Parse(item.Value);
                        break;

                        case "descriptionPrice":
                        bill.descriptionPrice = item.Value;
                        break;

                        case "amountPrice":
                        bill.amountPrice = int.Parse(item.Value);
                        break;

                        case "type":
                        bill.type = item.Value;
                        break;
                    }
                }

                listBillings.Add(bill);
            }

            return listBillings;
        }

        public int deleteBillngs(int idServiceData)
        {
            Dictionary<string, string> whereParameters = new Dictionary<string, string>();
            whereParameters.Add("idServiceData",idServiceData+"");

            if (billingModel.deleteServiceData(whereParameters) != 0)
            {
                return billingModel.deleteServiceProvided(whereParameters);
            }
            
            return 0;
        }

        public List<Patient> getAllPatientForAdmin(int idAdmin, string date)
        {

            List<Patient> patients = new List<Patient>();
            Patient patient;
           
            List<Dictionary<string, string>> patientsDictionary = billingModel.getPatientsByAdmin(idAdmin, date);

            if (patientsDictionary == null)
            {
                return null;
            }

            foreach (var token in patientsDictionary) 
            {
                patient = new Patient();
                foreach (var item in token) 
                {
                    switch (item.Key)
                    {
                        case "idServiceData":
                            patient.idServiceData = int.Parse(item.Value);
                            break;

                        case "folioPatient":
                            patient.folioPatient = item.Value;
                            break;

                        case "namePatient":
                            patient.namePatient = item.Value;
                            break;

                        case "lastNamePatient":
                            patient.lastNamePatient = item.Value;
                            break;

                        case "adressPatient":
                            patient.adressPatient = item.Value;
                            break;

                        case "dateService":
                            patient.dateService = item.Value;
                            break;

                        case "auxDate":
                            patient.auxDate = item.Value;
                        break;

                        case "hourService":
                            patient.hourService = item.Value;
                            break;
                    }
                }

                patients.Add(patient);
            }

            

            return patients;
        }

        public int updateBilling(Bill bill)
        {
            Dictionary<string, string> whereParameters = new Dictionary<string, string>();
            Dictionary<string, string> setParameters = new Dictionary<string, string>();

            whereParameters.Add("idProvided",bill.idProvided+"");

            setParameters.Add("reasonDiscount", "'"+bill.reasonDiscount+"'");
            setParameters.Add("amountWithDiscount", bill.amountWithDiscount+"");

          int updated =  billingModel.updateBilling(setParameters, whereParameters);
          
          return updated;
        }

        public List<Ticket> getBillingForAdminID(int idAdministrador)
        {
            List<Dictionary<string, string>> listOfDictionarys = new List<Dictionary<string, string>>();
            List<Ticket> listOfBills = new List<Ticket>();
            Ticket ticket;

            int hour = DateTime.Now.Hour;
            string auxDate = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd");

            if (idAdministrador == 5 || idAdministrador == 6)
            {
                if (hour >= 19)
                {
                    listOfDictionarys = billingModel.getPatientsByAdminNocturnToday(idAdministrador, auxDate); //billingController.getAllPatient();

                }
                else if (hour <= 10)
                {
                    string auxDateYesterday = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.AddDays(-1).ToString("dd");
                    string auxDateToday = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd");

                    listOfDictionarys = billingModel.getPatientsByAdminNocturn(idAdministrador, auxDateYesterday, auxDateToday);
                }
            }
            else 
            {
                listOfDictionarys = billingModel.getBillingsForAdminID(idAdministrador);
            }
           
            string dateAux = DateTime.Now.Year + "_" + DateTime.Now.ToString("MM") + "_" + DateTime.Now.ToString("dd");

            foreach (var token in listOfDictionarys) 
            {
                ticket = new Ticket();
               // isEnabled = true;

                foreach (var item in token) 
                {
                    /*if (item.Key.Equals("auxDate") ) 
                    {
                        if (!item.Value.Equals(dateAux)) 
                        {
                            isEnabled = false;
                        }
                    }*/

                    switch(item.Key)
                    {
                        case "idServiceData":
                        ticket.idServiceData = int.Parse(item.Value);
                        break;

                        case "idService":
                        ticket.idService = int.Parse(item.Value);
                        break;

                        case "reasonDiscount":
                        ticket.reasonDiscount = item.Value;
                        break;

                        case "amountPrice":
                        ticket.amountPrice = int.Parse(item.Value);
                        break;

                        case "namePatient":
                        ticket.namePatien = item.Value;
                        break;

                        case "lastNamePatient":
                        ticket.lastNamePatient = item.Value;
                        break;

                        case "adressPatient":
                        ticket.adressPatient = item.Value;
                        break;

                        case "dateService":
                        ticket.dateService = item.Value;
                        break;

                        case "type":
                        ticket.type = item.Value;
                        break;

                        case "hourService":
                        ticket.hourService = item.Value;
                        break;

                        case "auxDate":
                        ticket.auxDate = item.Value;
                        break;

                        case "amountWithDiscount":
                        ticket.amountWithDiscount = int.Parse(item.Value);
                        break;

                        case "descriptionPrice":
                        ticket.descriptionPrice = item.Value;
                        break;

                        case "keyPrice":
                        ticket.keyPrice = item.Value;
                        break;

                        case "folioPatient":
                        ticket.folio = item.Value;
                        break;
                    }
                }

               /* if (isEnabled) 
                {
                    listOfBills.Add(ticket);
                }*/
            }

            return listOfBills;
        }

        public int cancelServiceController(Patient patient, string reason)
        {
            List<Dictionary<string, string>> listOfServicesForCancel = billingModel.getServicesForCancel(patient.idServiceData);
            int serviceCanceled = 0;

            foreach (var token in listOfServicesForCancel)
            {
                foreach (var item in token)
                {
                    if (item.Key == "idProvided")
                    {
                        int idProvided = int.Parse(item.Value);

                        Dictionary<string, string> setParameters = new Dictionary<string, string>();
                        setParameters.Add("reasonDiscount", '"'+reason.ToUpper()+'"');
                        setParameters.Add("serviceCanceled", 1 + "");

                        Dictionary<string, string> whereParameters = new Dictionary<string, string>();
                        whereParameters.Add("idServiceData", patient.idServiceData + "");

                        serviceCanceled = billingModel.cancelServiceModel(whereParameters, setParameters);

                        if (serviceCanceled == 0)
                        {
                            return 0;
                        }
                    }
                }
            }

            return serviceCanceled;
            
        }

        public List<Patient> getAllPatientForAdminAux(int p, string auxDateYesterday, string auxDateToday)
        {
            List<Dictionary<string, string>> listOfDictionary = billingModel.getPatientsByAdminNocturn( p, auxDateYesterday, auxDateToday);

            Console.WriteLine(listOfDictionary+" count: "+listOfDictionary.Count);

            List<Patient> patients = new List<Patient>();


            if (listOfDictionary == null)
            {
                return null;
            }

            foreach (var token in listOfDictionary)
            {
                Patient patient = new Patient();
                foreach (var item in token)
                {
                    switch (item.Key)
                    {
                        case "idServiceData":
                            patient.idServiceData = int.Parse(item.Value);
                            break;

                        case "folioPatient":
                            patient.folioPatient = item.Value;
                            break;

                        case "namePatient":
                            patient.namePatient = item.Value;
                            break;

                        case "lastNamePatient":
                            patient.lastNamePatient = item.Value;
                            break;

                        case "adressPatient":
                            patient.adressPatient = item.Value;
                            break;

                        case "dateService":
                            patient.dateService = item.Value;
                            break;

                        case "auxDate":
                            patient.auxDate = item.Value;
                            break;

                        case "hourService":
                            patient.hourService = item.Value;
                            break;
                    }
                }

                patients.Add(patient);
            }

            return patients;
        }

        public List<Patient> getAllPatientForAdminTodayNocturn(int p, string auxDate)
        {
            List<Dictionary<string, string>> listOfDictionary = billingModel.getPatientsByAdminNocturnToday( p,  auxDate);

            Console.WriteLine(listOfDictionary + " count: " + listOfDictionary.Count);

            List<Patient> patients = new List<Patient>();


            if (listOfDictionary == null)
            {
                return null;
            }

            foreach (var token in listOfDictionary)
            {
                Patient patient = new Patient();
                foreach (var item in token)
                {
                    switch (item.Key)
                    {
                        case "idServiceData":
                            patient.idServiceData = int.Parse(item.Value);
                            break;

                        case "folioPatient":
                            patient.folioPatient = item.Value;
                            break;

                        case "namePatient":
                            patient.namePatient = item.Value;
                            break;

                        case "lastNamePatient":
                            patient.lastNamePatient = item.Value;
                            break;

                        case "adressPatient":
                            patient.adressPatient = item.Value;
                            break;

                        case "dateService":
                            patient.dateService = item.Value;
                            break;

                        case "auxDate":
                            patient.auxDate = item.Value;
                            break;

                        case "hourService":
                            patient.hourService = item.Value;
                            break;
                    }
                }

                patients.Add(patient);
            }

            return patients;
        }

        public List<Ticket> getAllPatientForAdminTodayNocturnTicket(int p, string auxDate)
        {
            List<Dictionary<string, string>> listOfDictionary = billingModel.getPatientsByAdminNocturnTodayTicket(p, auxDate);
            List<Ticket> patients = new List<Ticket>();


            if (listOfDictionary == null)
            {
                return null;
            }

            foreach (var token in listOfDictionary)
            {
                Ticket patient = new Ticket();
                foreach (var item in token)
                {
                    switch (item.Key)
                    {
                        case "idServiceData":
                            patient.idServiceData = int.Parse(item.Value);
                            break;

                        case "folioPatient":
                            patient.folio = item.Value;
                            break;

                        case "namePatient":
                            patient.namePatien = item.Value;
                            break;

                        case "lastNamePatient":
                            patient.lastNamePatient = item.Value;
                            break;

                        case "adressPatient":
                            patient.adressPatient = item.Value;
                            break;

                        case "dateService":
                            patient.dateService = item.Value;
                            break;

                        case "auxDate":
                            patient.auxDate = item.Value;
                            break;

                        case "hourService":
                            patient.hourService = item.Value;
                            break;

                        case "type":
                            patient.type = item.Value;
                            break;
                    }
                }

                patients.Add(patient);
            }

            return patients;
        }

        public List<Ticket> getAllPatientForAdminAuxTicket(int p, string auxDateYesterday, string auxDateToday)
        {
            List<Dictionary<string, string>> listOfDictionary = billingModel.getPatientsByAdminNocturnTicket(p, auxDateYesterday, auxDateToday);

            Console.WriteLine(listOfDictionary + " count: " + listOfDictionary.Count);

            List<Ticket> patients = new List<Ticket>();


            if (listOfDictionary == null)
            {
                return null;
            }

            foreach (var token in listOfDictionary)
            {
                Ticket patient = new Ticket();
                foreach (var item in token)
                {
                    switch (item.Key)
                    {
                        case "idServiceData":
                            patient.idServiceData = int.Parse(item.Value);
                            break;

                        case "folioPatient":
                            patient.folio = item.Value;
                            break;

                        case "namePatient":
                            patient.namePatien = item.Value;
                            break;

                        case "lastNamePatient":
                            patient.lastNamePatient = item.Value;
                            break;

                        case "adressPatient":
                            patient.adressPatient = item.Value;
                            break;

                        case "dateService":
                            patient.dateService = item.Value;
                            break;

                        case "auxDate":
                            patient.auxDate = item.Value;
                            break;

                        case "hourService":
                            patient.hourService = item.Value;
                            break;

                        case "type":
                            patient.type = item.Value;
                        break;
                    }
                }

                patients.Add(patient);
            }

            return patients;
        }

        public List<Ticket> getAllPatientForAdminTicket(int idAdmin, string date)
        {
            List<Ticket> patients = new List<Ticket>();
            Ticket patient;

            List<Dictionary<string, string>> patientsDictionary = billingModel.getPatientsByAdminTicket(idAdmin, date);

            if (patientsDictionary == null)
            {
                return null;
            }

            foreach (var token in patientsDictionary)
            {
                patient = new Ticket();
                foreach (var item in token)
                {
                    switch (item.Key)
                    {
                        case "idServiceData":
                            patient.idServiceData = int.Parse(item.Value);
                            break;

                        case "folioPatient":
                            patient.folio = item.Value;
                            break;

                        case "namePatient":
                            patient.namePatien = item.Value;
                            break;

                        case "lastNamePatient":
                            patient.lastNamePatient = item.Value;
                            break;

                        case "adressPatient":
                            patient.adressPatient = item.Value;
                            break;

                        case "dateService":
                            patient.dateService = item.Value;
                            break;

                        case "auxDate":
                            patient.auxDate = item.Value;
                            break;

                        case "hourService":
                            patient.hourService = item.Value;
                        break;

                        case "type":
                            patient.type = item.Value;
                        break;

                        case "serviceCanceled":
                            patient.serviceCanceled = int.Parse(item.Value);
                        break;

                        case "reasonDiscount":
                            patient.reasonDiscount = item.Value;
                        break;
                    }
                }

                patients.Add(patient);
            }

            return patients;
        }

        public List<Ticket> getBillingsForMonthlyReport(string strDateInitial, string strDateFinal)
        {
            List<Ticket> patients = new List<Ticket>();
            Ticket patient;

            List<Dictionary<string, string>> patientsDictionary = billingModel.getPatientsByMonthlyReport(strDateInitial, strDateFinal);

            if (patientsDictionary == null)
            {
                return null;
            }

            foreach (var token in patientsDictionary)
            {
                patient = new Ticket();
                foreach (var item in token)
                {
                    switch (item.Key)
                    {
                        case "idServiceData":
                            patient.idServiceData = int.Parse(item.Value);
                        break;

                        case "folioPatient":
                            patient.folio = item.Value;
                        break;

                        case "namePatient":
                            patient.namePatien = item.Value;
                        break;

                        case "lastNamePatient":
                            patient.lastNamePatient = item.Value;
                        break;

                        case "adressPatient":
                            patient.adressPatient = item.Value;
                        break;

                        case "dateService":
                            patient.dateService = item.Value;
                        break;

                        case "auxDate":
                            patient.auxDate = item.Value;
                        break;

                        case "hourService":
                            patient.hourService = item.Value;
                        break;

                        case "descriptionPrice":
                            patient.descriptionPrice = item.Value;
                        break;

                        case "type":
                            patient.type = item.Value;
                        break;

                        case "amountPrice":
                            patient.amountPrice = int.Parse(item.Value);
                        break;

                        case "amountWithDiscount":
                            patient.amountWithDiscount = int.Parse(item.Value);
                        break;

                        case "serviceCanceled":
                            patient.serviceCanceled = int.Parse(item.Value);
                        break;

                        case "reasonDiscount":
                            patient.reasonDiscount = item.Value;
                        break;
                    }
                }

                patients.Add(patient);
            }

            return patients;
        }
    }
}

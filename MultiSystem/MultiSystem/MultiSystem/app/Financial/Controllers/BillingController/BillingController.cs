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
            patient.hourService = DateTime.Now.Hour.ToString()+":"+DateTime.Now.Minute.ToString();

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

        public List<Patient> getAllPatientForAdmin(int idAdmin)
        {

            List<Patient> patients = new List<Patient>();
            Patient patient;
           
            List<Dictionary<string, string>> patientsDictionary = billingModel.getPatientsByAdmin(idAdmin);

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
            bool isEnabled = true;

            listOfDictionarys = billingModel.getBillingsForAdminID(idAdministrador);
            string dateAux = DateTime.Now.Year + "_" + DateTime.Now.ToString("MM") + "_" + DateTime.Now.ToString("dd");

            foreach (var token in listOfDictionarys) 
            {
                ticket = new Ticket();
                isEnabled = true;

                foreach (var item in token) 
                {
                    if (item.Key.Equals("auxDate") ) 
                    {
                        if (!item.Value.Equals(dateAux)) 
                        {
                            isEnabled = false;
                        }
                    }

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

                if (isEnabled) 
                {
                    listOfBills.Add(ticket);
                }
            }

            return listOfBills;
        }
    }
}

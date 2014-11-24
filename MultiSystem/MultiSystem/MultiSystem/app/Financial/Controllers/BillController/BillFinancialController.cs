using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSystem.app.Financial.Controllers
{

    /// <summary>
    /// Controller for pre Create billing
    /// </summary>
    public class BillFinancialController
    {
        public List<Bill> listOfBills;
        public BillFinancialController() 
        {
            listOfBills = new List<Bill>();
        }

        public BillFinancialController add(Bill bill) 
        {
            listOfBills.Add(bill);
            return this;
        }
    }

    /// <summary>
    /// Class Patient
    /// Contain the rows from DataBase financialResources, table servicesdata
    /// </summary>
    public class Patient 
    {
        public int idServiceData { get; set; }

        public string auxDate { get; set; }

        [DisplayName("Folio")]
        public string folioPatient { get; set; }

        [DisplayName("Nombre")]
        public string namePatient { get; set; }

        [DisplayName("Apellidos")]
        public string lastNamePatient { get; set; }

        [DisplayName("Dirección")]
        public string adressPatient { get; set; }

        [DisplayName("Fecha")]
        public string dateService { get; set; }

        [DisplayName("Hora")]
        public string hourService { get; set; }

        public Patient() 
        {

        }
        /// <summary>
        /// Constructor for patient Data
        /// </summary>
        /// <param name="idServiceData">int idServiceData from Database</param>
        /// <param name="namePatient">Name of Patient</param>
        /// <param name="lastNamePatient">Lastname Patient</param>
        /// <param name="dateService">Date of service</param>
        /// <param name="hourService">Hour of service</param>
        public Patient(int idServiceData, string namePatient, string lastNamePatient, string dateService, string hourService)
        {
            this.idServiceData = idServiceData;
            this.namePatient = namePatient;
            this.lastNamePatient = lastNamePatient;
            this.dateService = dateService;
            this.hourService = hourService;
        }

        /// <summary>
        ///  Constructor 
        /// </summary>
        /// <param name="namePatient">Name of Patient</param>
        /// <param name="lastNamePatient">Lastname Patient</param>
        /// <param name="dateService">Date of service</param>
        /// <param name="hourService">Hour of service</param>
        public Patient( string namePatient, string lastNamePatient, string dateService, string hourService)
        {
            this.namePatient = namePatient;
            this.lastNamePatient = lastNamePatient;
            this.dateService = dateService;
            this.hourService = hourService;
        }

        
    }

    public class Ticket 
    {
        public int idServiceData { get; set; }
        public string namePatien { get; set; }
        public string lastNamePatient { get; set; }
        public string adressPatient { get; set; }
        public string dateService { get; set; }
        public string hourService { get; set; }
        public string auxDate { get; set; }
        public int idService { get; set; }
        public string keyPrice { get; set; }
        public string descriptionPrice { get; set; }
        public int amountPrice { get; set; }
        public string type { get; set; }
        public string reasonDiscount { get; set; }
        public int amountWithDiscount { get; set; }
        public string folio { get; set; }

        public int serviceCanceled { get; set; }

        public void description() 
        {
            Console.WriteLine(" idServiceData: " + idServiceData + " \nnamePatien: " + namePatien + " \nlastName: " + lastNamePatient);
            Console.WriteLine(" address: " + adressPatient + " \ndateService " + dateService + " \nhourService " + hourService);
            Console.WriteLine(" auxDate: " + auxDate + " \nidService: " + idService + " \nkeyPrice: " + keyPrice + " \ndescriptionPrice: " + descriptionPrice);
            Console.WriteLine(" amountPrice" + amountPrice + " \ntype: " + type + " \nreasonDiscount: " + reasonDiscount);
            Console.WriteLine(" amountWithDiscount: " + amountWithDiscount + " folio: " + folio + "\n\n");
            Console.WriteLine(" cancelado: "+serviceCanceled);
        }
    }

    /// <summary>
    /// Bill class, this class contain all data for billing ticket
    /// </summary>
    public class Bill
    {
        /// <summary>
        /// 
        /// </summary>
        /// 
        public int idProvided { get; set; }

        public int idService { get; set; }

        [DisplayName("Clave")]
        public string keyPrice { get; set; }

        [DisplayName("Descripción")]
        public string descriptionPrice { get; set; }

        [DisplayName("Precio")]
        public int amountPrice { get; set; }

        [DisplayName("Categoria")]
        public string type { get; set; }

       [DisplayName("Servicio cancelado")]
        public int serviceCanceled { get; set; }

        public string reasonDiscount { get; set; }

        [DisplayName("Descuento")]
        public int amountWithDiscount { get; set; }

        /// <summary>
        /// Constructor empty for create simple objects
        /// </summary>
        public Bill()
        {

        }

        /// <summary>
        /// Constructor to create the complete object Bill
        /// </summary>
        /// <param name="idService">ID from service provided</param>
        /// <param name="keyPrice">Key search</param>
        /// <param name="descriptionPrice">Short description</param>
        /// <param name="amountPrice">Real amount of service</param>
        /// <param name="type">Type of service, example Ambulance, Laboratory, etc</param>
        /// <param name="reasonDiscount">Reason for create discount</param>
        /// <param name="amountWithDiscount">Amounth with discoubnt applied</param>
        public Bill(int idService, string keyPrice, string descriptionPrice, int amountPrice, string type, string reasonDiscount, int amountWithDiscount ) 
        {
            this.idService = idService;
            this.keyPrice = keyPrice;
            this.descriptionPrice = descriptionPrice;
            this.amountPrice = amountPrice;
            this.type = type;
            this.reasonDiscount = reasonDiscount;
            this.amountWithDiscount = amountWithDiscount;
        }
    }
}

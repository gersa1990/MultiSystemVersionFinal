using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiSystem.app.Financial.Models.Services;
using System.ComponentModel;
using System.Windows;
using System.Globalization;

namespace MultiSystem.app.Financial.Controllers
{
    class ServicesFinancialController
    {
        private ServicesFinancialModel modelFinancial;

        public ServicesFinancialController() 
        {
            this.modelFinancial = new ServicesFinancialModel();
        }
		
		private string parsingToCurrencyFormat(int money)
		{
			var culture = CultureInfo.GetCultureInfo("es-MX");
			var formattedNumber = string.Format(culture , "{0:C}", money);
			
			return formattedNumber;
		}

        public int InsertNewService(Dictionary<string,string> parameters) 
        {
            return modelFinancial.insertNewService(parameters);
        }

        public List<Service> getAllServices() 
        {
            List<Service> servicesFounded = new List<Service>();

            List<Dictionary<string, string>> servicesDict =  modelFinancial.getAllServices();

            Service service;

            foreach (var token in servicesDict) 
            {
                service = new Service();
 
                foreach(var item in token)
                {
                    switch(item.Key)
                    {
                        case "idService":
                        service.idService = int.Parse(item.Value);
                        break;

                        case "keyPrice":
                        service.keyPrice = item.Value;
                        break;

                        case "descriptionPrice":
						service.descriptionPrice = item.Value;     
                        break;

                        case "amountPrice":
						service.amountPrice = this.parsingToCurrencyFormat( int.Parse(item.Value));
						break;
							
						case "type":
						service.type = item.Value;
						break;
                    }
                }

                servicesFounded.Add(service);
            }

            return servicesFounded;
        }

        public int editService(Dictionary<string, string> setParameters, Dictionary<string, string> whereParameters)
        {
            return modelFinancial.editService(setParameters, whereParameters);
        }
    }

    public class Service
    {
        public int idService {get; set;}
		
		[DisplayName("Clave")]
        public string keyPrice { get; set; }
		
		[DisplayName("Descripción")]
        public string descriptionPrice { get; set; }
		
		[DisplayName("Monto")]
        public string amountPrice { get; set; }
		
		[DisplayName("Categoria")]
        public string type { get; set; } 
    }
}

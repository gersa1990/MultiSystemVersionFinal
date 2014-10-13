using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSystem.app.Financial.Controllers.BillingController
{
    public class BillSingleton
    {
        private static BillSingleton singleton;
        private List<Bill> listOfBills = new List<Bill>();

        public BillSingleton()
        {

        }

        public void deleteBills() 
        {
            this.listOfBills = new List<Bill>();
        }

        public static BillSingleton Singleton 
        {
            get 
            {
                if(singleton == null)
                {
                    singleton = new BillSingleton();
                }
                return singleton;
            }
        }

        public void addBill(Bill bill) 
        {
            listOfBills.Add(bill);
        }

        public List<Bill> getBills() 
        {
            return listOfBills;
        }

        public void editBill(Bill bill)
        {
            foreach (var item in listOfBills) 
            {
                if (item.idService == bill.idService) 
                {
                    item.amountWithDiscount = bill.amountWithDiscount;
                    item.reasonDiscount = bill.reasonDiscount;
                }
            }
        }

        public void deleteBill(Bill bill)
        {
            foreach (var item in listOfBills)
            {
                if (item.idService == bill.idService)
                {
                    listOfBills.Remove(item);
                    break;
                }
            }
        }
    }        
}

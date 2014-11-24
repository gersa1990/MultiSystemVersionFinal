using MultiSystem.app.Financial.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSystem.app.Financial.CreatorWorkBook
{
    class CreatorReportByMonthly
    {
        private Microsoft.Office.Interop.Excel.Application excelApp;
        private Microsoft.Office.Interop.Excel.Workbook wbobj;
        private Microsoft.Office.Interop.Excel.Worksheet ws;
        private List<Ticket> listOfBills;
        private Dictionary<string, int> dictionaryGlobalServices = new Dictionary<string, int>();

        private string folioInicial = "";
        private string folioFinal   = "";
        private int totalServices = 0;
        private int totalAmount = 0;
        private Dictionary<int, int> dict = new Dictionary<int, int>();
        private Dictionary<int, string> dictNames = new Dictionary<int, string>();
        private Dictionary<int, string> _dictNames = new Dictionary<int, string>();
        private Dictionary<int, int> amounts = new Dictionary<int, int>();
        private Dictionary<int, string> folio = new Dictionary<int, string>();
        private Dictionary<string, int> dictServices = new Dictionary<string, int>();

        public CreatorReportByMonthly(List<Ticket> listOfBills)
        {
            this.listOfBills = listOfBills;
        }
    }
}

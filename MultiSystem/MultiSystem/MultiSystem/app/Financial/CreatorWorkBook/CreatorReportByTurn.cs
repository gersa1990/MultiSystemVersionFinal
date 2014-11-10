using Microsoft.Office.Interop.Excel;
using MultiSystem.app.Financial.Controllers;
using MultiSystem.app.Financial.Controllers.AdminController;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MultiSystem.app.Financial.CreatorWorkBook
{
    class CreatorReportByTurn
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

        public CreatorReportByTurn(List<Ticket> listOfBills)
        {
            this.listOfBills = listOfBills;
        }

        public CreatorReportByTurn createReportByTurn()
        {
            try
            {
                this.excelApp = new Microsoft.Office.Interop.Excel.Application();

                wbobj = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

                ws = (Worksheet)wbobj.Worksheets[1];
                this.createHeader();
                
                this.createTicketForAllServicesProvideds();
                this.createContainerText();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error al tratar de crear el archivo Excel. Reinstale Microsoft Office. " + e.ToString());
            }

            return this;
        }

        private void createTicketForAllServicesProvideds()
        {

            foreach (Ticket ticket in listOfBills) 
            {
                if (dict.ContainsKey(ticket.idServiceData))
                {
                    folioFinal = ticket.folio;
                    totalServices++;
                    folio[ticket.idServiceData] = ticket.folio;

                    dict[ticket.idServiceData]++;
                    if (ticket.type.Equals("AMBULANCIA"))
                    {
                        dictNames[ticket.idServiceData] += (",TRASLADO "+ticket.descriptionPrice ).ToUpper();
                    }
                    else if (ticket.type.Equals("LABORATORIO"))
                    {
                        dictNames[ticket.idServiceData] += (",ESTUDIOS " + ticket.descriptionPrice ).ToUpper();
                    }
                    else 
                    {
                        dictNames[ticket.idServiceData] += ("," + ticket.descriptionPrice).ToUpper();
                    }



                    if (ticket.amountWithDiscount != 0)
                    {
                        amounts[ticket.idServiceData] = ticket.amountWithDiscount + amounts[ticket.idServiceData];
                    }
                    else
                    {
                        amounts[ticket.idServiceData] += ticket.amountPrice + amounts[ticket.idServiceData];
                    }
                }
                else
                {
                    totalServices++;
                    dict[ticket.idServiceData] = 1;
                    folioInicial = ticket.folio;
                    folio[ticket.idServiceData] = ticket.folio;
                    
                    if (ticket.type.Equals("AMBULANCIA"))
                    {
                        dictNames[ticket.idServiceData] = (" TRASLADO " + ticket.descriptionPrice + "").ToUpper();
                    }
                    else if (ticket.type.Equals("LABORATORIO"))
                    {
                        dictNames[ticket.idServiceData] = (" ESTUDIOS " + ticket.descriptionPrice + "").ToUpper();
                    }
                    else
                    {
                        dictNames[ticket.idServiceData] = ("" + ticket.descriptionPrice + "").ToUpper();
                    }
      

                    if (ticket.amountWithDiscount != 0)
                    {
                        amounts[ticket.idServiceData] = ticket.amountWithDiscount;
                    }
                    else
                    {
                        amounts[ticket.idServiceData] = ticket.amountPrice;
                    }
                }
            }

            string[] ocurrences;
            Dictionary<string, string> dictionaryOcurrences = new Dictionary<string,string>();
            Dictionary<int, string> dictionaryOcurrencesClean = new Dictionary<int, string>(); ;

            string result = "";
            foreach (var item in dictNames) 
            {
                
                ocurrences = item.Value.Split(',');

                foreach(string ocurrence in ocurrences)
                {
                    if (!dictionaryOcurrences.ContainsKey(ocurrence+item.Key)) 
                    {
                        result = " ("+TextTool.CountStringOccurrences(item.Value, ocurrence)+") "+ocurrence+",";

                        if (dictServices.ContainsKey(ocurrence))
                        {
                            dictServices[ocurrence] += TextTool.CountStringOccurrences(item.Value, ocurrence);
                        }
                        else 
                        {
                            dictServices[ocurrence] = TextTool.CountStringOccurrences(item.Value, ocurrence);
                        }

                        dictionaryOcurrences[ocurrence + item.Key] = "parsed";
                        dictionaryOcurrencesClean[item.Key] = result;

                        result = "";
                    }
                }
            }


            int x = 8;
            int __total = 0;
            foreach (var item in dictServices)
            {
                excelApp.Cells[x, 13] = item.Key;
                excelApp.Cells[x, 14] = item.Value;
                __total += item.Value;

                x++;
            }

            excelApp.Cells[20, 14] = "TOTAL";
            excelApp.Cells[20, 15] = __total;

            int i = 6;
            
            foreach (var token in folio)
            {
                excelApp.Cells[i, 1] = token.Value;
                try
                {
                    excelApp.Cells[i, 2] = (dictionaryOcurrencesClean[token.Key] != null) ? dictionaryOcurrencesClean[token.Key] : "1";
                }
                catch 
                {
                    excelApp.Cells[i, 2] =  "1";
                }
                
                excelApp.Cells[i, 7] = amounts[token.Key].ToString("C");

                this.totalAmount += amounts[token.Key];
                
                i++;
                
            }
        }

       

        private void createContainerText()
        {
            excelApp.Cells[30, 7] = this.totalAmount.ToString("C");

            ws.Range["H1"].ColumnWidth = 8.14;
            ws.Range["I1"].ColumnWidth = 8.57;
            ws.Range["J1"].ColumnWidth = 5.71;
            ws.Range["K1"].ColumnWidth = 10.71;
            ws.Range["L1"].ColumnWidth = 5.14;
            ws.Range["M1"].ColumnWidth = 23.51;
            ws.Range["N1"].ColumnWidth = 9.00;
            ws.Range["O1"].ColumnWidth = 10.14;

            //Header
            ws.Range["H1:O1"].Merge();
            ws.Range["K2:M2"].Merge();

            //Turno
            ws.Range["I4:K4"].Merge();
            ws.Range["N4:O4"].Merge();

            excelApp.Cells[1, 8]    = "HOSPITAL INTEGRAL COMUNITARIO";
            excelApp.Cells[2, 11]   = "DE LA HUACANA, MICHOACÁN";
            excelApp.Cells[4, 8]    = "TURNO";
            excelApp.Cells[4, 9] = AdminSingleton.Singleton.getAdmin().typeAdmin;

            Range sheetRange = ws.get_Range("I4","K4");
            sheetRange.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

            ws.Range["H23:K23"].Merge();
            sheetRange = ws.get_Range("H23","K23");
            sheetRange.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

            ws.Range["M23:O23"].Merge();
            sheetRange = ws.get_Range("M23","O23");
            sheetRange.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;


            excelApp.Cells[4, 13] = "FECHA";
            sheetRange = ws.get_Range("N4", "O4");
            sheetRange.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

            excelApp.Cells[4, 14] =  DateTime.Now.Day + "-" + DateTime.Now.ToString("MM") + "" + "-" + DateTime.Now.Year ;

            sheetRange = ws.get_Range("H8", "K19");
            sheetRange.Borders.LineStyle = XlLineStyle.xlContinuous;

            sheetRange = ws.get_Range("M8", "O19");
            sheetRange.Borders.LineStyle = XlLineStyle.xlContinuous;


            excelApp.Cells[8, 8] = "FOLIO INICIAL";
            ws.Range["H8:H9"].Merge();

            ws.Range["I24:J24"].Merge();
            ws.Range["M24:O24"].Merge();
            ws.Range["M25:O25"].Merge();

            excelApp.Cells[24, 9] = "CAJERO";
            excelApp.Cells[24, 13] = "L. E IVAN ADAME ASCENCIO";
            excelApp.Cells[25, 13] = "ADMINISTRADOR";

            Range ad = ws.get_Range("H1");
            ad.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            ad = ws.get_Range("K2");
            ad.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            excelApp.Cells[8, 9] = "FOLIO FINAL";
            ws.Range["I8:I9"].Merge();

            ws.Range["H8"].Style.WrapText = true;
            ws.Range["I8"].Style.WrapText = true;
            ws.Range["J8"].Style.WrapText = true;
            ws.Range["K8"].Style.WrapText = true;

            excelApp.Cells[8, 10] = "TOTAL";

            //Folios
            excelApp.Cells[10, 8] = this.folioInicial;

            if (this.folioFinal.Equals(""))
            {
                this.folioFinal = this.folioInicial;
           }

            excelApp.Cells[10, 9] = this.folioFinal;
            excelApp.Cells[10, 10] = dict.Count;
            excelApp.Cells[10, 11] = this.totalAmount.ToString("C");
              
            ws.Range["J8:J9"].Merge();
            ws.Range["K8:K9"].Merge();
        }

        private void createHeader()
        {

            ws.Range["A1"].ColumnWidth = 9.29;
            ws.Range["B1"].ColumnWidth = 11.57;
            ws.Range["C1"].ColumnWidth = 15.00;
            ws.Range["D1"].ColumnWidth = 10.71;
            ws.Range["E1"].ColumnWidth = 10.71;
            ws.Range["F1"].ColumnWidth = 9.43;
            ws.Range["G1"].ColumnWidth = 15.00;

            for (int i = 6; i < 30; i++) 
            {
                ws.Range["A"+i].RowHeight = 15.00;
            }

            //Total resultado GDE

            excelApp.Cells[30, 6] = "TOTAL";
            

            Range sheetRange = ws.get_Range("A5", "G29");
            sheetRange.Borders.LineStyle = XlLineStyle.xlContinuous;

            excelApp.Cells[2, 2] = "HOSPITAL INTEGRAL COMUNITARIO DE LA HUACANA, MICHOACAN";
            excelApp.Cells[4, 2] = (DateTime.Now.ToString("dddd", new CultureInfo("es-MX")).ToUpper() + " " + DateTime.Now.Day + " DE " + DateTime.Now.ToString("MMMM", new CultureInfo("es-MX")).ToUpper() + "" + " DEL " + DateTime.Now.Year + "").ToUpper();

            Range ad = ws.get_Range("B4");
            ad.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Range tittles = ws.get_Range("A5","G35");
            tittles.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            excelApp.Cells[5, 1] = "FOLIO";
            excelApp.Cells[5, 2] = "DESCRIPCIÓN";
            excelApp.Cells[5, 7] = "MONTO";

            ws.Range["B2:F2"].Merge();
            ws.Range["B4:F4"].Merge();

            Range firmaCajero = ws.get_Range("A33", "C33");
            firmaCajero.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

            Range firmaAdmin = ws.get_Range("E33", "G33");
            firmaAdmin.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            
            //Bottom
            ws.Range["A33:C33"].Merge();
            ws.Range["E33:G33"].Merge();

            ws.Range["A34:C34"].Merge();
            ws.Range["E34:G34"].Merge();

            ws.Range["A35:C35"].Merge();
            ws.Range["E35:G35"].Merge();

            //Recibebottom
            excelApp.Cells[33, 5] = "L.E IVAN ADAME ASCENCIO";
            excelApp.Cells[34, 5] = "ADMINISTRADOR";
            excelApp.Cells[35, 5] = "RECIBE";

            //Cajero Bottom
            excelApp.Cells[23, 8] = (AdminSingleton.Singleton.getAdmin().nameAdmin + " " + AdminSingleton.Singleton.getAdmin().lastNameAdmin).ToUpper();
            excelApp.Cells[33, 1] = (AdminSingleton.Singleton.getAdmin().nameAdmin+" "+AdminSingleton.Singleton.getAdmin().lastNameAdmin).ToUpper();
            excelApp.Cells[34, 1] = "CAJERO";
            excelApp.Cells[35, 1] = "ENTREGA";

            for (int i = 5; i < 30; i++) 
            {
                ws.Range["B"+i+":F"+i+""].Merge();
            }

            var orientation = ws.PageSetup;
            orientation.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
        }

        public void setVisible()
        {
            excelApp.Visible = true;
        }

        public void save(string part)
        {
            try
            {
                wbobj.SaveAs(Directory.GetCurrentDirectory() + "_REPORTE_" + DateTime.Now.ToString("dddd", new CultureInfo("es-MX")).ToUpper() + "_" + DateTime.Now.Day + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + "_" +AdminSingleton.Singleton.getAdmin().nameAdmin + "_" + AdminSingleton.Singleton.getAdmin().typeAdmin + ".xlsx");
                excelApp.Visible = true;
                MessageBox.Show("El archivo se guardó satisfactoriamente en: " + Directory.GetCurrentDirectory());
            }
            catch (Exception e)
            {
                MessageBox.Show("Asegúrate de no tener abierto el archivo que estás tratando de generar. " + e.ToString());
            }
        }
    }
    public static class TextTool
    {
        /// <summary>
        /// Count occurrences of strings.
        /// </summary>
        public static int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }
    }
}

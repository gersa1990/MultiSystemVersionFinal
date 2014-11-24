using Microsoft.Office.Interop.Excel;
using MultiSystem.app.Financial.Controllers;
using MultiSystem.app.Financial.Controllers.AdminController;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace MultiSystem.app.Financial.Views.Controls
{
    class CreatorReportByMonth
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

        private Dictionary<int, string> dictPatients = new Dictionary<int, string>();
        private Dictionary<int, string> dictAddress  = new Dictionary<int, string>();
        private Dictionary<int, int> dictCanceled = new Dictionary<int, int>();
        private Dictionary<int, string> dictDiscount = new Dictionary<int, string>();

        //private Dictionary<int, string> _dictNames = new Dictionary<int, string>();
        private Dictionary<int, int> amounts = new Dictionary<int, int>();
        private Dictionary<int, string> folio = new Dictionary<int, string>();
        private Dictionary<string, int> dictServices = new Dictionary<string, int>();

        public CreatorReportByMonth(List<Ticket> listOfBills)
        {
            this.listOfBills = listOfBills;
        }

        public CreatorReportByMonth createReportByMonth()
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
            catch
            {
                MessageBox.Show("Error al tratar de crear el archivo Excel. Reinstale Microsoft Office. ");
            }

            return this;
        }

        private void createTicketForAllServicesProvideds()
        {

            foreach (Ticket ticket in listOfBills)
            {
                ticket.description();

                if (dict.ContainsKey(ticket.idServiceData))
                {
                    folioFinal = ticket.folio;
                    //totalServices++;
                    folio[ticket.idServiceData] = ticket.folio;

                    dict[ticket.idServiceData]++;
                    if (ticket.type.Equals("AMBULANCIA"))
                    {
                        dictNames[ticket.idServiceData] += (",TRASLADO " + ticket.descriptionPrice).ToUpper();
                    }
                    else if (ticket.type.Equals("LABORATORIO"))
                    {
                        dictNames[ticket.idServiceData] += (",ESTUDIOS " + ticket.descriptionPrice).ToUpper();
                    }
                    else
                    {
                        dictNames[ticket.idServiceData] += ("," + ticket.descriptionPrice).ToUpper();
                    }

                    //Reporte mensual
                    dictPatients[ticket.idServiceData] = ticket.namePatien + " " + ticket.lastNamePatient;
                    dictAddress[ticket.idServiceData] = ticket.adressPatient;
                    dictCanceled[ticket.idServiceData] = ticket.serviceCanceled;
                    dictDiscount[ticket.idServiceData]= ticket.reasonDiscount;
                    //Reporte mensual

                    if (ticket.amountWithDiscount != 0)
                    {
                        amounts[ticket.idServiceData] = ticket.amountWithDiscount + amounts[ticket.idServiceData];
                    }
                    else
                    {
                        amounts[ticket.idServiceData] += ticket.amountPrice + amounts[ticket.idServiceData];
                    }

                    if (ticket.serviceCanceled != 0)
                    {
                        amounts[ticket.idServiceData] = 0;
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

                    if (ticket.serviceCanceled != 0) 
                    {
                        amounts[ticket.idServiceData] = 0;
                    }

                    //Reporte mensual
                    dictPatients[ticket.idServiceData] = ticket.namePatien + " " + ticket.lastNamePatient;
                    dictAddress[ticket.idServiceData] = ticket.adressPatient;
                    dictCanceled[ticket.idServiceData] = ticket.serviceCanceled;
                    dictDiscount[ticket.idServiceData]= ticket.reasonDiscount;
                    //Reporte mensual
                }
            }

            string[] ocurrences;
            Dictionary<string, string> dictionaryOcurrences = new Dictionary<string, string>();
            Dictionary<int, string> dictionaryOcurrencesClean = new Dictionary<int, string>(); ;

            string result = "";
            foreach (var item in dictNames)
            {
                ocurrences = item.Value.Split(',');

                foreach (string ocurrence in ocurrences)
                {

                    if (!dictionaryOcurrences.ContainsKey(ocurrence + item.Key))
                    {
                        result = " (" + TextTool.CountStringOccurrences(item.Value, ocurrence) + ") " + ocurrence + ",";

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


            /*int x = 8;
            int __total = 0;
            foreach (var item in dictServices)
            {
                excelApp.Cells[x, 13] = item.Key;
                excelApp.Cells[x, 14] = item.Value;
                __total += item.Value;

                x++;
            }*/

            //excelApp.Cells[20, 14] = "TOTAL";
            //excelApp.Cells[20, 15] = __total;

            int i = 5;

            foreach (var token in folio)
            {
                excelApp.Cells[i, 1] = token.Value;

                try
                {
                    excelApp.Cells[i, 4] = (dictionaryOcurrencesClean[token.Key] != null) ? dictionaryOcurrencesClean[token.Key] : "1";
                    excelApp.Cells[i, 2] = dictPatients[token.Key];
                    excelApp.Cells[i, 3] = dictAddress[token.Key];

                    if (dictCanceled[token.Key] != 0) 
                    {
                        excelApp.Cells[i, 6] = dictDiscount[token.Key].ToUpper();
                    }
                }
                catch
                {
                    excelApp.Cells[i, 4] = "1";
                    excelApp.Cells[i, 2] = dictPatients[token.Key];
                    excelApp.Cells[i, 3] = dictAddress[token.Key];

                    if (dictCanceled[token.Key] != 0)
                    {
                        excelApp.Cells[i, 6] = dictDiscount[token.Key].ToUpper();
                    }
                }

                excelApp.Cells[i, 5] = amounts[token.Key].ToString("C");

                this.totalAmount += amounts[token.Key];

                i++;

            }
        }



        private void createContainerText()
        {
            totalServices = totalServices + 4;
            int totalServicesAux = totalServices + 2;
            string final = "F"+totalServices;
            string finalAmount = "F" + totalServicesAux;

            Range sheetRange = ws.get_Range("A4", final);
            sheetRange.Borders.LineStyle = XlLineStyle.xlContinuous;

            Range tittles = ws.get_Range("A4", final);
            tittles.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            excelApp.Cells[ totalServicesAux, 4] = "TOTAL: "+(this.totalAmount.ToString("C"));
        }

        private void createHeader()
        {

            ws.Range["A1"].ColumnWidth = 12.71;
            ws.Range["B1"].ColumnWidth = 40.43;
            ws.Range["C1"].ColumnWidth = 32.00;
            ws.Range["D1"].ColumnWidth = 45.00;
            ws.Range["E1"].ColumnWidth = 12.86;
            ws.Range["F1"].ColumnWidth = 10.86;
           
            

            excelApp.Cells[1, 1] = "HOSPITAL INTEGRAL COMUNITARIO DE LA HUACANA, MICHOACAN";
            excelApp.Cells[2, 2] = "REPORTE MENSUAL";

            excelApp.Cells[2, 4] = "Fecha: "+(DateTime.Now.ToString("dddd", new CultureInfo("es-MX")).ToUpper() + " " + DateTime.Now.Day + " DE " + DateTime.Now.ToString("MMMM", new CultureInfo("es-MX")).ToUpper() + "" + " DEL " + DateTime.Now.Year + "").ToUpper();

            Range ad = ws.get_Range("A1");
            ad.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            

            excelApp.Cells[4, 1] = "FOLIO";
            excelApp.Cells[4, 2] = "NOMBRE";
            excelApp.Cells[4, 3] = "DIRECCIÓN";
            excelApp.Cells[4, 4] = "CONCEPTO";
            excelApp.Cells[4, 5] = "PRECIO";
            excelApp.Cells[4, 6] = "CANCELADO";

            ws.Range["A1:E1"].Merge();

            var orientation = ws.PageSetup;
            orientation.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
        }

        public void save()
        {
            try
            {
                wbobj.SaveAs(Directory.GetCurrentDirectory() + "_REPORTE_MENSUAL_" + DateTime.Now.ToString("dddd", new CultureInfo("es-MX")).ToUpper() + "_" + DateTime.Now.Day + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + "_" + AdminSingleton.Singleton.getAdmin().nameAdmin + "_" + AdminSingleton.Singleton.getAdmin().typeAdmin + ".xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8);
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
            if (!pattern.Equals("")) 
            {
                while ((i = text.IndexOf(pattern, i)) != -1)
                {
                    i += pattern.Length;
                    count++;
                }
            }

            return count;
        }
    }
}

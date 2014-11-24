using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MultiSystem.app.Financial.Controllers.Receipt
{
    public class Receipter
    {
        private Microsoft.Office.Interop.Excel.Application excelApp;
        private Workbook wbobj;
        private Worksheet ws;

        private List<Bill> listOfBillsAdded;
        private Patient patient;
        private int totalAmount = 0;


        public Receipter() 
        {
            
        }

        public Receipter(List<Bill> listOfBillsAdded, Patient patient)
        {
            this.listOfBillsAdded = listOfBillsAdded;
            this.patient = patient;
        }

        public Receipter createReceipt()
        {
            try
            {
                this.excelApp = new Microsoft.Office.Interop.Excel.Application();

                wbobj = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

                ws = (Worksheet)wbobj.Worksheets[1];
                this.createHeader();
                this.createContainerText();
                this.createTicketForAllServicesProvideds();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error al tratar de crear el archivo Excel. Reinstale Microsoft Office. " + e.ToString());
            }

            return this;
        }

        private void createTicketForAllServicesProvideds() 
        {
            
            Dictionary<string, int> dict = new Dictionary <string, int>();
            Dictionary<string, string> dictNames = new Dictionary<string, string>();

            bool isTicketCanceled = false;
            string reasonCanceled = "";

            foreach(Bill bill in this.listOfBillsAdded)
            {
                if (bill.serviceCanceled == 1) 
                {
                    isTicketCanceled = true;
                    reasonCanceled = bill.reasonDiscount;
                }

                if (dict.ContainsKey(bill.keyPrice))
                {
                    dict[bill.keyPrice]++;
                    dictNames[bill.keyPrice] = bill.descriptionPrice;

                    if (!bill.reasonDiscount.Equals(""))
                    {
                        this.totalAmount += bill.amountWithDiscount;
                    }
                    else 
                    {
                        this.totalAmount += bill.amountPrice;
                    }
                }
                else 
                {
                    dict[bill.keyPrice] = 1;
                    dictNames[bill.keyPrice] = bill.descriptionPrice;

                    if (!bill.reasonDiscount.Equals(""))
                    {
                        this.totalAmount += bill.amountWithDiscount;
                    }
                    else
                    {
                        this.totalAmount += bill.amountPrice;
                    }
                }
            }

            

            excelApp.Cells[25, 9] = "$"+this.totalAmount+".00";

            if (isTicketCanceled) 
            {
                excelApp.Cells[25, 9] = "SERVICIO CANCELADO POR "+reasonCanceled;
            }

            excelApp.Cells[27, 7] = this.NumberToWords(this.totalAmount)+" 00/100 mn";

            int i = 1;
            int services = 0;

            foreach(var token in dict)
            {
                if (i <= 5) 
                {

                    string s = token.Key;
                    services = token.Value;

                    string list = dictNames[token.Key];

                    switch (i) 
                    {
                        case 1:

                            for (int j = 0; j < s.Length ; j++)
                            {
                                excelApp.Cells[14, j + 2] = s[j].ToString();
                            }

                            excelApp.Cells[14, 8] = " ("+services + ") " + list;
                        break;

                        case 2:
                            for (int j = 0; j < s.Length; j++)
                            {
                                excelApp.Cells[16, j + 2] = s[j].ToString();
                            }
                            excelApp.Cells[16, 8] = " (" + services + ") " + list;
                        break;

                        case 3:
                            for (int j = 0; j < s.Length; j++)
                            {
                                excelApp.Cells[18, j + 2] = s[j].ToString();
                            }
                            excelApp.Cells[18, 8] = " (" + services + ") " + list;
                        break;

                        case 4:
                            for (int j = 0; j < s.Length; j++)
                            {
                                excelApp.Cells[20, j + 2] = s[j].ToString();
                            }
                            excelApp.Cells[20, 8] = " (" + services + ") " + list;
                        break;

                        case 5:
                            for (int j = 0; j < s.Length; j++)
                            {
                                excelApp.Cells[22, j + 2] = s[j].ToString();
                            }
                            excelApp.Cells[22, 8] = " (" + services + ") " + list;
                        break;
                    }
                }

                i++;
            }
        }

        private string NumberToWords(int number)
        {
            if (number == 0)
                return "cero";

            if (number < 0)
                return "menos " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " millón ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " mil ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " cientos ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "y ";

                var unitsMap = new[] { "cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez", "once", "doce", "trece", "catorce", "quince", "dieciseis", "dieci siete", "dieci ocho", "dieci nueve" };
                var tensMap = new[] { "cero", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        private void createContainerText() 
        {
            excelApp.Cells[1, 12] = this.patient.folioPatient;

            string[] a = this.patient.dateService.Select(c => c.ToString()).ToArray();

            for (int i = 0; i < a.Length ; i++)
            {
                switch (i) 
                {
                    case 2:
                        excelApp.Cells[5, 14] = a[i];
                    break;
                    
                    case 3:
                    excelApp.Cells[5, 15] = a[i];
                    break;

                    case 5:
                    excelApp.Cells[5, 12] = a[i];
                    break;

                    case 6:
                    excelApp.Cells[5, 13] = a[i];
                    break;

                    case 8:
                    excelApp.Cells[5, 10] = a[i];
                    break;

                    case 9:
                    excelApp.Cells[5, 11] = a[i];
                    break;
                }
            }

            excelApp.Cells[8, 8] = this.patient.namePatient.ToUpper();
            excelApp.Cells[9, 8] = this.patient.lastNamePatient.ToUpper();

    

            if (this.patient.adressPatient.Length > 30)
            {
                string aux1 = "";
                string aux2 = "";
                string[] array = this.patient.adressPatient.Split(' ');

                foreach (string word in array) 
                {
                    if (aux1.Length <= 30)
                    {
                        aux1 += word + " ";
                    }
                    else 
                    {
                        aux2 += word + " ";
                    }
                }

                excelApp.Cells[11, 8] = aux1.ToUpper();
                excelApp.Cells[12, 8] = aux2.ToUpper();
                
            }
            else
            {
                excelApp.Cells[11, 8] = this.patient.adressPatient.ToUpper();
            }
        }

        private void createHeader() 
        {
            ws.Range["B1"].ColumnWidth = 2.57;
            ws.Range["C1"].ColumnWidth = 2.57;
            ws.Range["D1"].ColumnWidth = 2.57;
            ws.Range["E1"].ColumnWidth = 2.57;
            ws.Range["F1"].ColumnWidth = 2.57;
            ws.Range["G1"].ColumnWidth = 2.57;

            ws.Range["H1"].ColumnWidth = 9.29;

            ws.Range["I1"].ColumnWidth = 2.57;
            ws.Range["J1"].ColumnWidth = 2.57;
            ws.Range["K1"].ColumnWidth = 2.57;
            ws.Range["L1"].ColumnWidth = 2.57;
            ws.Range["M1"].ColumnWidth = 2.57;
            ws.Range["N1"].ColumnWidth = 2.57;
            ws.Range["O1"].ColumnWidth = 2.57;

            //Folio
            ws.Range["L1:O1"].Merge();
            

            //Nombre
            ws.Range["H8:O8"].Merge(); 
            ws.Range["H9:O9"].Merge();

            //Domicilio
            ws.Range["H11:O11"].Merge();
            ws.Range["H12:O12"].Merge();

            //Servicio 1
            ws.Range["H14:O14"].Merge();
            //Servicio 2
            ws.Range["H16:O16"].Merge();
            //Servicio 3
            ws.Range["H18:O18"].Merge();
            //Servicio 4
            ws.Range["H20:O20"].Merge();
            //Servicio 5
            ws.Range["H22:O22"].Merge();

            //Total in number format
            ws.Range["I25:O25"].Merge();

            //Total in format letters
            ws.Range["G27:O27"].Merge();

            var orientation = ws.PageSetup;
            orientation.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;

            ws.PageSetup.TopMargin = 0.0f;
        }

        public void setVisible()
        {
            excelApp.Visible = true;
        }

        public void save()
        {
            MessageBox.Show("El archivo se guardó satisfactoriamente en: " + Directory.GetCurrentDirectory());
            
            try
            {
                wbobj.SaveAs(Directory.GetCurrentDirectory() + "_RECIBO_" + DateTime.Now.ToString("dddd", new CultureInfo("es-MX")).ToUpper() + "_" + DateTime.Now.Day + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + "_" + patient.namePatient + "_" + patient.lastNamePatient + ".xlsx");
                excelApp.Visible = true;
               
            }
            catch (Exception e)
            {
                MessageBox.Show("Asegúrate de no tener abierto el archivo que estás tratando de generar. " + e.ToString());
            }
        }
    }
}

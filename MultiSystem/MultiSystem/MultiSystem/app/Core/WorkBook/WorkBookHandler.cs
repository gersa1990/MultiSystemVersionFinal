using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Windows;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;
using System.Globalization;
using MultiSystem.app.Library.Controllers;
using System.Drawing;
using System.Diagnostics;

namespace MultiSystem.app.Core.WorkBook
{
    class WorkBookHandler
    {
        private Microsoft.Office.Interop.Excel.Application excelApp;
        private Microsoft.Office.Interop.Excel.Workbook wbobj;
        private Microsoft.Office.Interop.Excel.Worksheet ws;
        

        public WorkBookHandler() 
        {

        }

        public WorkBookHandler(bool createTittle, bool createSubtittle) 
        {
            
        }

        private void createHeader(string[] headerColumns)
        {
            Range sheetRange = ws.get_Range("A1", "I27");
            sheetRange.Borders.LineStyle = XlLineStyle.xlContinuous;

            Range headerRange = ws.get_Range("A1","I1");
            headerRange.Style.Font.Size = 60;
            headerRange.Style.Font.Bold = true;

            
            excelApp.Cells[1, 2] = "HOSPITAL INTEGRAL COMUNITARIO DE LA HUACANA";

            excelApp.Cells[1, 2].Style.HorizontalAlignment = HorizontalAlignment.Center;
            excelApp.Cells[1, 3].Style.HorizontalAlignment = HorizontalAlignment.Center;
            excelApp.Cells[1, 4].Style.HorizontalAlignment = HorizontalAlignment.Center;
            excelApp.Cells[1, 5].Style.HorizontalAlignment = HorizontalAlignment.Center;
            excelApp.Cells[1, 6].Style.HorizontalAlignment = HorizontalAlignment.Center;
            excelApp.Cells[1, 7].Style.HorizontalAlignment = HorizontalAlignment.Center;
            excelApp.Cells[1, 8].Style.HorizontalAlignment = HorizontalAlignment.Center;
            excelApp.Cells[1, 9].Style.HorizontalAlignment = HorizontalAlignment.Center;
            
            excelApp.Cells[2, 2] = "BIBLIOTECA";

            ws.Range["A1:I1"].Merge();
            ws.Range["A2:I2"].Merge();
            ws.Range["E4:F4"].Merge();

            excelApp.Cells[1, 2].Style.HorizontalAlignment = HorizontalAlignment.Center;
            excelApp.Cells[1, 3].Style.HorizontalAlignment = HorizontalAlignment.Center;
            excelApp.Cells[1, 4].Style.HorizontalAlignment = HorizontalAlignment.Center;
            excelApp.Cells[1, 5].Style.HorizontalAlignment = HorizontalAlignment.Center;
            excelApp.Cells[1, 6].Style.HorizontalAlignment = HorizontalAlignment.Center;
            excelApp.Cells[1, 7].Style.HorizontalAlignment = HorizontalAlignment.Center;
            excelApp.Cells[1, 8].Style.HorizontalAlignment = HorizontalAlignment.Center;
            excelApp.Cells[1, 9].Style.HorizontalAlignment = HorizontalAlignment.Center;

            Range ad = ws.get_Range("A1");
            ad.HorizontalAlignment = HorizontalAlignment.Right;

            Range subtittle = ws.get_Range("A2", "I2");
            subtittle.Style.Font.Size = 12;
            subtittle.Style.Font.Bold = true;

            ws.Range["B1"].Style.HorizontalAlignment = HorizontalAlignment.Center;
            ws.Range["B2"].Style.HorizontalAlignment = HorizontalAlignment.Center;


            ws.Range["A4"].ColumnWidth = 3.88;
            ws.Range["B4"].ColumnWidth = 7.88;
            ws.Range["C4"].ColumnWidth = 22.50;
            ws.Range["D4"].ColumnWidth = 22.50;
            ws.Range["E4"].ColumnWidth = 9.50;
            ws.Range["F4"].ColumnWidth = 9.50;
            ws.Range["G4"].ColumnWidth = 10.38;
            ws.Range["H4"].ColumnWidth = 10.38;
            
            
            ws.Range["A4"].Style.WrapText = true;
            ws.Range["C4"].Style.WrapText = true;
            ws.Range["D4"].Style.WrapText = true;
            ws.Range["E4"].Style.WrapText = true;
            ws.Range["F4"].Style.WrapText = true;
            ws.Range["G4"].Style.WrapText = true;
            ws.Range["H4"].Style.WrapText = true;
            ws.Range["I4"].Style.WrapText = true;

            int i = 1;

            foreach (var header in headerColumns) 
            {
                string aux = "";
                switch (header) 
                {
                       
                    case "fecha de entrega":
                        aux = "fecha de \n Entrega";
                    break;

                    default:
                    aux = header;
                    break;
                }

                
                ws.Cells[4, i] = aux.ToString();
                i++;
            }
        }

        private void createContainer(List<LoanBook> rows) 
        {
            int cellIndicator = 5;

            foreach (var token in rows) 
            {
                excelApp.Cells[cellIndicator, 1] = cellIndicator-4; 
                excelApp.Cells[cellIndicator, 2] = token.hashLoan.ToString();
                excelApp.Cells[cellIndicator, 3] = token.nameBook;
                excelApp.Cells[cellIndicator, 4] = token.nameReader;
                excelApp.Cells[cellIndicator, 5] = token.hourLoan;
                excelApp.Cells[cellIndicator, 6] = (!token.hourDeliveryLoan.Equals("00:00")) ? token.hourDeliveryLoan : "";
                excelApp.Cells[cellIndicator, 7] = "Matutino";
                excelApp.Cells[cellIndicator, 8] = (!token.dateLoan.Equals("0000-00-00")) ? token.dateLoan : "";
                excelApp.Cells[cellIndicator, 9] = (!token.dateDeliveryLoan.Equals("0000-00-00")) ? token.dateDeliveryLoan : "";

                cellIndicator++;
            }

           var orientation =  ws.PageSetup;
           orientation.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
        }

        public WorkBookHandler createDocumentWithColumsAndRows(string[] header, List<LoanBook> rows) 
        {
            try
            {
                this.excelApp = new Microsoft.Office.Interop.Excel.Application();

                wbobj = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

                ws = (Worksheet)wbobj.Worksheets[1];
                this.createHeader(header);
                this.createContainer(rows);
            }
            catch(Exception e) 
            {
                MessageBox.Show("Error al tratar de crear el archivo Excel. Reinstale Microsoft Office. "+e.ToString());
            }

            return this;
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
                wbobj.SaveAs(Directory.GetCurrentDirectory() + "_BIBLIOTECA_" + DateTime.Now.ToString("dddd", new CultureInfo("es-MX")).ToUpper() +"_"+DateTime.Now.Day+"_"+ DateTime.Now.Year + "_" + DateTime.Now.ToString("MMMM", new CultureInfo("es-MX")).ToUpper() + "_" + ".xlsx");
                excelApp.Visible = true;
            }
            catch(Exception e)
            {
                MessageBox.Show("Asegúrate de no tener abierto el archivo que estás tratando de generar. "+e.ToString());
            }
            
        }

        public void close() 
        {
            wbobj.Close();
        }
    }
}

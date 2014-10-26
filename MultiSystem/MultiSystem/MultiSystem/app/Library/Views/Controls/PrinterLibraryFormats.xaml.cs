using System;
using System.Data;
using System.Windows.Controls;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows;
using System.Reflection;
using MultiSystem.app.Core.WorkBook;
using System.Text;
using System.Collections.Generic;
using MultiSystem.app.Library.Controllers;
using MultiSystem.app.Library.Views.PopUp;
using System.Threading;


namespace MultiSystem.app.Library.Views.Controls
{
    /// <summary>
    /// Interaction logic for PrinterLibraryFormats.xaml
    /// </summary>
    public partial class PrinterLibraryFormats : UserControl
    {

        private WorkBookHandler excelHandler;
        private BookController controllerBook; 
		private PopUpCustom popUpCustom;
       
        public PrinterLibraryFormats()
        {
            InitializeComponent();
            controllerBook = new BookController();
			popUpCustom = new PopUpCustom();
        }


        private void test(List<LoanBook> rows)
        {
            excelHandler = new WorkBookHandler(); 

            string[] headerStrings = { "No.","Folio","Nombre del libro","Solicitado por","Horario","Horario salida","Turno","Fecha de solicitud","Fecha de entrega"};

            excelHandler.createDocumentWithColumsAndRows(headerStrings, rows).save();

            MessageBox.Show("Por tu seguridad y la de todos los que laboran en esta institución. \n Tu sesión será cerrada cada vez que generes tu reporte.");
            Application.Current.Shutdown();
            Thread.Sleep(1000);
            System.Windows.Forms.Application.Restart();

        }
       

        private void printFormat(object sender, System.Windows.RoutedEventArgs e)
        {
			string dateTime = datePickerPrinter.Text;
			
			if(!dateTime.Equals(""))
			{
				string[] serialized = dateTime.Split('/');
				List<LoanBook> rows = controllerBook.getLoanedsBook(serialized[2]+"-"+serialized[1]+"-"+serialized[0]);

                if (rows == null)
                {
                    try 
                    {
                        popUpCustom.setDataForAlert("Sin libros", "No existen registros en esta fecha.", typeOfAlertEnum.warning);
                        popUpCustom.Show();
                    }
                    catch(Exception exc)
                    {
                        MessageBox.Show("No existen registros en esta fecha.");

                    }
                    finally
                    {

                    }
                   
                }
                else 
                {
                    try 
                    {
                        if (rows.Count > 0)
                        {
                            this.test(rows);
                        }
                        else
                        {
                            popUpCustom.setDataForAlert("Sin libros", "No existen registros en esta fecha.", typeOfAlertEnum.warning);
                            popUpCustom.Show();
                        }
                    }
                    catch
                    {
                        popUpCustom.setDataForAlert("Sin libros", "No existen registros en esta fecha.", typeOfAlertEnum.warning);
                        popUpCustom.Show();
                    }
                }
                
			}
			else
			{
				popUpCustom.setDataForAlert("Error","Debes seleccionar una fecha",typeOfAlertEnum.error);
				popUpCustom.Show();
			}
			//this.test(controllerBook.getLoanedsBook("2014-08-02"));
        }
    }
}

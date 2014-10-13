using MultiSystem.app.Core.System.Screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Globalization;
using System.Windows.Forms;

namespace MultiSystem.app.Financial.Views.Main
{
    /// <summary>
    /// Interaction logic for HomeFinancialView.xaml
    /// </summary>
    public partial class HomeFinancialView : Window
    {
        private List<Dictionary<string, string>> admin;
        private Screener screen;
  		static  Timer myTimer = new Timer();
        private int idAdmin;

        public HomeFinancialView(List<Dictionary<string, string>> admin)
        {
            screen = new Screener();

            this.Width = this.MinWidth = screen.fullWidth;
            this.Height = this.MinHeight = screen.fullHeight + 25;

            this.admin = admin;
			
			myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 1000;
            myTimer.Start();
			
            this.InitializeComponent();
			this.customizeWindow();
        }
	
		private void customizeWindow()
		{
            string welcome = "BIENVENIDO: ";

			foreach(var _admin in this.admin)
			{
				foreach(var token in _admin)
				{
                    switch (token.Key) 
                    {
                        case "nameAdmin":
                        welcome += " "+token.Value+" ".ToUpper();
                        break;

                        case "lastNameAdmin":
                        welcome += " "+token.Value+" ".ToUpper();
                        break;

                        case "typeAdmin":
                        welcome += " "+token.Value+" ".ToUpper();
                        break;

                        case "idAdmin":
                        this.idAdmin = int.Parse(token.Value);
                        break;
                    }
				}
			}

            nameAdmin.Content = welcome.ToUpper();
		}
		
		private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            clockBottom2.Content = DateTime.Now.ToString("dddd", new CultureInfo("es-MX")).ToUpper() +" "+ DateTime.Now.Day +" DE "+ DateTime.Now.ToString("MMMM", new CultureInfo("es-MX")).ToUpper() + "" + " DEL " + DateTime.Now.Year + ", SON LAS: " +string.Format("{0:hh:mm:ss tt}", DateTime.Now);   
        }
    }
}

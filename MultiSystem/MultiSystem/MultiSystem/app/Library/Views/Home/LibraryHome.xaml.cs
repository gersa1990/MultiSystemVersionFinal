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
using System.Drawing;
using MultiSystem.app.Core.System.Screen;
using MultiSystem.app.Library.Views.Controls;
using System.Globalization;
using MultiSystem.app.Financial.Controllers.AdminController;


namespace MultiSystem.app.Biblioteca.Views
{
    /// <summary>
    /// Interaction logic for LibraryHome.xaml
    /// </summary>
    public partial class LibraryHome : Window
    {
        private AddBook formAddBook = new AddBook();
        public List<Dictionary<string, string>> userData;
        public List<Dictionary<string, string>> size;
        Screener screen = new Screener();

        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        public LibraryHome(List<Dictionary<string, string>> parameters)
        {
            InitializeComponent();

			this.Width  = this.MinWidth   = screen.fullWidth;
			this.Height = this.MinHeight = screen.fullHeight+25;
            this.userData = parameters;
            
            this.editHomeVisual();

            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 1000;
            myTimer.Start();
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            clockBottom.Content = DateTime.Now.ToString("dddd", new CultureInfo("es-MX")).ToUpper() +" "+ DateTime.Now.Day +" DE "+ DateTime.Now.ToString("MMMM", new CultureInfo("es-MX")).ToUpper() + "" + " DEL " + DateTime.Now.Year + ", SON LAS: " +string.Format("{0:hh:mm:ss tt}", DateTime.Now);   
        }
        
        public LibraryHome()
        {
            this.editHomeVisual();
        }

        private void editHomeVisual()
        {   
        
            rectangleTop.Width = screen.fullWidth;
            rectangleBottom.Width = screen.fullWidth;
            

            Admin admin = new Admin();

            foreach(var item in this.userData)
            {
                foreach (var field in item) 
                {
                   
                    switch (field.Key) 
                    {
                        case "idAdmin":
                            admin.idAdmin = int.Parse(field.Value);
                        break;

                        case "userNameAdmin":
                            admin.userAdmin = field.Value;
                        break;

                        case "turnAdmin":
                            admin.workingHours = field.Value;
                        break;

                        case "passAdmin":
                            admin.passwordAdmin = field.Value;
                        break;

                        case "nameAdmin": 
                        {
                            admin.nameAdmin = field.Value;
                            nameAdmin.Content = (""+field.Value+"").ToUpper();
                        }
                        break;

                        case "lastNameAdmin":
                        {
                            admin.lastNameAdmin = field.Value;
                            nameAdmin.Content += (" "+field.Value+"").ToUpper();
                        }
                        break;

                        case "descriptionAdmin":
                        {
                            admin.typeAdmin = field.Value;
                            nameAdmin.Content += (", " + field.Value + "").ToUpper();
                        }
                        break; 
                    }
                }

                AdminSingleton.Singleton.saveAdmin(admin);
            }
        }

        private void controlMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             
        }
    }
}

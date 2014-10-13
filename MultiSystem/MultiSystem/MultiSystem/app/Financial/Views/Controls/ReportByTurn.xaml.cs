﻿using MultiSystem.app.Core.System.Screen;
using MultiSystem.app.Financial.Controllers;
using MultiSystem.app.Financial.Controllers.AdminController;
using MultiSystem.app.Financial.Controllers.BillingController;
using MultiSystem.app.Financial.CreatorWorkBook;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultiSystem.app.Financial.Views.Controls
{
    /// <summary>
    /// Interaction logic for ReportByTurn.xaml
    /// </summary>
    public partial class ReportByTurn : UserControl
    {

        private BillingController billingController;
        private List<Ticket> listOfBills;
        private List<Ticket> listOfTickets = new List<Ticket>();
        private Screener screen;

        public ReportByTurn()
        {
            InitializeComponent();
            billingController = new BillingController();
            listOfBills = new List<Ticket>();
            this.getAsyncronusTickets();
            screen = new Screener();
            this.Width = this.MinWidth = screen.fullWidth - 190;
            this.Height = this.MinHeight = screen.fullHeight - 130;
        }

        public void getAsyncronusTickets() 
        {
            try
            {
                listOfBills = billingController.getBillingForAdminID(AdminSingleton.Singleton.getAdmin().idAdmin);
            }
            catch 
            {
                Console.WriteLine("Error al tratar de obtener los registros del día.");
            }
        }

        private void generateReport(object sender, RoutedEventArgs e)
        {
            this.getAsyncronusTickets();
            Dictionary<int, int> dict = new Dictionary<int, int>();

            

            int i = 0;
            int aux = 0;
            int parte = 1;

            if (listOfBills != null)
            {
                foreach (Ticket ticket in listOfBills)
                {
                    if (dict.ContainsKey(ticket.idServiceData))
                    {
                        aux++;
                        Console.WriteLine("i : " + i + " aux: " + aux);

                        listOfTickets.Add(ticket);
                        dict[ticket.idServiceData]++;

                        if (aux == listOfBills.Count)
                        {
                            CreatorReportByTurn creator = new CreatorReportByTurn(listOfTickets);
                            creator.createReportByTurn().save("PARTE_1");

                            listOfTickets = new List<Ticket>();
                        }
                    }
                    else
                    {
                        i++;
                        aux++;
                        listOfTickets.Add(ticket);

                        dict[ticket.idServiceData] = 1;

                        if (aux % 24 == 0)
                        {
                            CreatorReportByTurn creator = new CreatorReportByTurn(listOfTickets);
                            creator.createReportByTurn().save("PARTE_" + parte);
                            parte++;

                            listOfTickets = new List<Ticket>();
                        }
                        else
                        {
                            if (aux == listOfBills.Count)
                            {
                                CreatorReportByTurn creator = new CreatorReportByTurn(listOfTickets);
                                creator.createReportByTurn().save("PARTE_1");
                                listOfTickets = new List<Ticket>();
                            }
                        }
                    }
                }
            }
            else 
            {
                MessageBox.Show("No existen registros para generar el reporte.");
            }
               
        }
    }
}

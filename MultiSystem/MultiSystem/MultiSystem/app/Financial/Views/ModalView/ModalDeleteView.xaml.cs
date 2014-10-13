using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MultiSystem.app.Financial.View.ModalView
{
	/// <summary>
	/// Interaction logic for ModalDeleteView.xaml
	/// </summary>
	public partial class ModalDeleteView : Window
	{
        private Views.Controls.RegisterService registerService;
        private Controllers.Bill bill;

        public ModalDeleteView(Views.Controls.RegisterService registerService, Controllers.Bill bill)
        {
            this.registerService = registerService;
            this.bill = bill;
			this.InitializeComponent();
			this.customizeWindow();
        }
		
		private void customizeWindow()
		{
			tittleService.Content = "SE ELIMINARÁ EL SERVICIO: "+bill.keyPrice;
			
			containerText.Text = ("ESTÁ SEGURO QUE DESEA ELIMINAR EL SERVICIO: "+bill.descriptionPrice+", para este cliente? ").ToUpper();
		}

		private void deleteServiceAction(object sender, System.Windows.RoutedEventArgs e)
		{
            registerService.performanceDeleteService(bill);
            this.Close();
		}

		private void cancelDeleteAction(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
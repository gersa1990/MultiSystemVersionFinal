using MultiSystem.app.Financial.Controllers;
using MultiSystem.app.Financial.Views.Controls;
using MultiSystem.app.Library.Views.Controls;
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
	/// Interaction logic for ModalEditView.xaml
	/// </summary>
	public partial class ModalEditView : Window
	{
        private RegisterService registerService;
        private Bill bill;
        private EditorServices editorServices;
        private bool isHandlered = false;
        

        public ModalEditView(RegisterService registerService, Bill bill)
        {
            this.registerService = registerService;
            this.bill = bill;
            this.InitializeComponent();
			this.customizeWindow();
			this.createDiscountEdited(null,null);
        }

        public ModalEditView(EditorServices editorServices, Bill bill)
        {
            // TODO: Complete member initialization
            this.editorServices = editorServices;
            this.bill = bill;
            this.InitializeComponent();
            this.customizeWindow();
            this.createDiscountEdited(null, null);
            this.isHandlered = true;
        }
		
		private void customizeWindow()
		{
			tittleEditBill.Content = "SE EDITARÁ EL SERVICIO: "+bill.keyPrice;
			nameService.Content = "Nombre: "+bill.descriptionPrice+"\n "+" Tipo: "+bill.type;
		
			if(bill.amountWithDiscount != 0)
			{
				switchDiscount.IsChecked =  true;
				motiveDiscount.Text = bill.reasonDiscount;
				amountDiscount.Text = bill.amountWithDiscount+"";
			}
		}

		private void createDiscountEdited(object sender, System.Windows.RoutedEventArgs e)
		{
			if(switchDiscount.IsChecked == true)
			{
                labelMotiveDiscount.Visibility = Visibility.Visible;
                motiveDiscount.Visibility = Visibility.Visible;
                labelAmountDiscount.Visibility = Visibility.Visible;
                amountDiscount.Visibility = Visibility.Visible;
			}
			else
			{
                labelMotiveDiscount.Visibility = Visibility.Hidden;
                motiveDiscount.Visibility = Visibility.Hidden;
                labelAmountDiscount.Visibility = Visibility.Hidden;
                amountDiscount.Visibility = Visibility.Hidden;
			}
		}

		private void editServiceAction(object sender, System.Windows.RoutedEventArgs e)
		{
			if(this.checkValidations())
			{
				if (switchDiscount.IsChecked == true)
				{
					bill.amountWithDiscount = int.Parse(amountDiscount.Text);
					bill.reasonDiscount = motiveDiscount.Text;
                    if (isHandlered)
                    {
                        editorServices.performanceEditService(bill);
                    }
                    else 
                    {
                        registerService.performanceEditService(bill);
                    }
                    
                    this.Close();
				}
				else
				{
					bill.amountWithDiscount = 0;
					bill.reasonDiscount = "";

                    if (isHandlered)
                    {
                        editorServices.performanceEditService(bill);
                    }
                    else
                    {
                        registerService.performanceEditService(bill);
                    }
                    this.Close();
				}
			}
			else
			{
				MessageBox.Show("Completa todos los campos.");
			}
		}

		private void cancelServiceAction(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Close();
		}
		
		private bool checkValidations()
        {
            if (switchDiscount.IsChecked == true)
            {
                if (motiveDiscount.Text.Equals("") || amountDiscount.Text.Equals(""))
                {
                    return false;
                }
                else
                {
                    try
                    {
                        if (Int32.Parse(amountDiscount.Text.Trim()) <= 0)
                        {
                            MessageBox.Show("El precio por descuento debe ser mayor a 0.");
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("El monto para el descuento debe ser numérico.");
                        return false;
                    }
                }
            }
            return true;
        }
	}
}
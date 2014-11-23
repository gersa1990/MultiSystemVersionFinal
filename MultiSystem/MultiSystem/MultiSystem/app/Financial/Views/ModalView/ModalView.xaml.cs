using MultiSystem.app.Financial.Controllers;
using MultiSystem.app.Financial.Views.Controls;
using MultiSystem.app.Library.Controllers;
using MultiSystem.app.Library.Views.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
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
	/// Interaction logic for ModalViewFinancial.xaml
	/// </summary>
	public partial class ModalViewFinancial : Window
	{
        private RegisterService registerService;
        private Service service;
        private int formatedPriceReal;
        private EditorServices editorServices;
        private Bill idPatient;
        private string customDescription  { get; set; }



        public ModalViewFinancial(RegisterService registerService, Service service)
        {
            this.registerService = registerService;
            this.service = service;
            this.InitializeComponent();
            this.createDiscount(null,null);
            this.personalizeWindow();
        }

        public ModalViewFinancial(EditorServices editorServices, Bill idPatient)
        {
            // TODO: Complete member initialization
            this.editorServices = editorServices;
            this.idPatient = idPatient;
            this.InitializeComponent();
            this.createDiscount(null, null);
            this.personalizeWindow();
        }

        private void personalizeWindow() 
        {
            if (this.service.type == "AMBULANCIA") 
            {
                nameService.Text = "TRASLADO DE HUACANA HASTA ";
                customDescription = "TRASLADO ";
            }
            else if (this.service.type == "LABORATORIO")
            {
                nameService.Text = "ESTUDIOS DE ";
                customDescription = "ESTUDIOS ";
            }
            else 
            {
                nameService.Text = "SERVICIO DE ";
                customDescription = "SERVICIO ";
            }

            customDescription += this.service.descriptionPrice;

            if (customDescription.Length > 20) 
            {
                customDescription = customDescription.Substring(0,20);
            }

            nameService.Text += this.service.descriptionPrice;
 

            try
            {
                this.formatedPriceReal = int.Parse(this.service.amountPrice.ToString() + "", NumberStyles.Currency);
            }
            catch
            {
                String precio = this.service.amountPrice.Substring(1, this.service.amountPrice.Length - 4);
                precio = precio.Replace(",", "");
                this.formatedPriceReal = int.Parse(precio);
            }
            finally 
            {

            }



            amountService.Text = this.service.amountPrice;

            for (int i = 1; i < 10; i++) 
            {
                manyServices.Items.Add(new WorkItem(i,""+i));
            }

            manyServices.SelectedIndex = 0;
        }

        private void createDiscount(object sender, System.Windows.RoutedEventArgs e)
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

        private void cancelAction(object sender, System.Windows.RoutedEventArgs e)
        {
        	this.Close();
        }

        private void executeActionNew(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.checkValidations())
            {
                int servicesRequired = int.Parse(((WorkItem)manyServices.SelectedItem).Value);

                if (switchDiscount.IsChecked == true)
                {
                    if (servicesRequired == 1)
                    {
                        MessageBox.Show("Se realizara descuento");
                        registerService.responseDelegateModalAdd(new Bill(service.idService, service.keyPrice, customDescription, this.formatedPriceReal, service.type, motiveDiscount.Text, int.Parse(amountDiscount.Text)));
                    }
                    else 
                    {
                        MessageBox.Show("Se registrarán "+servicesRequired+" servicios con descuento");
                        for (int i = 0; i < servicesRequired; i++) 
                        {
                            registerService.responseDelegateModalAdd(new Bill(service.idService, service.keyPrice, customDescription, this.formatedPriceReal, service.type, motiveDiscount.Text, int.Parse(amountDiscount.Text)));
                        }
                    }
                    
                }
                else 
                {
                    if (servicesRequired == 1)
                    {
                        registerService.responseDelegateModalAdd(new Bill(service.idService, service.keyPrice, customDescription, this.formatedPriceReal, service.type, "", 0));
                    }
                    else
                    {
                        MessageBox.Show("Se registrarán " + servicesRequired + " servicios");
                        for (int i = 0; i < servicesRequired; i++)
                        {
                            registerService.responseDelegateModalAdd(new Bill(service.idService, service.keyPrice, customDescription, this.formatedPriceReal, service.type, "", 0));
                        }
                    }
                }

                this.Close();
            }
            else 
            {
                //MessageBox.Show("Verifica que los campos esten llenos.");
            } 
        }

        private bool checkValidations()
        {
            if (switchDiscount.IsChecked == true)
            {
                
                if (motiveDiscount.Text.Equals("") || amountDiscount.Text.Equals(""))
                {
                    MessageBox.Show("Completa los campos.");
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
                        else if (this.formatedPriceReal <= Int32.Parse(amountDiscount.Text.Trim()))
                        {
                             MessageBox.Show("El precio de descuento debe ser menor al precio real.");
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
using MultiSystem.app.Core.System.Screen;
using MultiSystem.app.Financial.Controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace MultiSystem.app.Financial.Views.Controls.ServicesCRUD
{
    /// <summary>
    /// Interaction logic for EditServiceAction.xaml
    /// </summary>
    public partial class EditServiceAction : Window
    {
        private EditService editService;
        private Service service;
        private Screener screen;

        private string keyService { get; set; }
        private string descriptionService { get; set; }
        private int amountService { get; set; }
        private string typeService { get; set; }

        public EditServiceAction(EditService editService, Service service)
        {
            this.editService = editService;
            this.service = service;
            InitializeComponent();
            this.performanceWindow();
            this.enableBtnEdit();
        }

        private void performanceWindow() 
        {
            keyEditPriceField.Text = this.service.keyPrice;
            descriptionEditField.Text = this.service.descriptionPrice;
            amountEditServiceField.Text = int.Parse( this.service.amountPrice, NumberStyles.Currency)+"";
            typeEditField.Text = this.service.type;
        }

        private bool validations() 
        {
            if (keyEditPriceField.Text.Equals("")) 
            {
                return false;
            }
            else if (descriptionEditField.Text.Equals("")) 
            {
                return false;
            }
            else if (descriptionEditField.Text.Equals("")) 
            {
                return true;
            }
            else if (typeEditField.Text.Equals("")) 
            {
                return false;
            }

            return true;
        }

        private void enableBtnEdit() 
        {
            if (this.validations())
            {
                btnEditService.IsEnabled = true;
            }
            else 
            {
                btnEditService.IsEnabled = false;
            }
        }

        private void writeEditKeyService(object sender, KeyEventArgs e)
        {
            this.keyService = keyEditPriceField.Text;
            this.enableBtnEdit();
        }

        private void writeEditDescriptionService(object sender, KeyEventArgs e)
        {
            this.descriptionService = descriptionEditField.Text;
            this.enableBtnEdit();
        }

        private void writeEditAmount(object sender, KeyEventArgs e)
        {
            try
            {
                this.amountService = int.Parse(amountEditServiceField.Text);
                this.enableBtnEdit();
            }
            catch 
            {
                MessageBox.Show("El monto debe ser numérico.");
                btnEditService.IsEnabled = false;
            }
        }

        private void writeEditType(object sender, KeyEventArgs e)
        {
            this.typeService = typeEditField.Text;
            this.enableBtnEdit();
        }

        private void editServiceAction(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> setParameters = new Dictionary<string, string>();
            Dictionary<string, string> whereParameters = new Dictionary<string, string>();

            setParameters.Add("keyPrice", keyEditPriceField.Text);
            setParameters.Add("descriptionPrice","'"+descriptionEditField.Text+"'");
            setParameters.Add("amountPrice", amountEditServiceField.Text+"");
            setParameters.Add("type","'"+typeEditField.Text+"'");

            whereParameters.Add("idService",this.service.idService+"");

            ServicesFinancialController serviceCtrler = new ServicesFinancialController();
            int edited = serviceCtrler.editService(setParameters, whereParameters);

            if (edited != 0)
            {
                editService.performanceServicesDB();
                MessageBox.Show("Servicio actualizado.");
            }
            else 
            {
                MessageBox.Show("Ocurrió un error.");
            }

            this.Close();
        }
    }
}

using MultiSystem.app.Core.System.Screen;
using MultiSystem.app.Financial.Controllers;
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
    /// Interaction logic for AddService.xaml
    /// </summary>
    public partial class AddService : UserControl
    {
        private Screener screen;
        private string keyService { get; set; }
        private string descriptionService { get; set; }
        private int amountService { get; set; }
        private string typeService { get; set; }

        public AddService()
        {
            InitializeComponent();
            this.enableBtnSave();
            screen = new Screener();
            this.Width = this.MinWidth = screen.fullWidth - 190;
            this.Height = this.MinHeight = screen.fullHeight - 130;
        }

        private bool validations() 
        {
            if (keyPriceField.Text.Equals("")) 
            {
                return false;
            }
            else if (descriptionField.Text.Equals("")) 
            {
                return false;
            }
            else if (amountServiceField.Text.Equals("")) 
            {
                return false;
            }
            else if (typeField.Text.Equals("")) 
            {
                return false;
            }

            return true;
        }

        private void enableBtnSave() 
        {
            if (this.validations())
            {
                btnAddService.IsEnabled = true;
            }
            else 
            {
                btnAddService.IsEnabled = false;
            }
        }

        private void createService(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("keyPrice",this.keyService);
            parameters.Add("descriptionPrice", this.descriptionService);
            parameters.Add("amountPrice", this.amountService+"");
            parameters.Add("type",this.typeService);

            ServicesFinancialController controller = new ServicesFinancialController();
            int idInserted = controller.InsertNewService(parameters);

            if (idInserted != 0) 
            {
                
                descriptionField.Text = "";
                keyPriceField.Text = "";
                amountServiceField.Text = 0+"";
                typeField.Text = "";

                MessageBox.Show("Se agregó el servicio con éxito.");
            }
        }

        private void writeKeyService(object sender, KeyEventArgs e)
        {
            this.keyService = keyPriceField.Text;
            this.enableBtnSave();
        }

        private void writeDescriptionService(object sender, KeyEventArgs e)
        {
            this.descriptionService = descriptionField.Text;
            this.enableBtnSave();
        }

        private void writeAmount(object sender, KeyEventArgs e)
        {
            try 
            {
                this.amountService = int.Parse(amountServiceField.Text);
                this.enableBtnSave();
            }
            catch
            {
                btnAddService.IsEnabled = false;
                MessageBox.Show("El monto debe ser solo números.");
            }
        }

        private void writeType(object sender, KeyEventArgs e)
        {
            this.typeService = typeField.Text;
            this.enableBtnSave();
        }
    }
}

using MultiSystem.app.Financial.Controllers;
using MultiSystem.app.Financial.Views.Controls;
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

namespace MultiSystem.app.Financial.Views.ModalView
{
    /// <summary>
    /// Interaction logic for ModalViewOptions.xaml
    /// </summary>
    public partial class ModalViewOptions : Window
    {
        private RegisterService registerService;
        private Bill service;

        public ModalViewOptions(RegisterService registerService, Bill service)
        {
            this.registerService = registerService;
            this.service = service;
            InitializeComponent();
            this.customizeWindow();
        }

        private void customizeWindow() 
        {
            dataServiceToEdit.Text = "Clave: " + this.service.keyPrice + " \n" + " Servicio: " + this.service.descriptionPrice + " \n ";
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            ModalViewHandler handlerView = new ModalViewHandler(this.registerService, service, typeOfModalView.delete);
            handlerView.executeModal();
            this.Close();
        }

        private void edit(object sender, RoutedEventArgs e)
        {
            ModalViewHandler handlerView = new ModalViewHandler(this.registerService, service, typeOfModalView.edit);
            handlerView.executeModal();
            this.Close();
        }
    }
}

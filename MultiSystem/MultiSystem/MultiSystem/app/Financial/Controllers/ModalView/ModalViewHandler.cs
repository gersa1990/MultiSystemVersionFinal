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
using MultiSystem.app.Financial.Views.Controls;
using MultiSystem.app.Financial.Controllers;
using MultiSystem.app.Financial.View.ModalView;

namespace MultiSystem.app.Financial.Controllers
{
	public enum typeOfModalView
    {
        edit,
        add,
        delete,
        info,
    }
	
	public class ModalViewHandler
	{
        private RegisterService registerService;
        private Service service;
        private typeOfModalView typeOfModalView;
        private Bill service1;

        public ModalViewHandler(RegisterService registerService, Service service, typeOfModalView typeOfModalView)
        {
            // TODO: Complete member initialization
            this.registerService = registerService;
            this.service = service;
            this.typeOfModalView = typeOfModalView;
        }

        public ModalViewHandler(RegisterService registerService, Bill service1, Controllers.typeOfModalView typeOfModalView)
        {
            // TODO: Complete member initialization
            this.registerService = registerService;
            this.service1 = service1;
            this.typeOfModalView = typeOfModalView;
        }

        public void executeModal() 
        {
            switch (typeOfModalView) 
            {
                case typeOfModalView.add:
                ModalViewFinancial modal = new ModalViewFinancial(registerService,service);
                modal.Show();
                break;

                case typeOfModalView.delete:
                ModalDeleteView modalDelete = new ModalDeleteView(registerService, service1);
                modalDelete.Show();
                break;

                case typeOfModalView.edit:
                ModalEditView modalEdit = new ModalEditView(registerService, service1);
                modalEdit.Show();
                break;
            }
        }
	}
}
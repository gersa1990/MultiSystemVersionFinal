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

namespace MultiSystem.app.Library.Views.PopUp
{
   public enum typeOfAlertEnum
    {
        alert,
        error,
        warning,
        info,
        success
    }
    /// <summary>
    /// Interaction logic for PopUpCustom.xaml
    /// </summary>
    public partial class PopUpCustom : Window
    {
        public string tittleLabel           { get; set; }
        public string containerText         { get; set; }
        public int    typeOfAlert           { get; set; }



        private typeOfAlertEnum _typeOfAlertEnum;
        

        public PopUpCustom() 
        {
            InitializeComponent();
        }
        public void setDataForAlert(string tittleLabelParameter, string container, typeOfAlertEnum typeOfAlertParameter)
        {
            this.tittleLabel    = tittleLabelParameter;
            this.containerText  = "\n\n"+container;
            this._typeOfAlertEnum = typeOfAlertParameter;
            this.customizePopUp();

            InitializeComponent();
        }

        private void customizePopUp() 
        {
            tittle.Content = this.tittleLabel;
            container.Text = this.containerText;
            this.changeImageAlert();
        }

        private void changeImageAlert() 
        {

            BitmapImage img = new BitmapImage();
            img.BeginInit();
            
            switch (_typeOfAlertEnum) 
            {
                case typeOfAlertEnum.alert: //INFO Alert
                    img.UriSource = new Uri("pack://application:,,,/MultiSystem;component/app/Resources/Info.png");
                break;

                case typeOfAlertEnum.warning: //Warning Alert
                    img.UriSource = new Uri("pack://application:,,,/MultiSystem;component/app/Resources/Warning.png");
                break;

                case typeOfAlertEnum.error: // Error Alert
                    img.UriSource = new Uri("pack://application:,,,/MultiSystem;component/app/Resources/Error.png");
                break;

                case typeOfAlertEnum.success: //Success Alert
                    img.UriSource = new Uri("pack://application:,,,/MultiSystem;component/app/Resources/Success.png");
                break;

                default:
                    img.UriSource = new Uri("pack://application:,,,/MultiSystem;component/app/Resources/Alert.png");
                break;
            }

            img.EndInit();
            imageAlert.Source = img;
        }

        private void closePopUp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

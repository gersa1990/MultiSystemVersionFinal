﻿#pragma checksum "..\..\..\..\..\..\app\Financial\Views\Controls\RegisterService.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "55631DD1E7F72839BDA9D6711D9F724A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MultiSystem.app.Financial.Views.Controls {
    
    
    /// <summary>
    /// RegisterService
    /// </summary>
    public partial class RegisterService : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\..\..\app\Financial\Views\Controls\RegisterService.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataServicesFounded;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\..\app\Financial\Views\Controls\RegisterService.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchServiceField;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\..\app\Financial\Views\Controls\RegisterService.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonNext;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\..\app\Financial\Views\Controls\RegisterService.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid servicesAdded;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\..\app\Financial\Views\Controls\RegisterService.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid servicesAddedByPatient;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MultiSystem;component/app/financial/views/controls/registerservice.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\app\Financial\Views\Controls\RegisterService.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dataServicesFounded = ((System.Windows.Controls.DataGrid)(target));
            
            #line 26 "..\..\..\..\..\..\app\Financial\Views\Controls\RegisterService.xaml"
            this.dataServicesFounded.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.OnAutoGeneratingColumn);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\..\..\..\app\Financial\Views\Controls\RegisterService.xaml"
            this.dataServicesFounded.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.selectedRow);
            
            #line default
            #line hidden
            return;
            case 2:
            this.searchServiceField = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\..\..\..\..\app\Financial\Views\Controls\RegisterService.xaml"
            this.searchServiceField.KeyUp += new System.Windows.Input.KeyEventHandler(this.searchServiceAction);
            
            #line default
            #line hidden
            return;
            case 3:
            this.buttonNext = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\..\..\app\Financial\Views\Controls\RegisterService.xaml"
            this.buttonNext.Click += new System.Windows.RoutedEventHandler(this.goToCreateBillUser);
            
            #line default
            #line hidden
            return;
            case 4:
            this.servicesAdded = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.servicesAddedByPatient = ((System.Windows.Controls.DataGrid)(target));
            
            #line 35 "..\..\..\..\..\..\app\Financial\Views\Controls\RegisterService.xaml"
            this.servicesAddedByPatient.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.OnAutoGeneratingColumn);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\..\..\..\app\Financial\Views\Controls\RegisterService.xaml"
            this.servicesAddedByPatient.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.selectRowForOptions);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


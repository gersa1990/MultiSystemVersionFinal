﻿#pragma checksum "..\..\..\..\..\..\app\Financial\Views\Controls\AdminGralWindowFinancial.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3AAD24978FF73FD478EA82A2F06F9B19"
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
    /// AdminGralWindowFinancial
    /// </summary>
    public partial class AdminGralWindowFinancial : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\..\..\app\Financial\Views\Controls\AdminGralWindowFinancial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameUserFinancial;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\..\app\Financial\Views\Controls\AdminGralWindowFinancial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lastNameUserFinancial;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\..\app\Financial\Views\Controls\AdminGralWindowFinancial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox adminTurnFinancial;
        
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
            System.Uri resourceLocater = new System.Uri("/MultiSystem;component/app/financial/views/controls/admingralwindowfinancial.xaml" +
                    "", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\app\Financial\Views\Controls\AdminGralWindowFinancial.xaml"
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
            this.nameUserFinancial = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.lastNameUserFinancial = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 40 "..\..\..\..\..\..\app\Financial\Views\Controls\AdminGralWindowFinancial.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.setDataAdminFinancial);
            
            #line default
            #line hidden
            return;
            case 4:
            this.adminTurnFinancial = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            
            #line 52 "..\..\..\..\..\..\app\Financial\Views\Controls\AdminGralWindowFinancial.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.closeWindowFinancial);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\..\..\..\app\Library\Views\Controls\AdminControlWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B3FBF773E216A0185FFF8B1BCEB28A1E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MultiSystem.app.Library.Views.Controls.PrivateAdminSection;
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


namespace MultiSystem.app.Library.Views.Controls {
    
    
    /// <summary>
    /// AdminControlWindow
    /// </summary>
    public partial class AdminControlWindow : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\..\..\..\app\Library\Views\Controls\AdminControlWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid addBokkGrid;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\..\..\app\Library\Views\Controls\AdminControlWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl optionsForSuperAdmin;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\..\..\app\Library\Views\Controls\AdminControlWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem addCategory;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\..\..\app\Library\Views\Controls\AdminControlWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem addAdmin;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\..\..\app\Library\Views\Controls\AdminControlWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label tittleWelcomeAdminLibrary;
        
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
            System.Uri resourceLocater = new System.Uri("/MultiSystem;component/app/library/views/controls/admincontrolwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\app\Library\Views\Controls\AdminControlWindow.xaml"
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
            this.addBokkGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            
            #line 64 "..\..\..\..\..\..\app\Library\Views\Controls\AdminControlWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.closeSession);
            
            #line default
            #line hidden
            return;
            case 3:
            this.optionsForSuperAdmin = ((System.Windows.Controls.TabControl)(target));
            return;
            case 4:
            this.addCategory = ((System.Windows.Controls.TabItem)(target));
            return;
            case 5:
            this.addAdmin = ((System.Windows.Controls.TabItem)(target));
            return;
            case 6:
            this.tittleWelcomeAdminLibrary = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


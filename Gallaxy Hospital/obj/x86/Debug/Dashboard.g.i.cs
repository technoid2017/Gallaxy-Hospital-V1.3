﻿#pragma checksum "..\..\..\Dashboard.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "70CCE41AB3AA8CBFDA4779C25087F1A3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
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


namespace Gallaxy_Hospital {
    
    
    /// <summary>
    /// Dashboard
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class Dashboard : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image1;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvas1;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttnIPD;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bttnAdmissionMuster;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bttnStats;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bttnDischargeMuster;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bttnAdmin;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bttnAccounts;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Gallaxy Hospital;component/dashboard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Dashboard.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.image1 = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.canvas1 = ((System.Windows.Controls.Canvas)(target));
            return;
            case 3:
            this.buttnIPD = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\..\Dashboard.xaml"
            this.buttnIPD.Click += new System.Windows.RoutedEventHandler(this.button1_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.bttnAdmissionMuster = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\Dashboard.xaml"
            this.bttnAdmissionMuster.Click += new System.Windows.RoutedEventHandler(this.button2_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.bttnStats = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\Dashboard.xaml"
            this.bttnStats.Click += new System.Windows.RoutedEventHandler(this.button3_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.bttnDischargeMuster = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Dashboard.xaml"
            this.bttnDischargeMuster.Click += new System.Windows.RoutedEventHandler(this.bttnDischargeMuster_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.bttnAdmin = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Dashboard.xaml"
            this.bttnAdmin.Click += new System.Windows.RoutedEventHandler(this.bttnAdmin_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.bttnAccounts = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Dashboard.xaml"
            this.bttnAccounts.Click += new System.Windows.RoutedEventHandler(this.bttnAccounts_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


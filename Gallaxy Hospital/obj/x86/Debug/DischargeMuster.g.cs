﻿#pragma checksum "..\..\..\DischargeMuster.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "71EB402C37C0C8C01A9022607AD347DB"
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
    /// DischargeMuster
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class DischargeMuster : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\DischargeMuster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle rectangle3;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\DischargeMuster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label23;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\DischargeMuster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid1;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\DischargeMuster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bttnGoNamePres;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\DischargeMuster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpckAdmissionTo;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\DischargeMuster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpckAdmissionFrom;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\DischargeMuster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label26;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\DischargeMuster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\DischargeMuster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button7;
        
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
            System.Uri resourceLocater = new System.Uri("/Gallaxy Hospital;component/dischargemuster.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DischargeMuster.xaml"
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
            this.rectangle3 = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 2:
            this.label23 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.dataGrid1 = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.bttnGoNamePres = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\DischargeMuster.xaml"
            this.bttnGoNamePres.Click += new System.Windows.RoutedEventHandler(this.bttnGoNamePres_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dtpckAdmissionTo = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.dtpckAdmissionFrom = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.label26 = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.button7 = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\DischargeMuster.xaml"
            this.button7.Click += new System.Windows.RoutedEventHandler(this.button7_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

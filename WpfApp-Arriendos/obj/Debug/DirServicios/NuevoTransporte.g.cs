﻿#pragma checksum "..\..\..\DirServicios\NuevoTransporte.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D71FC9156FE3AFC84972E025F4428B7F96BB4455551D534F6E2E2B788E7FF0BE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace WpfApp_Arriendos.DirServicios {
    
    
    /// <summary>
    /// NuevoTransporte
    /// </summary>
    public partial class NuevoTransporte : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\DirServicios\NuevoTransporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimiza;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\DirServicios\NuevoTransporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCerrar;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\DirServicios\NuevoTransporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTitulo;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\DirServicios\NuevoTransporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxIdServicioTransporte;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\DirServicios\NuevoTransporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPatente;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\DirServicios\NuevoTransporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNombreConductor;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\DirServicios\NuevoTransporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblmensaje;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\DirServicios\NuevoTransporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRegistrarTransporte;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp-Arriendos;component/dirservicios/nuevotransporte.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DirServicios\NuevoTransporte.xaml"
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
            this.btnMinimiza = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\DirServicios\NuevoTransporte.xaml"
            this.btnMinimiza.Click += new System.Windows.RoutedEventHandler(this.btnMinimiza_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnCerrar = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\DirServicios\NuevoTransporte.xaml"
            this.btnCerrar.Click += new System.Windows.RoutedEventHandler(this.btnCerrar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblTitulo = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.cbxIdServicioTransporte = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.txtPatente = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtNombreConductor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.lblmensaje = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.btnRegistrarTransporte = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\DirServicios\NuevoTransporte.xaml"
            this.btnRegistrarTransporte.Click += new System.Windows.RoutedEventHandler(this.btnRegistrarTransporte_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


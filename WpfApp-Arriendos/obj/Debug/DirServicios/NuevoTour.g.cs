﻿#pragma checksum "..\..\..\DirServicios\NuevoTour.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "180347AD70D92691F8841F7BF4757B707FCB945CB382B152146DB6791D69C9E4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
using WpfApp_Arriendos.DirServicios;


namespace WpfApp_Arriendos.DirServicios {
    
    
    /// <summary>
    /// NuevoTour
    /// </summary>
    public partial class NuevoTour : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\DirServicios\NuevoTour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDescripcionServicio;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\DirServicios\NuevoTour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTitulo;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\DirServicios\NuevoTour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescripcionTour;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\DirServicios\NuevoTour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRegistrarTour;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\DirServicios\NuevoTour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblmensaje;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\DirServicios\NuevoTour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblIdServicioTour;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\DirServicios\NuevoTour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxIdServicioTour;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp-Arriendos;component/dirservicios/nuevotour.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DirServicios\NuevoTour.xaml"
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
            this.lblDescripcionServicio = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lblTitulo = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.txtDescripcionTour = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnRegistrarTour = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\DirServicios\NuevoTour.xaml"
            this.btnRegistrarTour.Click += new System.Windows.RoutedEventHandler(this.btnRegistrarTour_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lblmensaje = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblIdServicioTour = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.cbxIdServicioTour = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

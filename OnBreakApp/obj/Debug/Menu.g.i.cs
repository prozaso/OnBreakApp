﻿#pragma checksum "..\..\Menu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A768758DEC6BCC006C7C625B7981AFC6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using OnBreakApp;
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


namespace OnBreakApp {
    
    
    /// <summary>
    /// Menu
    /// </summary>
    public partial class Menu : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Card expander;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander expGestionClientes;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander expListaClientes;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander expGestionContratos;
        
        #line default
        #line hidden
        
        
        #line 214 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander expListaContratos;
        
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
            System.Uri resourceLocater = new System.Uri("/OnBreakApp;component/menu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Menu.xaml"
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
            
            #line 20 "..\..\Menu.xaml"
            ((OnBreakApp.Menu)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.MetroWindow_Closing);
            
            #line default
            #line hidden
            
            #line 21 "..\..\Menu.xaml"
            ((OnBreakApp.Menu)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.MetroWindow_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.expander = ((MaterialDesignThemes.Wpf.Card)(target));
            return;
            case 3:
            this.expGestionClientes = ((System.Windows.Controls.Expander)(target));
            
            #line 40 "..\..\Menu.xaml"
            this.expGestionClientes.Expanded += new System.Windows.RoutedEventHandler(this.expanderGestionClientes);
            
            #line default
            #line hidden
            return;
            case 4:
            this.expListaClientes = ((System.Windows.Controls.Expander)(target));
            
            #line 114 "..\..\Menu.xaml"
            this.expListaClientes.Expanded += new System.Windows.RoutedEventHandler(this.expanderListaClientes);
            
            #line default
            #line hidden
            return;
            case 5:
            this.expGestionContratos = ((System.Windows.Controls.Expander)(target));
            
            #line 139 "..\..\Menu.xaml"
            this.expGestionContratos.Expanded += new System.Windows.RoutedEventHandler(this.expanderGestionContratos);
            
            #line default
            #line hidden
            return;
            case 6:
            this.expListaContratos = ((System.Windows.Controls.Expander)(target));
            
            #line 214 "..\..\Menu.xaml"
            this.expListaContratos.Expanded += new System.Windows.RoutedEventHandler(this.expanderListaContratos);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\..\Class\Client\ClientPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "370A53732F3B783F4812CD1B0A490425367E285A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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
using WpfApp1.Class.Client;


namespace WpfApp1.Class.Client {
    
    
    /// <summary>
    /// ClientPage
    /// </summary>
    public partial class ClientPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 16 "..\..\..\..\Class\Client\ClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grid;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Class\Client\ClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridComboBoxColumn civilite;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Class\Client\ClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Nom;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Class\Client\ClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Prenom;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Class\Client\ClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Mail;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Class\Client\ClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Cocivilite;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Class\Client\ClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Fidelite;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Class\Client\ClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/class/client/clientpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Class\Client\ClientPage.xaml"
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
            this.grid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 16 "..\..\..\..\Class\Client\ClientPage.xaml"
            this.grid.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.Edit);
            
            #line default
            #line hidden
            
            #line 16 "..\..\..\..\Class\Client\ClientPage.xaml"
            this.grid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.civilite = ((System.Windows.Controls.DataGridComboBoxColumn)(target));
            return;
            case 5:
            this.Nom = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Prenom = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Mail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Cocivilite = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.Fidelite = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.Password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 11:
            
            #line 62 "..\..\..\..\Class\Client\ClientPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Nouveau_client_click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 27 "..\..\..\..\Class\Client\ClientPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Billet_client_click);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 34 "..\..\..\..\Class\Client\ClientPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Supp_client_click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}


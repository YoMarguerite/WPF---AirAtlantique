﻿#pragma checksum "..\..\NumericBox.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01700B3DA04983D0170BE02960920CA278DF8D3A"
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


namespace WpfApp1 {
    
    
    /// <summary>
    /// NumericBox
    /// </summary>
    public partial class NumericBox : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\NumericBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApp1.NumericBox UserControl;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\NumericBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LayoutTimePicker;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\NumericBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtNum;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\NumericBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TopButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\NumericBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/numericbox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NumericBox.xaml"
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
            this.UserControl = ((WpfApp1.NumericBox)(target));
            return;
            case 2:
            this.LayoutTimePicker = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.TxtNum = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\NumericBox.xaml"
            this.TxtNum.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ChangeValue);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TopButton = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\NumericBox.xaml"
            this.TopButton.Click += new System.Windows.RoutedEventHandler(this.Top);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BotButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\NumericBox.xaml"
            this.BotButton.Click += new System.Windows.RoutedEventHandler(this.Bot);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

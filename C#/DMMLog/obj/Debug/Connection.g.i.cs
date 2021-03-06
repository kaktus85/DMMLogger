﻿#pragma checksum "..\..\Connection.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5C155A6075AC594DA6BF7A7BE46E356E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DMMLog;
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


namespace DMMLog {
    
    
    /// <summary>
    /// Connection
    /// </summary>
    public partial class Connection : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Connection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelVISA;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Connection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxVISA;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Connection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonConnect;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Connection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonClose;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Connection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxInstrument;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Connection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockIdentify;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Connection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelInstrument;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Connection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxInstrumentConnectionType;
        
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
            System.Uri resourceLocater = new System.Uri("/DMMLog;component/connection.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Connection.xaml"
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
            
            #line 8 "..\..\Connection.xaml"
            ((DMMLog.Connection)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 8 "..\..\Connection.xaml"
            ((DMMLog.Connection)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.Window_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.labelVISA = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.textBoxVISA = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.buttonConnect = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\Connection.xaml"
            this.buttonConnect.Click += new System.Windows.RoutedEventHandler(this.buttonConnect_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.buttonClose = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\Connection.xaml"
            this.buttonClose.Click += new System.Windows.RoutedEventHandler(this.buttonClose_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.comboBoxInstrument = ((System.Windows.Controls.ComboBox)(target));
            
            #line 14 "..\..\Connection.xaml"
            this.comboBoxInstrument.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboBoxInstrument_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.textBlockIdentify = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.labelInstrument = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.comboBoxInstrumentConnectionType = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


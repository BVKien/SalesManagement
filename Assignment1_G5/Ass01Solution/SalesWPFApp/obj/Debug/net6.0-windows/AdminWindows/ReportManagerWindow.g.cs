﻿#pragma checksum "..\..\..\..\AdminWindows\ReportManagerWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B0DFFAF9B010CE12E5BE0E46D84E57B6F9DB1DAC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SalesWPFApp.AdminWindow;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace SalesWPFApp.AdminWindow {
    
    
    /// <summary>
    /// ReportManagerWindow
    /// </summary>
    public partial class ReportManagerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 21 "..\..\..\..\AdminWindows\ReportManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu menuBar;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\AdminWindows\ReportManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lbPickDate;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\AdminWindows\ReportManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatePickerFrom;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\AdminWindows\ReportManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblSubtract;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\AdminWindows\ReportManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatePickerTo;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\AdminWindows\ReportManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblHeader;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\AdminWindows\ReportManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblTotalMoney;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\AdminWindows\ReportManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgInfo;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\AdminWindows\ReportManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SalesWPFApp;component/adminwindows/reportmanagerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\AdminWindows\ReportManagerWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\AdminWindows\ReportManagerWindow.xaml"
            ((SalesWPFApp.AdminWindow.ReportManagerWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Form_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.menuBar = ((System.Windows.Controls.Menu)(target));
            return;
            case 3:
            this.lbPickDate = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.DatePickerFrom = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.lblSubtract = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.DatePickerTo = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.lblHeader = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.lblTotalMoney = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.dtgInfo = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            this.SearchBtn = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\AdminWindows\ReportManagerWindow.xaml"
            this.SearchBtn.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 11:
            
            #line 43 "..\..\..\..\AdminWindows\ReportManagerWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CellContent_click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

﻿#pragma checksum "..\..\..\..\AdminWindows\MembersManagerWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5AEE079A64D09CFCA5B0DA7CD009AF2F73BF2E7F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SalesWPFApp.AdminWindows;
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


namespace SalesWPFApp.AdminWindows {
    
    
    /// <summary>
    /// MembersManagerWindow
    /// </summary>
    public partial class MembersManagerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\AdminWindows\MembersManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu menuBar;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\AdminWindows\MembersManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid tableMember;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\AdminWindows\MembersManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputEmail;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\AdminWindows\MembersManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputCompanyName;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\AdminWindows\MembersManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputCity;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\AdminWindows\MembersManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputCountry;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\AdminWindows\MembersManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputPassword;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.22.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SalesWPFApp;component/adminwindows/membersmanagerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\AdminWindows\MembersManagerWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.22.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.menuBar = ((System.Windows.Controls.Menu)(target));
            return;
            case 2:
            this.tableMember = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.inputEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.inputCompanyName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.inputCity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.inputCountry = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.inputPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 48 "..\..\..\..\AdminWindows\MembersManagerWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnRemove);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 49 "..\..\..\..\AdminWindows\MembersManagerWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnUpdate);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 50 "..\..\..\..\AdminWindows\MembersManagerWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Save);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


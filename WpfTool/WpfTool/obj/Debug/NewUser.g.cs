﻿#pragma checksum "..\..\NewUser.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C583BEDDBC500E2F769DB3CBA0790D73011025B5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using System.Windows.Forms.Integration;
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
using WpfTool;


namespace WpfTool {
    
    
    /// <summary>
    /// NewUser
    /// </summary>
    public partial class NewUser : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\NewUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UserNameText;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\NewUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FirstNameText;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\NewUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LastNameText;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\NewUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FirstPasswordText;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\NewUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SecondPasswordText;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\NewUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UsernameField;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\NewUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstNameField;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\NewUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastNameField;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\NewUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstPWField;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\NewUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SecondPWField;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\NewUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ErrorMessage;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfTool;component/newuser.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewUser.xaml"
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
            this.UserNameText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.FirstNameText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.LastNameText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.FirstPasswordText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.SecondPasswordText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.UsernameField = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\NewUser.xaml"
            this.UsernameField.LostFocus += new System.Windows.RoutedEventHandler(this.UsernameField_LostFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.FirstNameField = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.LastNameField = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.FirstPWField = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.SecondPWField = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            
            #line 20 "..\..\NewUser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Submit);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ErrorMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


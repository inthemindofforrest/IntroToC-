﻿#pragma checksum "..\..\SignIn.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43EBEB48BE9D64D1B2FC103F6E5286DA4DCDA4E4"
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
    /// SignIn
    /// </summary>
    public partial class SignIn : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\SignIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UsernameText;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\SignIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PasswordText;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\SignIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Username;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\SignIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Submit;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\SignIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\SignIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewUserButton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\SignIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\SignIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ErrorMessage;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\SignIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ShowPasswordCheckBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\SignIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Unhidden;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\SignIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ForgotPasswordButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfTool;component/signin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SignIn.xaml"
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
            this.UsernameText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.PasswordText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Username = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\SignIn.xaml"
            this.Username.GotFocus += new System.Windows.RoutedEventHandler(this.ClearError);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Submit = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\SignIn.xaml"
            this.Submit.Click += new System.Windows.RoutedEventHandler(this.AttemptLogin);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Password = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 29 "..\..\SignIn.xaml"
            this.Password.GotFocus += new System.Windows.RoutedEventHandler(this.ClearError);
            
            #line default
            #line hidden
            return;
            case 6:
            this.NewUserButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\SignIn.xaml"
            this.NewUserButton.Click += new System.Windows.RoutedEventHandler(this.NewUser);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\SignIn.xaml"
            this.Cancel.Click += new System.Windows.RoutedEventHandler(this.CancelApp);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ErrorMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.ShowPasswordCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 33 "..\..\SignIn.xaml"
            this.ShowPasswordCheckBox.Checked += new System.Windows.RoutedEventHandler(this.ShowPassword);
            
            #line default
            #line hidden
            
            #line 33 "..\..\SignIn.xaml"
            this.ShowPasswordCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.HidePassword);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Unhidden = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\SignIn.xaml"
            this.Unhidden.LostFocus += new System.Windows.RoutedEventHandler(this.Unhidden_LostFocus);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ForgotPasswordButton = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\SignIn.xaml"
            this.ForgotPasswordButton.Click += new System.Windows.RoutedEventHandler(this.ForgotPassword);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


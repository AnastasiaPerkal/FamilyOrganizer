﻿#pragma checksum "..\..\Register.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "384693EA462C7BE7ECB3BD4C7ABF69FB51433F7C28C274AC1F2495FFE1FAAC34"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FamilyOrganizer;
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


namespace FamilyOrganizer {
    
    
    /// <summary>
    /// Register
    /// </summary>
    public partial class Register : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UsernameRegister;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordRegister;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LB;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ParentWithCheckBox;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ParentLabel;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button IsParent;
        
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
            System.Uri resourceLocater = new System.Uri("/FamilyOrganizer;component/register.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Register.xaml"
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
            this.Close = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\Register.xaml"
            this.Close.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Close_MouseEnter);
            
            #line default
            #line hidden
            
            #line 32 "..\..\Register.xaml"
            this.Close.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Close_MouseLeave);
            
            #line default
            #line hidden
            
            #line 33 "..\..\Register.xaml"
            this.Close.Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UsernameRegister = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PasswordRegister = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.LB = ((System.Windows.Controls.Button)(target));
            
            #line 94 "..\..\Register.xaml"
            this.LB.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            
            #line 95 "..\..\Register.xaml"
            this.LB.MouseEnter += new System.Windows.Input.MouseEventHandler(this.LB_MouseEnter);
            
            #line default
            #line hidden
            
            #line 96 "..\..\Register.xaml"
            this.LB.MouseLeave += new System.Windows.Input.MouseEventHandler(this.LB_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ParentWithCheckBox = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.ParentLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.IsParent = ((System.Windows.Controls.Button)(target));
            
            #line 125 "..\..\Register.xaml"
            this.IsParent.MouseEnter += new System.Windows.Input.MouseEventHandler(this.IsParent_MouseEnter);
            
            #line default
            #line hidden
            
            #line 126 "..\..\Register.xaml"
            this.IsParent.MouseLeave += new System.Windows.Input.MouseEventHandler(this.IsParent_MouseLeave);
            
            #line default
            #line hidden
            
            #line 128 "..\..\Register.xaml"
            this.IsParent.Click += new System.Windows.RoutedEventHandler(this.IsParent_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


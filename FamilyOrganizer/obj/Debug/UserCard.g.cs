﻿#pragma checksum "..\..\UserCard.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CFBFE82FDE934CFBE5D9B9C0144322014E4557AD3A6FE024DF07DC847572085C"
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
    /// UserCard
    /// </summary>
    public partial class UserCard : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 84 "..\..\UserCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Balance;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\UserCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteUser;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\UserCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddMoney;
        
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
            System.Uri resourceLocater = new System.Uri("/FamilyOrganizer;component/usercard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserCard.xaml"
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
            this.Balance = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.DeleteUser = ((System.Windows.Controls.Button)(target));
            
            #line 108 "..\..\UserCard.xaml"
            this.DeleteUser.Click += new System.Windows.RoutedEventHandler(this.DeleteUser_Click);
            
            #line default
            #line hidden
            
            #line 109 "..\..\UserCard.xaml"
            this.DeleteUser.MouseEnter += new System.Windows.Input.MouseEventHandler(this.DeleteUser_MouseEnter);
            
            #line default
            #line hidden
            
            #line 110 "..\..\UserCard.xaml"
            this.DeleteUser.MouseLeave += new System.Windows.Input.MouseEventHandler(this.DeleteUser_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddMoney = ((System.Windows.Controls.Button)(target));
            
            #line 125 "..\..\UserCard.xaml"
            this.AddMoney.MouseEnter += new System.Windows.Input.MouseEventHandler(this.AddMoney_MouseEnter);
            
            #line default
            #line hidden
            
            #line 126 "..\..\UserCard.xaml"
            this.AddMoney.MouseLeave += new System.Windows.Input.MouseEventHandler(this.AddMoney_MouseLeave);
            
            #line default
            #line hidden
            
            #line 127 "..\..\UserCard.xaml"
            this.AddMoney.Click += new System.Windows.RoutedEventHandler(this.AddMoney_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


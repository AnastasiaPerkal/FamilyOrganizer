﻿#pragma checksum "..\..\AddTransaction.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E1F74E3AAE04FA071CA2026E712CD0DD881ECD85689A739B7C3156C387C1B57E"
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
    /// AddTransaction
    /// </summary>
    public partial class AddTransaction : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 76 "..\..\AddTransaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CategoryChoice;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\AddTransaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ToUser;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\AddTransaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TypeChoice;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\AddTransaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem DepositItem;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\AddTransaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem TransferItem;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\AddTransaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TranSum;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\AddTransaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseBtn;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\AddTransaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/FamilyOrganizer;component/addtransaction.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddTransaction.xaml"
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
            this.CategoryChoice = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.ToUser = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.TypeChoice = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.DepositItem = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 5:
            this.TransferItem = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 6:
            this.TranSum = ((System.Windows.Controls.TextBox)(target));
            
            #line 139 "..\..\AddTransaction.xaml"
            this.TranSum.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TranSum_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 140 "..\..\AddTransaction.xaml"
            this.TranSum.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TranSum_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CloseBtn = ((System.Windows.Controls.Button)(target));
            
            #line 156 "..\..\AddTransaction.xaml"
            this.CloseBtn.Click += new System.Windows.RoutedEventHandler(this.CloseBtn_Click);
            
            #line default
            #line hidden
            
            #line 157 "..\..\AddTransaction.xaml"
            this.CloseBtn.MouseEnter += new System.Windows.Input.MouseEventHandler(this.CloseBtn_MouseEnter);
            
            #line default
            #line hidden
            
            #line 158 "..\..\AddTransaction.xaml"
            this.CloseBtn.MouseLeave += new System.Windows.Input.MouseEventHandler(this.CloseBtn_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AddBtn = ((System.Windows.Controls.Button)(target));
            
            #line 171 "..\..\AddTransaction.xaml"
            this.AddBtn.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            
            #line 172 "..\..\AddTransaction.xaml"
            this.AddBtn.MouseEnter += new System.Windows.Input.MouseEventHandler(this.AddBtn_MouseEnter);
            
            #line default
            #line hidden
            
            #line 173 "..\..\AddTransaction.xaml"
            this.AddBtn.MouseLeave += new System.Windows.Input.MouseEventHandler(this.AddBtn_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\..\View\NPUkoly.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E2F8A532863DF67F9439D76FEF26F32AA2A2352D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Tento kód byl generován nástrojem.
//     Verze modulu runtime:4.0.30319.42000
//
//     Změny tohoto souboru mohou způsobit nesprávné chování a budou ztraceny,
//     dojde-li k novému generování kódu.
// </auto-generated>
//------------------------------------------------------------------------------

using Projurneyo_better_design.View;
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


namespace Projurneyo_better_design.View {
    
    
    /// <summary>
    /// NPUkoly
    /// </summary>
    public partial class NPUkoly : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\View\NPUkoly.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.SolidColorBrush PozadiGridu;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\View\NPUkoly.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAddUkol;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\View\NPUkoly.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRemoveUkol;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\View\NPUkoly.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Ukol;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\View\NPUkoly.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbxTypUkolu;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\View\NPUkoly.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPotvrdit;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\View\NPUkoly.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Seznam;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Projurneyo_better_design;component/view/npukoly.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\NPUkoly.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.PozadiGridu = ((System.Windows.Media.SolidColorBrush)(target));
            return;
            case 2:
            this.BtnAddUkol = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\View\NPUkoly.xaml"
            this.BtnAddUkol.Click += new System.Windows.RoutedEventHandler(this.BtnAddUkol_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnRemoveUkol = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\View\NPUkoly.xaml"
            this.BtnRemoveUkol.Click += new System.Windows.RoutedEventHandler(this.BtnRemoveUkol_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Ukol = ((System.Windows.Controls.TextBox)(target));
            
            #line 49 "..\..\..\..\View\NPUkoly.xaml"
            this.Ukol.GotFocus += new System.Windows.RoutedEventHandler(this.Ukol_GotFocus);
            
            #line default
            #line hidden
            
            #line 49 "..\..\..\..\View\NPUkoly.xaml"
            this.Ukol.LostFocus += new System.Windows.RoutedEventHandler(this.Ukol_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CmbxTypUkolu = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.BtnPotvrdit = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\..\View\NPUkoly.xaml"
            this.BtnPotvrdit.Click += new System.Windows.RoutedEventHandler(this.BtnPotvrdit_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Seznam = ((System.Windows.Controls.ListBox)(target));
            
            #line 65 "..\..\..\..\View\NPUkoly.xaml"
            this.Seznam.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Seznam_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


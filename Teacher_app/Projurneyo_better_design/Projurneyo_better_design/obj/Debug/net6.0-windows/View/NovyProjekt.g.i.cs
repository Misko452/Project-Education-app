﻿#pragma checksum "..\..\..\..\View\NovyProjekt.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EAE287932F51D62FEC2C885B468963C2059C46C4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Tento kód byl generován nástrojem.
//     Verze modulu runtime:4.0.30319.42000
//
//     Změny tohoto souboru mohou způsobit nesprávné chování a budou ztraceny,
//     dojde-li k novému generování kódu.
// </auto-generated>
//------------------------------------------------------------------------------

using Projurneyo_better_design.Utilities;
using Projurneyo_better_design.ViewModel;
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
    /// NovyProjekt
    /// </summary>
    public partial class NovyProjekt : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\View\NovyProjekt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.SolidColorBrush PozadiGridu;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\View\NovyProjekt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox RTpopis;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\View\NovyProjekt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxNazev;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\View\NovyProjekt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnNext;
        
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
            System.Uri resourceLocater = new System.Uri("/Projurneyo_better_design;component/view/novyprojekt.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\NovyProjekt.xaml"
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
            this.RTpopis = ((System.Windows.Controls.RichTextBox)(target));
            
            #line 31 "..\..\..\..\View\NovyProjekt.xaml"
            this.RTpopis.GotFocus += new System.Windows.RoutedEventHandler(this.RTpopis_GotFocus);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\..\View\NovyProjekt.xaml"
            this.RTpopis.LostFocus += new System.Windows.RoutedEventHandler(this.RTpopis_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TextBoxNazev = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\..\View\NovyProjekt.xaml"
            this.TextBoxNazev.GotFocus += new System.Windows.RoutedEventHandler(this.TextBoxNazev_GotFocus);
            
            #line default
            #line hidden
            
            #line 44 "..\..\..\..\View\NovyProjekt.xaml"
            this.TextBoxNazev.LostFocus += new System.Windows.RoutedEventHandler(this.TextBoxNazev_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnNext = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\View\NovyProjekt.xaml"
            this.BtnNext.Click += new System.Windows.RoutedEventHandler(this.BtnNext_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


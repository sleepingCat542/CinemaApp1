﻿#pragma checksum "..\..\..\UserControls\AddSeat.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AB89A36DF67F9B6CDFAFB42BD8C20C7123C2E5C1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CinemaApp.UserControls;
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


namespace CinemaApp.UserControls {
    
    
    /// <summary>
    /// AddSeat
    /// </summary>
    public partial class AddSeat : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\UserControls\AddSeat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Row1;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\UserControls\AddSeat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Seat1;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\UserControls\AddSeat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Row2;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\UserControls\AddSeat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Seat2;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\UserControls\AddSeat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Row3;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\UserControls\AddSeat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Seat3;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UserControls\AddSeat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Row4;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\UserControls\AddSeat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Seat4;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\UserControls\AddSeat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Row5;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\UserControls\AddSeat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Seat5;
        
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
            System.Uri resourceLocater = new System.Uri("/CinemaApp;component/usercontrols/addseat.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\AddSeat.xaml"
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
            this.Row1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.Seat1 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\UserControls\AddSeat.xaml"
            this.Seat1.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SetSeats);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Row2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.Seat2 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 25 "..\..\..\UserControls\AddSeat.xaml"
            this.Seat2.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SetSeats);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Row3 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.Seat3 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 30 "..\..\..\UserControls\AddSeat.xaml"
            this.Seat3.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SetSeats);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Row4 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.Seat4 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 35 "..\..\..\UserControls\AddSeat.xaml"
            this.Seat4.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SetSeats);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Row5 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.Seat5 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 40 "..\..\..\UserControls\AddSeat.xaml"
            this.Seat5.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SetSeats);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 43 "..\..\..\UserControls\AddSeat.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnOk);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "D:\Personal\Silverlight\FinalAssignment\FinalAssignment\Views\MedicationListItem.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5A4DE58F9E636244C39C2DDF9AAFD27B"
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
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace FinalAssignment.Views {
    
    
    public partial class MedicationListItem : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock txtMedication;
        
        internal System.Windows.Controls.TextBlock txtStatusComplete;
        
        internal System.Windows.Controls.TextBlock txtStatusInProgress;
        
        internal System.Windows.Controls.TextBlock txtStartDate;
        
        internal System.Windows.Controls.TextBlock txtEndDate;
        
        internal System.Windows.Controls.TextBlock txtDosage;
        
        internal System.Windows.Controls.TextBlock txtFrequency;
        
        internal System.Windows.Controls.TextBlock txtNote;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/FinalAssignment;component/Views/MedicationListItem.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.txtMedication = ((System.Windows.Controls.TextBlock)(this.FindName("txtMedication")));
            this.txtStatusComplete = ((System.Windows.Controls.TextBlock)(this.FindName("txtStatusComplete")));
            this.txtStatusInProgress = ((System.Windows.Controls.TextBlock)(this.FindName("txtStatusInProgress")));
            this.txtStartDate = ((System.Windows.Controls.TextBlock)(this.FindName("txtStartDate")));
            this.txtEndDate = ((System.Windows.Controls.TextBlock)(this.FindName("txtEndDate")));
            this.txtDosage = ((System.Windows.Controls.TextBlock)(this.FindName("txtDosage")));
            this.txtFrequency = ((System.Windows.Controls.TextBlock)(this.FindName("txtFrequency")));
            this.txtNote = ((System.Windows.Controls.TextBlock)(this.FindName("txtNote")));
        }
    }
}

﻿#pragma checksum "C:\Users\deli\Documents\GitHub\phone\PhoneMobileTracker\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "09C80D474C499BB18AB50506225C6CEC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
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


namespace PhoneMobileTracker {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock LatitudeTextBlock;
        
        internal System.Windows.Controls.TextBlock LongitudeTextBlock;
        
        internal System.Windows.Controls.TextBlock AddressTextBlock;
        
        internal System.Windows.Controls.TextBox Imei;
        
        internal System.Windows.Controls.Button BtnImei;
        
        internal System.Windows.Controls.Button BtnStart;
        
        internal System.Windows.Controls.Button BtnStop;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PhoneMobileTracker;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.LatitudeTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("LatitudeTextBlock")));
            this.LongitudeTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("LongitudeTextBlock")));
            this.AddressTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("AddressTextBlock")));
            this.Imei = ((System.Windows.Controls.TextBox)(this.FindName("Imei")));
            this.BtnImei = ((System.Windows.Controls.Button)(this.FindName("BtnImei")));
            this.BtnStart = ((System.Windows.Controls.Button)(this.FindName("BtnStart")));
            this.BtnStop = ((System.Windows.Controls.Button)(this.FindName("BtnStop")));
        }
    }
}


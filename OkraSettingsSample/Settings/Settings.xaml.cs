﻿using Okra.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Settings Flyout item template is documented at http://go.microsoft.com/fwlink/?LinkId=273769

namespace OkraSettingsSample.Pages
{
    /// <summary>
    /// A page that displays the contents of a settings pane
    /// </summary>
    [PageExport("Settings_Sample")]
    public sealed partial class Settings : UserControl
    {
        public Settings()
        {
            this.InitializeComponent();
        }
    }
}
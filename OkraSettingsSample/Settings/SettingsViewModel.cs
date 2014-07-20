using Okra.Navigation;
using System;
using System.Collections.Generic;
using System.Composition;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using OkraSettingsSample.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Windows.Input;

// The Settings Flyout item template is documented at http://go.microsoft.com/fwlink/?LinkId=273769

namespace OkraSettingsSample.Pages
{
    /// <summary>
    /// A view model for displaying an overview of a single group, including a preview of the items
    /// within the group.
    /// </summary>
    [ViewModelExport("Settings_Sample")]
    public class SettingsViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public SettingsViewModel(INavigationContext navigationContext)
            : base(navigationContext)
        {
            NavigateToChildCommand = NavigationManager.GetNavigateToCommand("Settings_Child");
        }

        // *** Properties ***

        public ICommand NavigateToChildCommand
        {
            get;
            private set;
        }
    }
}

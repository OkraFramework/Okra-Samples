using OkraShellSample.Common;
using Okra.Navigation;
using System;
using System.Collections.Generic;
using System.Composition;
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
using System.Windows.Input;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace OkraShellSample.Pages
{
    /// <summary>
    /// A basic view model that provides characteristics common to most applications.
    /// </summary>
    [ViewModelExport("Page1")]
    public class Page1ViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public Page1ViewModel(INavigationContext navigationContext)
            : base(navigationContext)
        {
            this.NavigateToPage2Command = NavigationManager.GetNavigateToCommand("Page2");
        }

        // *** Properties ***

        public ICommand NavigateToPage2Command { get; private set; }
    }
}

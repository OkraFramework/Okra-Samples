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
using Okra.Core;
using System.Windows.Input;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace OkraShellSample.Pages
{
    [Export(typeof(INavigationTarget))]
    [Shared]
    public class ShellPageViewModel : NotifyPropertyChangedBase, INavigationTarget
    {
        // *** Fields ***

        private INavigationBase navigationManager;
        private ICommand goBackCommand;

        private object content;
        private ShellPage shellPage;

        // *** Properties ***

        public object Content
        {
            get
            {
                return content;
            }
            set
            {
                SetProperty(ref content, value);
            }
        }

        public ICommand GoBackCommand
        {
            get
            {
                return goBackCommand;
            }
            set
            {
                SetProperty(ref goBackCommand, value);
            }
        }

        // *** INavigationTarget Methods ***

        public void NavigateTo(object page, INavigationBase navigationManager)
        {
            // If this is the first navigation then create the shell view and bind to this view model

            if (shellPage == null)
            {
                shellPage = new ShellPage();
                shellPage.DataContext = this;
            }

            // Set the content for the shell to the specified page

            this.Content = page;

            // Set the shell view as the window content

            Window.Current.Content = shellPage;

            // Update the navigation manager if changed

            if (this.navigationManager != navigationManager)
            {
                this.navigationManager = navigationManager;
                this.GoBackCommand = navigationManager.GetGoBackCommand();
            }
        }
    }
}

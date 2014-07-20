using Okra;
using Okra.Navigation;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.UI.ApplicationSettings;

namespace OkraSettingsSample
{
    public class AppBootstrapper : OkraBootstrapper
    {
        // *** Imported Properties ***

        [Import]
        public ISettingsPaneManager SettingsPaneManager { get; set; }

        // *** Overriden Base Methods ***

        protected override void SetupServices()
        {
            // Register with Windows to display items in the settings pane

            SettingsPane.GetForCurrentView().CommandsRequested += SettingsPane_CommandsRequested;
        }

        // *** Private Methods ***

        void SettingsPane_CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            // The settings names should be localised so create a ResourceLoader to gather these from

            ResourceLoader resourceLoader = new ResourceLoader();

            // Add each settings item in the order you wish them to appear
            // NB: Since we want the SettingsPaneManager to navigate when the item is selected we use the GetNavigateToSettingsCommand helper

            args.Request.ApplicationCommands.Add(SettingsPaneManager.GetNavigateToSettingsCommand(resourceLoader.GetString("SampleCommandLabel"), "Settings_Sample"));
            args.Request.ApplicationCommands.Add(SettingsPaneManager.GetNavigateToSettingsCommand(resourceLoader.GetString("AboutCommandLabel"), "Settings_About"));
        }
    }
}

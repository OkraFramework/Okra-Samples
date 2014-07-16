using Okra;
using Okra.Navigation;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OkraConventionSample
{
    public class AppBootstrapper : OkraBootstrapper
    {
        /// <summary>
        /// Perform general initialization of application services.
        /// </summary>
        protected override void SetupServices()
        {
            // Configure the navigation manager to preseve application state in local storage
            NavigationManager.NavigationStorageType = NavigationStorageType.Local;
        }

        protected override ContainerConfiguration GetContainerConfiguration()
        {
            // In this method we define the conventions for discovering types

            ConventionBuilder conventionBuilder = new ConventionBuilder();

            // Register any types ending in "Page" using the "OkraPage" contract with the corresponding "PageName"

            conventionBuilder.ForTypesMatching(type => type.FullName.EndsWith("Page"))
                             .Export(builder => builder.AsContractType<object>()
                                                       .AsContractName("OkraPage")
                                                       .AddMetadata("PageName", type => type.Name.Substring(0, type.Name.Length - 4)));

            // Register any types ending in "ViewModel" using the "OkraViewModel" contract with the corresponding "PageName"

            conventionBuilder.ForTypesMatching(type => type.FullName.EndsWith("ViewModel"))
                             .Export(builder => builder.AsContractType<object>()
                                                       .AsContractName("OkraViewModel")
                                                       .AddMetadata("PageName", type => type.Name.Substring(0, type.Name.Length - 9)));

            // Combine the newly created conventions with the default Okra App Framework container configuration

            return GetOkraContainerConfiguration()
                    .WithAssembly(typeof(AppBootstrapper).GetTypeInfo().Assembly, conventionBuilder);
        }
    }
}

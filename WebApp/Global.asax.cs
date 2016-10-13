using SitefinityWebApp.Mvc.Models;
using SitefinityWebApp.Resources;
using System;
using System.Web;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Frontend;
using Telerik.Sitefinity.Frontend.Navigation.Mvc.Models;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Bootstrapper.Initialized += this.Bootstrapper_Initialized;
            SystemManager.ApplicationStart += SystemManager_ApplicationStart;
                    }

        private void SystemManager_ApplicationStart(object sender, EventArgs e)
        {
            Res.RegisterResource<BreakingNewsResources>();
        }

        private void Bootstrapper_Initialized(object sender, ExecutedEventArgs e)
        {
            if (e.CommandName == "Bootstrapped")
            {
                FrontendModule.Current.DependencyResolver.Rebind<INavigationModel>().To<CustomNavigationModel>();
            }
        }
    }
}
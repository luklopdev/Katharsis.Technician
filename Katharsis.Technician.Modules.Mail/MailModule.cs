using Katharsis.Technician.Core;
using Katharsis.Technician.Modules.Mail.Menus;
using Katharsis.Technician.Modules.Mail.ViewModels;
using Katharsis.Technician.Modules.Mail.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katharsis.Technician.Modules.Mail
{
    public class MailModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public MailModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            // TODO: NAVIGATION
            //_regionManager.RegisterViewWithRegion(RegionNames.CONTENT_REGION, typeof(ViewA));


            _regionManager.RegisterViewWithRegion(RegionNames.TOP_NAVIGATION, typeof(HomeTab));
            _regionManager.RegisterViewWithRegion(RegionNames.SIDE_NAVIGATION, typeof(MailGroup));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<MailGroup, MailGroupViewModel>();

            containerRegistry.RegisterForNavigation<MailListView, MailListViewModel>();
        }
    }
}

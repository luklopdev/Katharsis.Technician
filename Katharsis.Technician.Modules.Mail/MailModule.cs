using Katharsis.Technician.Core;
using Katharsis.Technician.Modules.Mail.Menus;
using Katharsis.Technician.Modules.Mail.ViewModels;
using Katharsis.Technician.Modules.Mail.Views;
using Katharsis.Technician.Services;
using Katharsis.Technician.Services.Interfaces;
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
            _regionManager.RegisterViewWithRegion(RegionNames.SIDE_NAVIGATION, typeof(MailGroup));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<MailGroup, MailGroupViewModel>();

            containerRegistry.RegisterForNavigation<MailListView, MailListViewModel>();

            containerRegistry.RegisterSingleton<IMailService, MailService>();

            containerRegistry.RegisterDialog<MessageView, MessageViewModel>();
        }
    }
}

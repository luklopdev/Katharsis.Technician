using Katharsis.Technician.Core;
using Katharsis.Technician.Modules.Contractors.Menus;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katharsis.Technician.Modules.Contractors
{
    public class ContractorsModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ContractorsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.SIDE_NAVIGATION, typeof(ContractorsGroup));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}

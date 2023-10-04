using Katharsis.Technician.Core;
using Katharsis.Technician.Core.Interfaces;
using Katharsis.Technician.Modules.Mail.Views;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Katharsis.Technician.Dialogs
{
    public class MyDialogService : IMyDialogService
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerExtension _containerExtension;

        public MyDialogService(IContainerExtension containerExtension, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _containerExtension = containerExtension;
        }

        public void Show(string name)
        {
            
        }
    }
}

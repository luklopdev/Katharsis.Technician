using Katharsis.Technician.Core;
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
    public class MyDialogService : DialogService
    {
        private readonly IRegionManager _regionManager;

        public MyDialogService(IContainerExtension containerExtension, IRegionManager regionManager) : base(containerExtension)
        {
            _regionManager = regionManager;
        }

        protected override void ConfigureDialogWindowContent(string dialogName, IDialogWindow window, IDialogParameters parameters)
        {
            base.ConfigureDialogWindowContent(dialogName, window, parameters);

            var regionManager = _regionManager.CreateRegionManager();
            RegionManager.SetRegionManager((DependencyObject)window, regionManager);

            regionManager.RequestNavigate(RegionNames.CONTENT_REGION, nameof(MessageView));
        }
    }
}

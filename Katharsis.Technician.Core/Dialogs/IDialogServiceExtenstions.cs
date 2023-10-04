using Prism.Regions;
using Prism.Services.Dialogs;
using System.Windows;

namespace Katharsis.Technician.Core.Dialogs
{
    public static class IDialogServiceExtenstions
    {
        public static void ShowRibbonWindow(this IDialogService dialogService, string name)
        {
            var window = new RibbonWindow();
            var regionManager = new RegionManager();
            RegionManager.SetRegionManager(window, regionManager);

            regionManager.RequestNavigate(RegionNames.CONTENT_REGION, name);
            window.Owner = Application.Current.MainWindow;
            window.Show();
        }
    }
}

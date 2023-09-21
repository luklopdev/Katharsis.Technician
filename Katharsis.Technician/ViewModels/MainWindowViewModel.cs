using Katharsis.Technician.Core;
using Katharsis.Technician.Core.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katharsis.Technician.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private DelegateCommand<string> _navigateCommand;
        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExecuteNavigateCommand));

        private DelegateCommand<ITabItem> _groupSelectionChangedCommand;
        public DelegateCommand<ITabItem> GroupSelectionChangedCommand =>
            _groupSelectionChangedCommand ?? (_groupSelectionChangedCommand = new DelegateCommand<ITabItem>(ExecuteGroupSelectionChangedCommand));

        private DelegateCommand<ITabItem> _groupLoadedCommand;
        public DelegateCommand<ITabItem> GroupLoadedCommand =>
            _groupLoadedCommand ?? (_groupLoadedCommand = new DelegateCommand<ITabItem>(ExecuteGroupSelectionChangedCommand));

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;   
        }

        void ExecuteNavigateCommand(string navigationPath)
        {
            if(string.IsNullOrEmpty(navigationPath))
                throw new ArgumentNullException(nameof(navigationPath));

            _regionManager.RequestNavigate(RegionNames.CONTENT_REGION, navigationPath);
        }

        void ExecuteGroupSelectionChangedCommand(ITabItem group)
        {
            if(group != null)
            {
                _regionManager.RequestNavigate(RegionNames.CONTENT_REGION, group.DefaultNavigationPath);
            }
        }
    }
}

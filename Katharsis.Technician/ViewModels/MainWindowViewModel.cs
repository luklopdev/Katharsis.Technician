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
    internal class MainWindowViewModel : ViewModelBase
    {
        private readonly IApplicationCommands _applicationCommands;
        private readonly IRegionManager _regionManger;

        private DelegateCommand<string> _navigateCommand;
        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExecuteNavigateCommand));

        private DelegateCommand<ITabItem> _groupSelectionChangedCommand;
        public DelegateCommand<ITabItem> GroupSelectionChangedCommand =>
            _groupSelectionChangedCommand ?? (_groupSelectionChangedCommand = new DelegateCommand<ITabItem>(ExecuteGroupSelectionChangedCommand));

        private DelegateCommand<ITabItem> _groupLoadedCommand;
        public DelegateCommand<ITabItem> GroupLoadedCommand =>
            _groupLoadedCommand ?? (_groupLoadedCommand = new DelegateCommand<ITabItem>(ExecuteGroupSelectionChangedCommand));

        public MainWindowViewModel(IApplicationCommands applicationCommands, IRegionManager regionManger)
        {
            _applicationCommands = applicationCommands;
            _applicationCommands.NavigateCommand.RegisterCommand(NavigateCommand);
            _regionManger = regionManger;

        }

        void ExecuteNavigateCommand(string navigationPath)
        {
            if(string.IsNullOrEmpty(navigationPath))
                throw new ArgumentNullException(nameof(navigationPath));

            _regionManger.RequestNavigate(RegionNames.CONTENT_REGION, navigationPath);
        }

        void ExecuteGroupSelectionChangedCommand(ITabItem group)
        {
            if(group != null)
            {
                _applicationCommands.NavigateCommand.Execute(group.DefaultNavigationPath);
            }
        }
    }
}

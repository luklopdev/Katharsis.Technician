using Katharsis.Technician.Business;
using Katharsis.Technician.Core;
using Katharsis.Technician.Modules.Mail.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katharsis.Technician.Modules.Mail.ViewModels
{
    public class MailGroupViewModel : ViewModelBase
    {
        private readonly IApplicationCommands _applicationCommands;

        private ObservableCollection<NavigationItem> _items;
        public ObservableCollection<NavigationItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private DelegateCommand<NavigationItem> _selectedItemChangedCommand;
        public DelegateCommand<NavigationItem> SelectedItemChangedCommand =>
            _selectedItemChangedCommand ?? (_selectedItemChangedCommand = new DelegateCommand<NavigationItem>(ExecuteSelectedItemChangedCommand));

        public MailGroupViewModel(IApplicationCommands applicationCommands)
        {
            GenerateMenu();
            _applicationCommands = applicationCommands;
        }

        void ExecuteSelectedItemChangedCommand(NavigationItem navigationItem)
        {
            if(navigationItem != null)
            {
                _applicationCommands.NavigateCommand.Execute(navigationItem.NavigationPath);
            }
        }

        void GenerateMenu()
        {
            Items = new ObservableCollection<NavigationItem>();

            var root = new NavigationItem() { Caption = "Personal Folder", NavigationPath = $"{nameof(MailListView)}?id=Default" };
            root.Items.Add(new NavigationItem() { Caption = "Inbox", NavigationPath = $"{nameof(MailListView)}?id=Inbox" });
            root.Items.Add(new NavigationItem() { Caption = "Deleted", NavigationPath = $"{nameof(MailListView)}?id=Deleted" });
            root.Items.Add(new NavigationItem() { Caption = "Sent", NavigationPath = $"{nameof(MailListView)}?id=Sent" });

            Items.Add(root);
        }
    }
}

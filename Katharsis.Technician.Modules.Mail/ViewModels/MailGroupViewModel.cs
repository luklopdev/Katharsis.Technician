using Katharsis.Technician.Business;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katharsis.Technician.Modules.Mail.ViewModels
{
    public class MailGroupViewModel : BindableBase
    {
        private ObservableCollection<NavigationItem> _items;
        public ObservableCollection<NavigationItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public MailGroupViewModel()
        {
            GenerateMenu();
        }

        void GenerateMenu()
        {
            Items = new ObservableCollection<NavigationItem>();

            var root = new NavigationItem() { Caption = "Personal Folder", NavigationPath = "MailList" };
            root.Items.Add(new NavigationItem() { Caption = "Inbox", NavigationPath = "" });
            root.Items.Add(new NavigationItem() { Caption = "Deleted", NavigationPath = "" });
            root.Items.Add(new NavigationItem() { Caption = "Sent", NavigationPath = "" });

            Items.Add(root);
        }
    }
}

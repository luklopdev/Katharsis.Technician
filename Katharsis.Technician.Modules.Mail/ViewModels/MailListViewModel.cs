using Katharsis.Technician.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Katharsis.Technician.Modules.Mail.ViewModels
{
    public class MailListViewModel : ViewModelBase
    {
        private string _title = "Default";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); ; }
        }

        public MailListViewModel(IDialogService dialogService)
        {
            
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            Title = navigationContext.Parameters.GetValue<string>("id");
        }
    }
}

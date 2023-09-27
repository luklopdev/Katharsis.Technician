using Katharsis.Technician.Business;
using Katharsis.Technician.Core;
using Katharsis.Technician.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Katharsis.Technician.Modules.Mail.ViewModels
{
    public class MailListViewModel : ViewModelBase
    {
        private readonly IMailService _mailService;

        private ObservableCollection<MailMessage> _messages;
        public ObservableCollection<MailMessage> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        private MailMessage _selectedMessage;
        public MailMessage SelectedMessage
        {
            get => _selectedMessage;
            set => SetProperty(ref _selectedMessage, value);
        }

        public MailListViewModel(IMailService mailService)
        {
            _mailService = mailService;
            //Messages
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            var folder = navigationContext.Parameters.GetValue<string>(FolderParameters.FOLDER_KEY);
            switch (folder)
            {
                case FolderParameters.INBOX:
                    Messages = new ObservableCollection<MailMessage>(_mailService.GetInboxItems());
                    break;
                case FolderParameters.DELETED:
                    Messages = new ObservableCollection<MailMessage>(_mailService.GetDeletedItems());
                    break;
                case FolderParameters.SENT:
                    Messages = new ObservableCollection<MailMessage>(_mailService.GetSentItems());
                    break;
                default:
                    break;
            }
        }
    }
}

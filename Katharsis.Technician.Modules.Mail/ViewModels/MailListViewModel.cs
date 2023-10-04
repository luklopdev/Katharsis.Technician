using Katharsis.Technician.Business;
using Katharsis.Technician.Core;
using Katharsis.Technician.Core.Dialogs;
using Katharsis.Technician.Core.Interfaces;
using Katharsis.Technician.Modules.Mail.Views;
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
        private readonly IDialogService _dialogService;

        internal EventHandler LoadBodyMessage { get; set; }

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

        private DelegateCommand _mailSelectionChangedCommand;
        public DelegateCommand MailSelectionChangedCommand =>
            _mailSelectionChangedCommand ?? (_mailSelectionChangedCommand = new DelegateCommand(ExecuteMailSelectionChangedCommand));

        private DelegateCommand<string> _messageCommand;
        public DelegateCommand<string> MessageCommand =>
            _messageCommand ?? (_messageCommand = new DelegateCommand<string>(ExecuteMessageCommand));

        public MailListViewModel(IMailService mailService, IDialogService dialogService)
        {
            _mailService = mailService;
            _dialogService = dialogService;
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

        void ExecuteMailSelectionChangedCommand()
        {
            LoadBodyMessage.Invoke(this, null);
        }

        void ExecuteMessageCommand(string message)
        {
            _dialogService.ShowRibbonWindow(nameof(MessageView));
        }
    }
}

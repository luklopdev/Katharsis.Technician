using Katharsis.Technician.Core;
using Prism.Services.Dialogs;
using System;

namespace Katharsis.Technician.Modules.Mail.ViewModels
{
    public class MessageViewModel : ViewModelBase, IDialogAware
    {
        public string Title => "Mail Message";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }
    }
}

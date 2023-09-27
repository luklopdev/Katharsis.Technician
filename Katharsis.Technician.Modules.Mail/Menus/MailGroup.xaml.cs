using Katharsis.Technician.Business;
using Katharsis.Technician.Core.Interfaces;
using Katharsis.Technician.Modules.Mail.ViewModels;
using Katharsis.Technician.Modules.Mail.Views;
using System.Linq;
using System.Windows.Controls;

namespace Katharsis.Technician.Modules.Mail.Menus
{
    /// <summary>
    /// Interaction logic for MailGroup.xaml
    /// </summary>
    public partial class MailGroup : TabItem, ITabItem
    {
        public MailGroup()
        {
            InitializeComponent();
        }

        public string DefaultNavigationPath
        {
            get
            {
                var item = tv.SelectedItem as NavigationItem;
                if (item != null)
                {
                    return item.NavigationPath;
                }

                return $"{nameof(MailListView)}?{FolderParameters.FOLDER_KEY}={FolderParameters.INBOX}";
            }
        }
    }
}

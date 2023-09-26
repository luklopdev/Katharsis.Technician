using Katharsis.Technician.Core;
using Katharsis.Technician.Core.Interfaces;
using Katharsis.Technician.Modules.Mail.Menus;
using System.Windows.Controls;


namespace Katharsis.Technician.Modules.Mail.Views
{
    /// <summary>
    /// Interaction logic for MailListView.xaml
    /// </summary>
    [DependentView(RegionNames.TOP_NAVIGATION, typeof(HomeTab))]
    public partial class MailListView : UserControl, ISupportDataContext
    {
        public MailListView()
        {
            InitializeComponent();
        }
    }
}

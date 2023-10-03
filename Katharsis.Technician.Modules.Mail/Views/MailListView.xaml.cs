using Katharsis.Technician.Core;
using Katharsis.Technician.Core.Interfaces;
using Katharsis.Technician.Modules.Mail.Menus;
using Katharsis.Technician.Modules.Mail.ViewModels;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Katharsis.Technician.Modules.Mail.Views
{
    /// <summary>
    /// Interaction logic for MailListView.xaml
    /// </summary>
    [DependentView(RegionNames.TOP_NAVIGATION, typeof(HomeTab))]
    public partial class MailListView : UserControl, ISupportDataContext
    {

        MailListViewModel CustomDataContext { get; set; }

        public MailListView()
        {
            InitializeComponent();
        }

        private void LoadRtfText(object sender, EventArgs e)
        {
            string body = CustomDataContext?.SelectedMessage?.Body;

            if (!string.IsNullOrEmpty(body))
            {
                using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(body)))
                {
                    TextRange textRange = new TextRange(richTextEditor.Document.ContentStart, richTextEditor.Document.ContentEnd);
                    textRange.Load(memoryStream, DataFormats.Rtf);
                }
            }
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CustomDataContext = (MailListViewModel)DataContext;
            CustomDataContext.LoadBodyMessage = LoadRtfText;
        }
    }
}

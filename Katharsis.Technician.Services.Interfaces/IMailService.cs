using Katharsis.Technician.Business;
using System.Collections.Generic;

namespace Katharsis.Technician.Services.Interfaces
{
    public interface IMailService
    {
        IList<MailMessage> GetInboxItems();
        IList<MailMessage> GetSentItems();
        IList<MailMessage> GetDeletedItems();
    }
}

using Katharsis.Technician.Business;
using Katharsis.Technician.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Katharsis.Technician.Services
{
    public class MailService : IMailService
    {
        static List<MailMessage> InboxItems = new List<MailMessage>
        {
            new MailMessage
            {
                Id = 1,
                From = "lukasz.lopata@gmail.com",
                To = new ObservableCollection<string> { "kongo@poland.com", "jhon.cena@yahoo.com" },
                Subject = "This is a test email",
                Body = "This is the body af an email",
                DateSent = DateTime.Now,
            },
            new MailMessage
            {
                Id = 2,
                From = "lukasz.lopata@gmail.com",
                To = new ObservableCollection<string> { "kongo@poland.com", "jhon.cena@yahoo.com" },
                Subject = "This is a test email 2",
                Body = "This is the body af an email 2",
                DateSent = DateTime.Now.AddDays(-1),
            },
            new MailMessage
            {
                Id = 3,
                From = "lukasz.lopata@gmail.com",
                To = new ObservableCollection<string> { "kongo@poland.com", "jhon.cena@yahoo.com" },
                Subject = "This is a test email 3",
                Body = "This is the body af an email 3",
                DateSent = DateTime.Now.AddDays(-5),
            },
            new MailMessage
            {
                Id = 4,
                From = "lukasz.lopata@gmail.com",
                To = new ObservableCollection<string> { "kongo@poland.com", "jhon.cena@yahoo.com" },
                Subject = "This is a test email 4",
                Body = "This is the body af an email 4",
                DateSent = DateTime.Now.AddDays(-1).AddMonths(-2),
            }
        };

        static List<MailMessage> SentItems = new List<MailMessage>();

        static List<MailMessage> DeletedItems = new List<MailMessage>();

        public IList<MailMessage> GetDeletedItems()
        {
            return DeletedItems;
        }

        public IList<MailMessage> GetInboxItems()
        {
            return InboxItems;
        }

        public IList<MailMessage> GetSentItems()
        {
            return SentItems;
        }
    }
}

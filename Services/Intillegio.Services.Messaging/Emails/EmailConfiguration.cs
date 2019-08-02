using Intillegio.Services.Messaging.Emails.Contracts;

namespace Intillegio.Services.Messaging.Emails
{

    public class EmailConfiguration : IEmailConfiguration
    {
        public string SmtpServer { get; set; }

        public int SmtpPort { get; set; }

        public string SmtpUsername { get; set; }

        public string SmtpPassword { get; set; }
    }
}

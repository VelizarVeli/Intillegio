﻿using Intillegio.Emails.Contracts;

namespace Intillegio.Emails
{

    public class EmailConfiguration : IEmailConfiguration
    {
        public string SmtpServer { get; set; }

        public int SmtpPort { get; set; }

        public string SmtpUsername { get; set; }

        public string SmtpPassword { get; set; }
    }
}

﻿using Intillegio.Web.Mails.Contracts;

namespace Intillegio.Web.Mails
{
    public class EmailConfiguration :IEmailConfiguration
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
    }
}

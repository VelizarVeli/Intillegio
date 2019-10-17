using System;
using Intillegio.Common.ViewModels;
using Intillegio.Web.Mails.Contracts;
using MimeKit;

namespace Intillegio.Web.Mails
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public void Send(IEmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailMessage.Name, _emailConfiguration.SmtpUsername));
            message.To.Add(new MailboxAddress("natalia", "dimovanat@gmail.com"));
            message.Subject = $"{emailMessage.Subject}";
            message.Body = new TextPart("plain")
            {
                Text = $"Message: {emailMessage.Content}" + Environment.NewLine +
                       $"Contact email: {emailMessage.Email}"
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, false);
                client.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void Callback(IEmailCallback callback)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(callback.Name, _emailConfiguration.SmtpUsername));
            message.To.Add(new MailboxAddress("vels", "dimovanat@gmail.com"));
            message.Subject = "Callback";
            message.Body = new TextPart("plain")
            {
                Text = $"Name: {callback.Name}" + Environment.NewLine +
                       $"Contact phone: {callback.PhoneNumber}",
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, false);
                client.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                client.Send(message);
                client.Disconnect(true);
            }

        }
    }
}

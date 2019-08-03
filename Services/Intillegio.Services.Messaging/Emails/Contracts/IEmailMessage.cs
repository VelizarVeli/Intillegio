﻿namespace Intillegio.Services.Messaging.Emails.Contracts
{
   public interface IEmailMessage
    {
        string Name { get; set; }

        string Email { get; set; }

        string Subject { get; set; }

        string Content { get; set; }
    }
}
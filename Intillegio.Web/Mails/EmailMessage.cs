﻿using System.ComponentModel.DataAnnotations;
using Intillegio.Web.Mails.Contracts;

namespace Intillegio.Web.Mails
{
    public class EmailMessage:IEmailMessage
    {
        [Required]
        [MinLength(3, ErrorMessage = "{0} must be more than or equal to {1} characters")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "This is not a valid email address")]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Message should be more than or equal to {1} characters")]
        public string Content { get; set; }
    }
}

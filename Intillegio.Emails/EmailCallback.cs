using System.ComponentModel.DataAnnotations;
using Intillegio.Emails.Contracts;

namespace Intillegio.Emails
{
    public class EmailCallback : IEmailCallback
    {
        [Required]
        [MinLength(3, ErrorMessage = "{0} must be more than or equal to {1} characters")]
        public string Name { get; set; }
        
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}

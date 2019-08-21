using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;

namespace Intillegio.DTOs.BindingModels
{
    public class TeamMemberBindingModel
    {
        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.ClientNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.ClientNameMinLength)]
        public string Position { get; set; }

        [Required]
        [StringLength(LengthConstants.AboutMaxLength, MinimumLength = LengthConstants.AboutMinLength)]
        public string About { get; set; }

        [Required]
        [RegularExpression("^\\(\\+[\\d]{3}\\) [\\d]{3}-[\\d]{3}-[\\d]{3}$", ErrorMessage = "The phone number should be in this format (+123) 123-456-789")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Image350X290 { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string Skype { get; set; }
    }
}

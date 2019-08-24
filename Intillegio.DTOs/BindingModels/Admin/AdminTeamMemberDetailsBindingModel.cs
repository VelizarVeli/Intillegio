using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;
using Intillegio.Models;

namespace Intillegio.DTOs.BindingModels.Admin
{
    public class AdminTeamMemberDetailsBindingModel
    {
        public AdminTeamMemberDetailsBindingModel()
        {
            ActivitiesAndSkills = new HashSet<ActivityAndSkill>();
            ProffessionalSkills = new HashSet<ProffessionalSkill>();
        }

        public int Id { get; set; }

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
        [StringLength(LengthConstants.PhonStringMaxLength)]
        [Display(Name = "Phone Number")]
        [RegularExpression("^\\(\\+[\\d]{3}\\) [\\d]{3}-[\\d]{3}-[\\d]{3}$", ErrorMessage = "The phone number should be in this format (+123) 123-456-789")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Image 350 x 290")]
        public string Image350X290 { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string Skype { get; set; }

        public string Linkedin { get; set; }

        [Display(Name = "Activities and Skills")]
        public ICollection<ActivityAndSkill> ActivitiesAndSkills { get; set; }

        [Display(Name = "Proffessional Skills")]
        public ICollection<ProffessionalSkill> ProffessionalSkills { get; set; }
    }
}

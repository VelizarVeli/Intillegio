﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;

namespace Intillegio.Models
{
    public class TeamMember : BaseId
    {
        public TeamMember()
        {
            ActivitiesAndSkills = new HashSet<ActivityAndSkill>();
            ProffessionalSkills = new HashSet<ProffessionalSkill>();
        }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.ClientNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.ClientNameMinLength)]
        public string Position { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        [StringLength(LengthConstants.PhonStringMaxLength)]
        [RegularExpression("^\\(\\+[\\d]{3}\\) [\\d]{3} [\\d]{3} [\\d]{3}$", ErrorMessage = "The phone number should be in this format (+123) 123 456 789")]
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

        public string Linkedin { get; set; }

        public ICollection<ActivityAndSkill> ActivitiesAndSkills { get; set; }

        public ICollection<ProffessionalSkill> ProffessionalSkills { get; set; }
    }
}

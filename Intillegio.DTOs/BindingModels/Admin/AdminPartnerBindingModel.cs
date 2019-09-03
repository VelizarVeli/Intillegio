using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;
using Intillegio.Models;

namespace Intillegio.DTOs.BindingModels.Admin
{
   public class AdminPartnerBindingModel
    {
        public AdminPartnerBindingModel()
        {
            this.Projects = new HashSet<Project>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.ClientNameMinLength)]
        public string Name { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        public string LinkToPartnersWebsite { get; set; }

        [Required]
        [Display(Name = "Logo Image 155 x 75")]
        public string Logo155X75 { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}

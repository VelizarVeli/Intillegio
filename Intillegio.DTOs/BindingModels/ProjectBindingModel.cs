using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;
using Intillegio.Models;

namespace Intillegio.DTOs.BindingModels
{
    public class ProjectBindingModel : BaseId
    {
        public ProjectBindingModel()
        {
            Features = new HashSet<ProjectFeatureJunctionClass>();
        }

        [Required]
        [StringLength(LengthConstants.MaxLengthProjectName, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = LengthConstants.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(5000)]
        [Display(Name = "About the project")]
        public string ProjectInfo { get; set; }

        [Display(Name = "In Progress")]
        public string Stage { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }

        [Required]
        [Display(Name = "Add the link to the image 350x350 px")]
        public string Image350X350 { get; set; }

        [Required]
        [Display(Name = "Add the link to the image 1110X450 px")]
        public string Image1110X450 { get; set; }

        [Required]
        [Display(Name = "Add the link to the image 360X240 px")]
        public string Image360X240 { get; set; }

        public ICollection<Project> RelatedProjects { get; set; }
        public ICollection<ProjectFeatureJunctionClass> Features { get; set; }

        [Required]
        public string Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public string Partner { get; set; }

        public IEnumerable<Partner> Partners { get; set; }
    }
}

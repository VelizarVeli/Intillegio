using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;
using Intillegio.Models;

namespace Intillegio.Common.BindingModels
{
    public class ProjectBindingModel
    {
        [Required]
        [StringLength(LengthConstants.MaxLengthProjectName, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = LengthConstants.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(5000)]
        [Display(Name = "About the project")]
        public string ProjectInfo { get; set; }

        public string Stage { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }

        [Required]
        [Display(Name="Add the link to the image")]
        public string Image { get; set; }

        public ICollection<Project> RelatedProjects { get; set; }
        public ICollection<ProjectFeatures> Features { get; set; }

        [Required]
        public string Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public string Client { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}

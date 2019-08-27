using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;
using Intillegio.Models;

namespace Intillegio.DTOs.BindingModels.Admin
{
   public class AdminProjectBindingModel
    {
        public AdminProjectBindingModel()
        {
            Features = new HashSet<ProjectFeature>();
            RelatedProjects = new HashSet<Project>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(LengthConstants.ProjectMaxLength, MinimumLength = LengthConstants.ClientNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(LengthConstants.AboutMaxLength, MinimumLength = LengthConstants.AboutMinLength)]
        [Display(Name = "Project Information")]
        public string ProjectInfo { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Stage { get; set; }

        [Required]
        public string Partner { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime StartingDate { get; set; }

        [Required]
        [Display(Name = "Image 350 x 350" )]
        public string Image350X350 { get; set; }

        [Required]
        [Display(Name = "Image 1110 x 450")]
        public string Image1110X450 { get; set; }

        [Required]
        [Display(Name = "Image 360 x 240" )]
        public string Image360X240 { get; set; }

        [Display(Name = "Related Projects")]
        public ICollection<Project> RelatedProjects { get; set; }

        public ICollection<ProjectFeature> Features { get; set; }
    }
}

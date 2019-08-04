using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common;
using Intillegio.Data.Common.Models;

namespace Intillegio.Data.Models
{
    public class Project : BaseModel<Guid>
    {
        public Project()
        {
            this.Features = new HashSet<ProjectFeatures>();
            this.RelatedProjects = new HashSet<Project>();
        }

        [Required]
        [StringLength(LengthConstants.MaxLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = LengthConstants.ClientNameMinLength)]
        public string Name { get; set; }

        [Required]
        public string ProjectInfo { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public Status Status { get; set; }

        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }

        public string Image { get; set; }

        public ICollection<Project> RelatedProjects { get; set; }

        public ICollection<ProjectFeatures> Features { get; set; }
    }
}

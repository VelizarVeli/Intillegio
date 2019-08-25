using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;

namespace Intillegio.Models
{
    public class Project : BaseId
    {
        public Project()
        {
            this.Features = new HashSet<ProjectFeatureJunctionClass>();
            this.RelatedProjects = new HashSet<Project>();
        }

        [Required]
        [StringLength(LengthConstants.ProjectMaxLength, MinimumLength = LengthConstants.ClientNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(LengthConstants.AboutMaxLength, MinimumLength = LengthConstants.AboutMinLength)]
        public string ProjectInfo { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        public Stage Stage { get; set; }

        [Required]
        public int PartnerId { get; set; }
        public virtual Partner Partner { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }

        [Required]
        public string Image350X350 { get; set; }

        [Required]
        public string Image1110X450 { get; set; }
        
        [Required]
        public string Image360X240 { get; set; }

        //TODO: Add related projects
        //public virtual ICollection<RelatedProject> RelatedProjects { get; set; }
        //public Guid CorrectRelatedProjectId { get; private set; }
        //public Guid? AnsweredRelatedProjectId { get; private set; }
        //public bool IsAnswerCorrect =>CorrectRelatedProjectId  == AnsweredRelatedProjectId;
        //public bool IsAnswered => AnsweredRelatedProjectId != null;

        public ICollection<Project> RelatedProjects { get; set; }

        public ICollection<ProjectFeatureJunctionClass> Features { get; set; }
    }
}

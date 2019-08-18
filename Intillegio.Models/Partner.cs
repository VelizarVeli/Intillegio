using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;

namespace Intillegio.Models
{
    public class Partner : BaseId
    {
        public Partner()
        {
            this.Projects = new HashSet<Project>();
        }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.ClientNameMinLength)]
        public string Name { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        public string Logo155X75 { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}

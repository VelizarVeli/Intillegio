using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;

namespace Intillegio.Models
{
    public class ProffessionalSkill : BaseId
    {
        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.ClientNameMinLength)]
        public string Name { get; set; }

        [Required]
        [Range(0, 100)]
        public int Percentage { get; set; }

        public int TeamMemberId { get; set; }
        public virtual TeamMember TeamMember { get; set; }
    }
}

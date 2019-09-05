using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;

namespace Intillegio.DTOs.BindingModels.Admin
{
    public class AdminQuickLinkBindingModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.ClientNameMinLength)]
        public string Name { get; set; }

        [Required]
        public string Link { get; set; }
    }
}

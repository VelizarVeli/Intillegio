using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;

namespace Intillegio.Models
{
    public class ProductFeatures
    {
        [Key]
        public int Id { get; set; }

        [StringLength(LengthConstants.NameMinLength, MinimumLength = LengthConstants.MaxLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(LengthConstants.NameMinLength, MinimumLength = LengthConstants.MaxLength)]
        public string ProductCategory { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public int Width { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        [StringLength(LengthConstants.NameMinLength, MinimumLength = LengthConstants.MaxLength)]
        public string Material { get; set; }

        [Required]
        [StringLength(LengthConstants.NameMinLength, MinimumLength = LengthConstants.MaxLength)]
        public string Color { get; set; }
    }
}
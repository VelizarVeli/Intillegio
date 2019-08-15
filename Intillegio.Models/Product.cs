using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;

namespace Intillegio.Models
{
    public class Product
    {
        public Product()
        {
            this.Reviews = new HashSet<Review>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LengthConstants.NameMinLength, MinimumLength = LengthConstants.MaxLength)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int ProductFeaturesId { get; set; }
        public virtual ProductFeatures ProductFeatures { get; set; }

        [Required]
        public string PictureLink { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}

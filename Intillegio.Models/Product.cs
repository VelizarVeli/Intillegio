using System;
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
            this.ProductImages = new HashSet<ProductImage>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(LengthConstants.SkuMaxLength, MinimumLength = LengthConstants.SkuMinLength)]
        public string StockKeepingUnit { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image255X325 { get; set; }

        [Required]
        public string Image540X540 { get; set; }

        [Required]
        public string Image135X135 { get; set; }

        [Required]
        public string Image95X125 { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string ProductCategory { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public int Width { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Material { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Color { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}

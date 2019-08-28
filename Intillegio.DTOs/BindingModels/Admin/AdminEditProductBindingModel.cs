using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;
using Intillegio.Models;

namespace Intillegio.DTOs.BindingModels.Admin
{
    public class AdminEditProductBindingModel
    {
        public AdminEditProductBindingModel()
        {
            Reviews = new HashSet<Review>();
            ProductImages = new HashSet<ProductImage>();
        }

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
        [Display(Name = "SKU")]
        public string StockKeepingUnit { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Image 255 x 325")]
        public string Image255X325 { get; set; }

        [Required]
        [Display(Name = "Image 540 x 540")]
        public string Image540X540 { get; set; }

        [Required]
        [Display(Name = "Image 135 x 135")]
        public string Image135X135 { get; set; }

        [Required]
        [Display(Name = "Image 95 x 125")]
        public string Image95X125 { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        [Display(Name = "Product Category")]
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

        [Display(Name = "Product Images")]
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}

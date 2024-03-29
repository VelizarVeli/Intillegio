﻿using System.ComponentModel.DataAnnotations;

namespace Intillegio.Common.ViewModels
{
   public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        [Display(Name = "Image 255 x 325")]
        public string Image255X325 { get; set; }

        public int  Stars { get; set; }
    }
}

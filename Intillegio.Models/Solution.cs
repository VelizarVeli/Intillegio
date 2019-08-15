﻿using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;

namespace Intillegio.Models
{
   public class Solution
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LengthConstants.NameMinLength, MinimumLength = LengthConstants.MaxLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(LengthConstants.AboutMaxLength, MinimumLength = LengthConstants.AboutMinLength)]
        public string About { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
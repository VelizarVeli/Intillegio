﻿using System;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;

namespace Intillegio.Models
{
    public class Review : BaseId
    {
        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required]
        public string Content { get; set; }

        public string Email { get; set; }

        public string Image75X75 { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}

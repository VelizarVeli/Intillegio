using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;

namespace Intillegio.Models
{
    public class Article : BaseId
    {
        public Article()
        {
            Comments = new HashSet<Comment>();
        }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category CategoryName { get; set; }

        public string VideoLink { get; set; }

        [Required]
        public string Image65X65 { get; set; }

        [Required]
        public string Image350X220 { get; set; }

        [Required]
        public string Image390X245 { get; set; }

        public string VideoImage400X250 { get; set; }

        [Required]
        public string Image825X530 { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public ICollection<Comment> Comments { get; set; }
    }
}

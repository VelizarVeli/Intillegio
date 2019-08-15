using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;

namespace Intillegio.Models
{
   public class Article
    {
        public Article()
        {
            Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LengthConstants.NameMinLength, MinimumLength = LengthConstants.MaxLength)]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category ArticleCategory { get; set; }

        public string VideoLink { get; set; }

        [Required]
        public string ImageLink { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public ICollection<Comment> Comments { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;

namespace Intillegio.Models
{
   public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string CommenterName { get; set; }

        [Required]
        public DateTime CommentDate { get; set; } = DateTime.UtcNow;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}

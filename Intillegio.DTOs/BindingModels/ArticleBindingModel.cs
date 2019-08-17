using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;
using Intillegio.Models;

namespace Intillegio.DTOs.BindingModels
{
   public class ArticleBindingModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = DisplayNameConstants.ArticleName)]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category ArticleCategory { get; set; }

        public string VideoLink { get; set; }

        [Required]
        public string SmallImage { get; set; }

        [Required]
        public string BigImage { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } 

        public IEnumerable<Comment> Comments { get; set; }
    }
}

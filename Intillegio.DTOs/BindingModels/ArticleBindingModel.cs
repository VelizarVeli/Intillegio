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
        public DateTime Date { get; set; } 

        public IEnumerable<Comment> Comments { get; set; }
    }
}

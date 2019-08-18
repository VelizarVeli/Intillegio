using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;

namespace Intillegio.Models
{
    public class Category : BaseId
    {
        public Category()
        {
            this.Projects = new HashSet<Project>();
            this.Articles = new HashSet<Article>();
            this.Products = new HashSet<Product>();
        }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Name { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ICollection<Article> Articles { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

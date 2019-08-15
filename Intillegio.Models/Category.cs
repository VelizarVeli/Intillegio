using System.Collections.Generic;

namespace Intillegio.Models
{
    public class Category
    {
        public Category()
        {
            this.Projects = new HashSet<Project>();
            this.Articles = new HashSet<Article>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}

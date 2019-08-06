using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intillegio.Data.Models.Entities
{
    public class Category
    {
        public Category()
        {
            this.Projects = new HashSet<Project>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}

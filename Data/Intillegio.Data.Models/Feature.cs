using System.Collections.Generic;

namespace Intillegio.Data.Models
{
   public class Feature
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProjectFeatures> Projects { get; set; }
    }
}

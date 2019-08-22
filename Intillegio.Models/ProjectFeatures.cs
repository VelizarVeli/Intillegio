using System.ComponentModel.DataAnnotations;

namespace Intillegio.Models
{
    public class ProjectFeatures
    {
        [Key]
        public int Id { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public int FeatureId { get; set; }
        public virtual ProjectFeature ProjectFeature { get; set; }
    }
}

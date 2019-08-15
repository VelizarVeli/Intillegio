using System;

namespace Intillegio.Models
{
    public class ProjectFeatures
    {
        public int Id { get; set; }

        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public int FeatureId { get; set; }
        public virtual ProjectFeature ProjectFeature { get; set; }
    }
}

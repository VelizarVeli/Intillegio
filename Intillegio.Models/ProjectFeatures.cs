using System;

namespace Intillegio.Models
{
    public class ProjectFeatures : BaseId
    {
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public int FeatureId { get; set; }
        public virtual ProjectFeature ProjectFeature { get; set; }
    }
}

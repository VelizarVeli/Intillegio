namespace Intillegio.Models
{
    public class ProjectFeatureJunctionClass
    {
        public int  Id { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int FeatureId { get; set; }
        public ProjectFeature ProjectFeature { get; set; }
    }
}

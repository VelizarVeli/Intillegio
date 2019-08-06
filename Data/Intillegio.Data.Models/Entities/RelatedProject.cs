using System;

namespace Intillegio.Data.Models.Entities
{
    public class RelatedProject
    {
        public Guid ProjectId { get; set; }
        public Guid RelatedId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Intillegio.Data.Common.Models;

namespace Intillegio.Data.Models.Entities
{
    public class Feature : BaseId
    {
        public string Name { get; set; }

        public ICollection<ProjectFeatures> Projects { get; set; }
    }
}

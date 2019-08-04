namespace Intillegio.Data.Models
{
    using System;

    using System.Collections.Generic;

    using Intillegio.Data.Common.Models;

    public class Client : BaseModel<Guid>
    {
        public Client()
        {
            this.Projects = new HashSet<Project>();
        }

        public string Name { get; set; }

        public string About { get; set; }

        public string Logo { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}

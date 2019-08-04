using System.ComponentModel.DataAnnotations;

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

        [Required]
        public string Name { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        public string Logo { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}

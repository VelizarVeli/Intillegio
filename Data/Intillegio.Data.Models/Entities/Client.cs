using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Data.Common.Models;

namespace Intillegio.Data.Models.Entities
{
    public class Client : BaseId
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

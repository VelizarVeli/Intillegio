﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;

namespace Intillegio.Models
{
    public class Client : BaseId
    {
        public Client()
        {
            this.Projects = new HashSet<Project>();
        }

        [Required]
        [StringLength(LengthConstants.NameMinLength, MinimumLength = LengthConstants.MaxLength)]
        public string Name { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        public string Logo { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}

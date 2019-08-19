﻿using System.ComponentModel.DataAnnotations;

namespace Intillegio.Common.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        public string Image350X350 { get; set; }

        public string Name { get; set; }

        public string Stage { get; set; }

        public string CategoryName { get; set; }
    }
}

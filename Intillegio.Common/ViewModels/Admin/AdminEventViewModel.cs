using System;
using System.ComponentModel.DataAnnotations;

namespace Intillegio.Common.ViewModels.Admin
{
    public class AdminEventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Start date")]
        public DateTime StartDateTime { get; set; }

        public string Place { get; set; }

        public string Town { get; set; }
    }
}

using System;

namespace Intillegio.Common.ViewModels.Admin
{
    public class AdminEventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDateTime { get; set; }

        public string Place { get; set; }

        public string Town { get; set; }
    }
}

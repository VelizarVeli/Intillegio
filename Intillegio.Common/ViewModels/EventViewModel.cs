using System;

namespace Intillegio.Common.ViewModels
{
   public class EventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartingDate { get; set; }

        public string About { get; set; }

        public string Place { get; set; }

        public string Image540X360 { get; set; }

        public string Image225X285 { get; set; }

        public string VideoLink { get; set; }
    }
}

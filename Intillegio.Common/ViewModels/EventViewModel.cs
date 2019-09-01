using System;
using System.ComponentModel.DataAnnotations;

namespace Intillegio.Common.ViewModels
{
   public class EventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Start Date Time")]
        public DateTime StartDateTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        public string About { get; set; }

        public string Place { get; set; }

        public string Town { get; set; }

        [Display(Name = "Image 540 x 360")]
        public string Image540X360 { get; set; }

        [Display(Name = "Image 445 x 255")]
        public string Image445X255 { get; set; }

        [Display(Name = "Video Link")]
        public string VideoLink { get; set; }
    }
}

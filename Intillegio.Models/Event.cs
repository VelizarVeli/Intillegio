using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;

namespace Intillegio.Models
{
    public class Event : BaseId
    {
        public Event()
        {
            this.EventImages = new HashSet<EventImage>();
        }
        
        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime StartDateTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Place { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Town { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        public string Image540X360 { get; set; }

        [Required]
        public string Image445X255 { get; set; }

        public string VideoLink { get; set; }

        public ICollection<EventImage> EventImages { get; set; }
    }
}

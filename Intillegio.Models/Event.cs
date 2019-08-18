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
        [DataType(DataType.DateTime)]
        public DateTime StartingDate { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Place { get; set; }

        [Required]
        public string Image320X405 { get; set; }

        public string VideoLink { get; set; }

        public ICollection<EventImage> EventImages { get; set; }
    }
}

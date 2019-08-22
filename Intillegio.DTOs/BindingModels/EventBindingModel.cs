using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;
using Intillegio.Models;

namespace Intillegio.DTOs.BindingModels
{
   public class EventBindingModel
    {
        public EventBindingModel()
        {
            this.EventImages = new HashSet<EventImage>();
        }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Starting Date")]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Starting Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Ending Time")]
        public DateTime EndTime { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Place { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Town { get; set; }

        [Required]
        [StringLength(LengthConstants.AboutMaxLength, MinimumLength = LengthConstants.AboutMinLength)]
        public string About { get; set; }

        [Required]
        public string Image540X360 { get; set; }

        [Required]
        public string Image445X255 { get; set; }

        public string VideoLink { get; set; }

        public ICollection<EventImage> EventImages { get; set; }
    }
}

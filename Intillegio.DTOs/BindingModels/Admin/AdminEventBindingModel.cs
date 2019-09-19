using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;
using Intillegio.Models;

namespace Intillegio.DTOs.BindingModels.Admin
{
    public class AdminEventBindingModel
    {
        public AdminEventBindingModel()
        {
            this.EventImages = new HashSet<EventImage>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Starts")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "Ends")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMMM yyyy H:mm}")]
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
        [Display(Name = "Image 540 x 360")]
        public string Image540X360 { get; set; }

        [Required]
        [Display(Name = "Image 445 x 255")]
        public string Image445X255 { get; set; }

        public string VideoLink { get; set; }

        [Display(Name = "Event Images")]
        public ICollection<EventImage> EventImages { get; set; }
    }
}

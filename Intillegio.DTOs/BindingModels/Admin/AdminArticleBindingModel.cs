﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;
using Intillegio.Models;

namespace Intillegio.DTOs.BindingModels.Admin
{
    public class AdminArticleBindingModel
    {
        public AdminArticleBindingModel()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        public string Category { get; set; }

        public string NewCategory { get; set; }

        [Display(Name = "Video Link")]
        public string VideoLink { get; set; }

        [Required]
        [Display(Name = "Image 65 x 65")]
        public string Image65X65 { get; set; }

        [Required]
        [Display(Name = "Image 350 x 220")]
        public string Image350X220 { get; set; }

        [Required]
        [Display(Name = "Image 390 x 245")]
        public string Image390X245 { get; set; }

        [Display(Name = "Image for the video 400 x 250")]
        public string VideoImage400X250 { get; set; }

        [Required]
        [Display(Name = "Image 825 x 530")]
        public string Image825X530 { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime Date { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}

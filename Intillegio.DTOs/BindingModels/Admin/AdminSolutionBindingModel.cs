using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;
using Intillegio.Models;

namespace Intillegio.DTOs.BindingModels.Admin
{
   public class AdminSolutionBindingModel
    {
        public AdminSolutionBindingModel()
        {
            FinancialPlanningStrategies = new HashSet<FinancialPlanningStrategy>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Name { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        [Display(Name = "Image 825 x 445")]
        public string Image825X445 { get; set; }

        [Required]

        [Display(Name = "Image 255 x 155")]
        public string Image255X155 { get; set; }

        [Required]
        [Display(Name = "Image 65 x 65")]
        public string Image65X65 { get; set; }

        [Display(Name = "Financial Planning Strategies")]
        public ICollection<FinancialPlanningStrategy> FinancialPlanningStrategies { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;
using Intillegio.Models;

namespace Intillegio.DTOs.BindingModels
{
   public class SolutionBindingModel
    {
        public SolutionBindingModel()
        {
            FinancialPlanningStrategies = new HashSet<FinancialPlanningStrategy>();
        }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(LengthConstants.AboutMaxLength, MinimumLength = LengthConstants.AboutMinLength)]
        public string About { get; set; }

        [Required]
        public string Image825X445 { get; set; }

        public ICollection<FinancialPlanningStrategy> FinancialPlanningStrategies { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Intillegio.Common.Constants;

namespace Intillegio.Models
{
   public class Solution : BaseId
    {
        public Solution()
        {
            FinancialPlanningStrategies = new HashSet<FinancialPlanningStrategy>();
        }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Name { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        public string Image825X445 { get; set; }

        [Required]
        public string Image255X155 { get; set; }

        [Required]
        public string Image65X65 { get; set; }

        public ICollection<FinancialPlanningStrategy> FinancialPlanningStrategies { get; set; }
    }
}

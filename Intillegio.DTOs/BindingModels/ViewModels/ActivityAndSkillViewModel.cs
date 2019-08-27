using System.ComponentModel.DataAnnotations;

namespace Intillegio.DTOs.BindingModels.ViewModels
{
   public class ActivityAndSkillViewModel
    {
        public int ActivityAndSkillId { get; set; }

        [Display(Name = "Activity or Skill")]
        public string Name { get; set; }

        public int TeamMemberId { get; set; }
    }
}

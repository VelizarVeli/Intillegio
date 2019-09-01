using System.ComponentModel.DataAnnotations;

namespace Intillegio.Common.ViewModels.Admin
{
    public class AdminTeamMemberViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}

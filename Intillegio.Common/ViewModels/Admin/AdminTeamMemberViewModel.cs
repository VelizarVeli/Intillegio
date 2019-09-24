using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Intillegio.Common.ViewModels.Admin
{
    [DebuggerDisplay("{" + nameof(Name) + "}")]
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

using System.ComponentModel.DataAnnotations;

namespace Intillegio.Common.ViewModels
{
    public class TeamMemberViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        public string Image350X290 { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string Skype { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Intillegio.Common.ViewModels
{
    public class TeamMemberViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string About { get; set; }

        public string Image350X290 { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string Skype { get; set; }
    }
}

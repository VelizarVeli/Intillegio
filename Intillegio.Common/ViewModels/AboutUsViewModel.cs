using System.Collections.Generic;

namespace Intillegio.Common.ViewModels
{
   public class AboutUsViewModel
    {
        public IEnumerable<SolutionViewModel> Solutions { get; set; }
        public IEnumerable<TeamMemberViewModel> TeamMembers { get; set; }
        public Icons Icons { get; set; } = new Icons();
    }
}

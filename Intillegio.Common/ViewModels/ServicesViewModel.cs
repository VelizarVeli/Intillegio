using System.Collections.Generic;

namespace Intillegio.Common.ViewModels
{
   public class ServicesViewModel
    {
        public IEnumerable<SolutionViewModel> AllSolutions { get; set; }
        public SolutionViewModel Solution { get; set; }
    }
}

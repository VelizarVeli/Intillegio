using System.Collections.Generic;
using Intillegio.Emails;

namespace Intillegio.Common.ViewModels
{
   public class ServicesViewModel
    {
        public IEnumerable<SolutionViewModel> AllSolutions { get; set; }
        public SolutionViewModel Solution { get; set; }
        public EmailCallback Callback { get; set; }
    }
}

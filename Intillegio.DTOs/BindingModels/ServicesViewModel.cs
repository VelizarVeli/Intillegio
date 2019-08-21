using System.Collections.Generic;
using Intillegio.Common.ViewModels;
using Intillegio.Emails;

namespace Intillegio.DTOs.BindingModels
{
   public class ServicesViewModel
    {
        public IEnumerable<SolutionViewModel> AllSolutions { get; set; }
        public SolutionBindingModel Solution { get; set; }
        public EmailCallback Callback { get; set; }
    }
}

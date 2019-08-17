using System.Collections.Generic;

namespace Intillegio.Common.ViewModels
{
   public class HomeViewModel
    {
        public IEnumerable<ProjectViewModel> Projects { get; set; }
        public IEnumerable<ArticleViewModel> Articles { get; set; }
    }
}

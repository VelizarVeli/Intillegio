using System.Collections.Generic;
using Microsoft.Build.Framework.XamlTypes;

namespace Intillegio.Common.ViewModels
{
   public class BlogViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ArticleViewModel> Articles { get; set; }
    }
}

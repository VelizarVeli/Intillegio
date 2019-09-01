using System.ComponentModel.DataAnnotations;

namespace Intillegio.Common.ViewModels.Admin
{
    public class AdminProjectViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Stage { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}

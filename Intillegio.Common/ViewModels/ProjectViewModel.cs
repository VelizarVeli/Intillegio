using System.ComponentModel.DataAnnotations;

namespace Intillegio.Common.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Image 350 x 350")]
        public string Image350X350 { get; set; }

        public string Name { get; set; }

        public string Stage { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}

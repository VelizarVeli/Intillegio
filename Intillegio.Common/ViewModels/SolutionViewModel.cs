using System.ComponentModel.DataAnnotations;

namespace Intillegio.Common.ViewModels
{
    public class SolutionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Image 255 x 155")]
        public string Image255X155 { get; set; }

        public string Name { get; set; }

        public string About { get; set; }
    }
}

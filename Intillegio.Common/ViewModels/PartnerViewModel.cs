using System.ComponentModel.DataAnnotations;

namespace Intillegio.Common.ViewModels
{
    public class PartnerViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        [Display(Name = "Logo 155 x 75")]
        public string Logo155X75 { get; set; }
    }
}

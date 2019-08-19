using System.ComponentModel.DataAnnotations;

namespace Intillegio.Models
{
    public enum Stage
    {
        [Display(Name = "In Progress")]
        InProgress = 1,
        Completed,
        UpComing
    }
}

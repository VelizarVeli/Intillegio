using System.ComponentModel.DataAnnotations;
using Intillegio.Models.Contracts;

namespace Intillegio.Models
{
    public abstract class BaseId : IBaseId<int>
    {
        [Key]
        public int Id { get; set; } 
    }
}

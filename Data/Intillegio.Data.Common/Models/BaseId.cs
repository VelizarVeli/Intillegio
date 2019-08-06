using System;
using System.ComponentModel.DataAnnotations;
using Intillegio.Data.Common.Models.Contracts;

namespace Intillegio.Data.Common.Models
{
    public abstract class BaseId : IBaseId<Guid>
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}

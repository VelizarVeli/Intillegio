using System;
using System.ComponentModel.DataAnnotations;

namespace Intillegio.Data.Common.Models.Contracts
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        [DataType(DataType.Date)]
        DateTime? DeletedOn { get; set; }
    }
}

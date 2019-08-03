namespace Intillegio.Data.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        [DataType(DataType.Date)]
        DateTime? DeletedOn { get; set; }
    }
}

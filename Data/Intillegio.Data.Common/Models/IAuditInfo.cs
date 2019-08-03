namespace Intillegio.Data.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public interface IAuditInfo
    {
        [DataType(DataType.Date)]
        DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        DateTime? ModifiedOn { get; set; }
    }
}

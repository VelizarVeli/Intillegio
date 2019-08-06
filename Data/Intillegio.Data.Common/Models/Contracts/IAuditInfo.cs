using System;
using System.ComponentModel.DataAnnotations;

namespace Intillegio.Data.Common.Models.Contracts
{
    public interface IAuditInfo
    {
        [DataType(DataType.Date)]
        DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        DateTime? ModifiedOn { get; set; }
    }
}

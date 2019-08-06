using Intillegio.Data.Common.Models.Contracts;

namespace Intillegio.Data.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseModel<TKey> : IAuditInfo
    {
        [Key]
        public TKey Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ModifiedOn { get; set; }
    }
}

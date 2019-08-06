using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Intillegio.Data.Common.Models.Contracts
{
    public interface IBaseId<T>
    {
        [Key]
        T Id { get; set; }
    }
}

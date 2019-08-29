using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Models;

namespace Intillegio.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
    }
}

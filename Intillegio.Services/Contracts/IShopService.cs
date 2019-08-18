using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;
using Intillegio.DTOs.BindingModels;

namespace Intillegio.Services.Contracts
{
    public interface IShopService
    {
        IEnumerable<ProductViewModel> GetAllProducts();
        Task<ProductBindingModel> GetProductDetailsAsync(int id);
    }
}

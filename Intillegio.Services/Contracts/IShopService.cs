using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.DTOs.BindingModels;
using Intillegio.DTOs.BindingModels.Admin;

namespace Intillegio.Services.Contracts
{
    public interface IShopService
    {
        IEnumerable<ProductViewModel> GetAllProducts();
        Task<ProductBindingModel> GetProductDetailsAsync(int id);
        IEnumerable<AdminProductViewModel> GetAllProductsForAdmin();
        Task<AdminProductBindingModel> GetProductDetailsForAdminAsync(int id);
        Task DeleteProductAsync(int id);
    }
}

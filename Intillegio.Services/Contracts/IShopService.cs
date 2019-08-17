using System.Collections.Generic;
using Intillegio.Common.ViewModels;

namespace Intillegio.Services.Contracts
{
    public interface IShopService
    {
        IEnumerable<ProductViewModel> GetAllProducts();
    }
}

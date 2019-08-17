using System.Collections.Generic;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Data.Data;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Intillegio.Services
{
    public class ShopService : BaseService, IShopService
    {
        public ShopService(IntillegioContext dbContext, IMapper mapper, UserManager<IntillegioUser> userManager)
            : base(dbContext, mapper, userManager)
        {
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var allProducts = Mapper.Map<IEnumerable<ProductViewModel>>(
                DbContext.Products);

            return allProducts;
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.Data.Data;
using Intillegio.DTOs.BindingModels;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ProductBindingModel> GetProductDetailsAsync(int id)
        {
            var product = await DbContext.Products.SingleOrDefaultAsync(i => i.Id == id);

            var productDto = Mapper.Map<ProductBindingModel>(product);

            return productDto;
        }

        public IEnumerable<AdminProductViewModel> GetAllProductsForAdmin()
        {
            var allProducts = Mapper.Map<IEnumerable<AdminProductViewModel>>(
                DbContext.Products);

            return allProducts;
        }

        public async Task<AdminProductBindingModel> GetProductDetailsForAdminAsync(int id)
        {
            var product = await DbContext
                .Products
                .Include(c => c.Category)
                .Include(i => i.ProductImages)
                .Include(b => b.Reviews)
                .SingleOrDefaultAsync(i => i.Id == id);

            var productDto = Mapper.Map<AdminProductBindingModel>(product);
            productDto.Category = product.Category.CategoryName;
            return productDto;
        }
    }
}

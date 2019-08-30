using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.Data.Data;
using Intillegio.DTOs.BindingModels;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Intillegio.Services
{
    public class ShopService : BaseService, IShopService
    {
        public ShopService(IntillegioContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
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

        public async Task DeleteProductAsync(int id)
        {
            var product = DbContext.Products.SingleOrDefault(e => e.Id == id);
            if (product != null)
            {
                DbContext.Products.Remove(product);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task AddProductAsync(AdminProductBindingModel product)
        {
            var model = Mapper.Map<Product>(product);
            model.CategoryId = DbContext.Categories.FirstOrDefault(c => c.CategoryName == product.Category).Id;
            await DbContext.Products.AddAsync(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var allCategories = await DbContext.Categories.ToListAsync();

            return allCategories;
        }

        public async Task ProductEditAsync(AdminEditProductBindingModel product, int id)
        {
            var model = DbContext.Products.FirstOrDefault(i => i.Id == id);

            Mapper.Map(product, model);
            DbContext.Products.Update(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task<AdminEditProductBindingModel> GetProductDetailsForAdminEditAsync(int id)
        {

            var product = await DbContext
                .Products
                .Include(a => a.Reviews)
                .Include(ab => ab.ProductImages)
                .SingleOrDefaultAsync(i => i.Id == id);

            var productDto = Mapper.Map<AdminEditProductBindingModel>(product);
            var category = await DbContext.Categories.SingleOrDefaultAsync(c => c.Id == product.CategoryId);
            productDto.Category = category.CategoryName;
            return productDto;
        }
    }
}

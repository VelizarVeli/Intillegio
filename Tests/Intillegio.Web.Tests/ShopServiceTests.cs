using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.Data.Data;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.Models;
using Intillegio.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Intillegio.Web.Tests
{
    public class ShopServiceTests
    {
        [Fact]
        public void GetAllProductsShouldGetProductsCorrectly()
        {
            var mockList = new List<ProductViewModel>
            {
                new ProductViewModel
                {
                    Name = "Return of the Jedi",
                    Category = "Books",
                    Image255X325 = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1328866630l/555314.jpg",
                    Price = 12.3M,
                    Stars = 5
                },
                new ProductViewModel
                {
                    Name = "The Empire Strikes Back",
                    Category = "Books",
                    Image255X325 = "https://pictures.abebooks.com/isbn/9780345400789-uk.jpg",
                    Price = 12.3M,
                    Stars = 5
                }
            };

            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Get_All_Products_Db")
                .Options;
            var dbContext = new IntillegioContext(options);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<IEnumerable<ProductViewModel>>(
                    dbContext.Products))
                .Returns(mockList);

            var productCount = 6;

            for (int i = 0; i < productCount; i++)
            {
                dbContext.Products.Add(new Product());
            }

            dbContext.SaveChanges();
            var service = new ShopService(dbContext, mapper.Object);

            var allProducts = service.GetAllProducts();

            Assert.NotNull(allProducts);
        }

        [Fact]
        public void GetAllCategoriesShouldReturnCategories()
        {
            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Get_All_Categories_Db")
                .Options;

            var dbContext = new IntillegioContext(options);

            var categoriesCount = 4;
            var compareCategories = new List<Category>();
            for (int i = 0; i < categoriesCount; i++)
            {
                var category = new Category();
                dbContext.Categories.Add(category);
                compareCategories.Add(category);
            }

            dbContext.SaveChanges();

            var service = new ShopService(dbContext, null);

            var categories = service.GetAllCategories();

            Assert.Equal(compareCategories, categories.Result);
        }

       // [Fact]
        public void AddProductAsyncShouldReturnProductCorrectly()
        {
            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Add_Product_Db")
                .Options;

            var dbContext = new IntillegioContext(options);

            var productBindingModel = new AdminProductBindingModel
            {
                Name = "The Empire Strikes Back",
                Image255X325 = "https://pictures.abebooks.com/isbn/9780345400789-uk.jpg",
                Price = 12.3M,
                Image135X135 = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1328866630l/555314.jpg"
            };

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<Product>(productBindingModel))
                .Returns(new Product
                {
                    Name = "The Empire Strikes Back",
                    Image255X325 = "https://pictures.abebooks.com/isbn/9780345400789-uk.jpg",
                    Price = 12.3M,
                    Image135X135 = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1328866630l/555314.jpg"
                });

            var service = new ShopService(dbContext, mapper.Object);
            service.AddProductAsync(productBindingModel);
            Assert.True(dbContext.Products.Any(n => n.Name == productBindingModel.Name));
            Assert.True(dbContext.Products.Any(a => a.Image135X135 == productBindingModel.Image135X135));
            Assert.True(dbContext.Products.Any(b => b.Price == productBindingModel.Price));
            Assert.True(dbContext.Products.Any(c => c.Image135X135 == productBindingModel.Image135X135));
        }

        [Fact]
        public void GetAllProductsForAdminShouldGetProductsCorrectly()
        {
            var mockList = new List<AdminProductViewModel>
            {
                new AdminProductViewModel
                {
                    Name = "Return of the Jedi",
                    StockKeepingUnit = "Books-StarWars-6",
                    Price = 12.3M,
                    Id = 1
                },
                new AdminProductViewModel
                {
                    Name = "The Empire Strikes Back",
                    StockKeepingUnit = "Books-StarWars-5",
                    Price = 12.3M,
                    Id = 2
                }
            };

            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Get_All_Products_for_Admin_Db")
                .Options;
            var dbContext = new IntillegioContext(options);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<IEnumerable<AdminProductViewModel>>(
                    dbContext.Products))
                .Returns(mockList);

            var productCount = 3;

            for (int i = 0; i < productCount; i++)
            {
                dbContext.Products.Add(new Product());
            }

            dbContext.SaveChanges();
            var service = new ShopService(dbContext, mapper.Object);

            var allProducts = service.GetAllProductsForAdmin();

            Assert.NotNull(allProducts);
        }
    }
}

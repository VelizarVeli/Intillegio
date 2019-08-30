using System.Collections.Generic;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.Data.Data;
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

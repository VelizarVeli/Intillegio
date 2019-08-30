using System.Collections.Generic;
using Intillegio.Data.Data;
using Intillegio.Models;
using Intillegio.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Intillegio.Web.Tests
{
    public class ProjectsServiceTests
    {
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
                var category = new  Category();
                dbContext.Categories.Add(category);
                compareCategories.Add(category);
            }

            dbContext.SaveChanges();

            var service = new ProjectsService(dbContext, null);

            var categories = service.GetAllCategories();

            Assert.Equal(compareCategories, categories.Result);
        }
    }
}

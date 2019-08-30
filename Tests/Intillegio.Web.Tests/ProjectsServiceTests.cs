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
    public class ProjectsServiceTests
    {
        [Fact]
        public void GetAllProjectsShouldGetProjectsCorrectly()
        {
            var mockList = new List<ProjectViewModel>
            {
                new ProjectViewModel
                {
                    Name = "Venera Base",
                    CategoryName = "Building",
                    Stage = "UpComing",
                    Image350X350 = "https://i.postimg.cc/PrSsz2qS/141222115103-cloud-city-horizontal-large-gallery.png"
                }
            };

            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Get_All_Projects_Db")
                .Options;
            var dbContext = new IntillegioContext(options);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<IEnumerable<ProjectViewModel>>(
                    dbContext.Projects))
                .Returns(mockList);

            var projectsCount = 3;

            for (int i = 0; i < projectsCount; i++)
            {
                dbContext.Projects.Add(new Project());
            }

            dbContext.SaveChanges();
            var service = new ProjectsService(dbContext, mapper.Object);

            var allProjects = service.GetAllProjects();

            Assert.NotNull(allProjects);
        }

        [Fact]
        public void GetAllCategoriesShouldReturnCategoriesCorrectly()
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

        [Fact]
        public void GetAllPartnersShouldReturnPartnersCorrectly()
        {
            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Get_All_Partners_Db")
                .Options;

            var dbContext = new IntillegioContext(options);

            var partnersCount = 3;
            var comparePartners = new List<Partner>();
            for (int i = 0; i < partnersCount; i++)
            {
                var partner = new Partner();
                dbContext.Partners.Add(partner);
                comparePartners.Add(partner);
            }

            dbContext.SaveChanges();

            var service = new ProjectsService(dbContext, null);

            var partners = service.GetAllPartners();

            Assert.Equal(comparePartners, partners.Result);
        }

        [Fact]
        public void GetAllProjectsForAdminShouldGetProjectsCorrectly()
        {
            var mockList = new List<AdminProjectViewModel>
            {
                new AdminProjectViewModel
                {
                    Name = "Venera Base",
                    CategoryName = "Building",
                    Stage = "UpComing"
                }
            };

            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Get_All_Projects_for_Admin_Db")
                .Options;
            var dbContext = new IntillegioContext(options);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<IEnumerable<AdminProjectViewModel>>(
                    dbContext.Projects))
                .Returns(mockList);

            var projectsCount = 3;

            for (int i = 0; i < projectsCount; i++)
            {
                dbContext.Projects.Add(new Project());
            }

            dbContext.SaveChanges();
            var service = new ProjectsService(dbContext, mapper.Object);

            var allProjects = service.GetAllProjectsForAdmin();

            Assert.NotNull(allProjects);
        }
    }
}

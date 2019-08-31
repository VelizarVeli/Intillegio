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
    public class SolutionsServiceTests
    {
        [Fact]
        public void GetAllSolutionsShouldGetSolutionsCorrectly()
        {
            var mockList = new List<SolutionViewModel>
            {
                new SolutionViewModel
                {
                    Name = "Business Solutions",
                    Image255X155 = "http://specthemes.com/redbiz/redbiz-5/img/content/services/service-1b.jpg",
                    About = "A business solution comes in terms of marketing and advertising, payroll,accounting market research and investigation, among the other essential Business Technology .",
                },
                new SolutionViewModel
                {
                    Name = "Development Manager",
                    Image255X155 = "http://specthemes.com/redbiz/redbiz-5/img/content/services/service-2b.jpg",
                    About = "Career Development Process- Development managers are responsible for developing the group.",
                }
            };

            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Get_All_Solutions_Db")
                .Options;
            var dbContext = new IntillegioContext(options);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<IEnumerable<SolutionViewModel>>(
                    dbContext.Solutions))
                .Returns(mockList);

            var solutionCount = 6;

            for (int i = 0; i < solutionCount; i++)
            {
                dbContext.Solutions.Add(new Solution());
            }

            dbContext.SaveChanges();
            var service = new SolutionsService(dbContext, mapper.Object);

            var allSolutions = service.GetAllSolutions();

            Assert.NotNull(allSolutions);
        }


        [Fact]
        public void AddSolutionAsyncShouldReturnSolutionCorrectly()
        {
            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Add_Solution_Db")
                .Options;

            var dbContext = new IntillegioContext(options);

            var solutionBindingModel = new AdminSolutionBindingModel
            {
                Name = "Development Manager",
                Image255X155 = "http://specthemes.com/redbiz/redbiz-5/img/content/services/service-2b.jpg",
                About = "Career Development Process- Development managers are responsible for developing the group.",
            };

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<Solution>(solutionBindingModel))
                .Returns(new Solution
                {
                    Name = "Development Manager",
                    Image255X155 = "http://specthemes.com/redbiz/redbiz-5/img/content/services/service-2b.jpg",
                    About = "Career Development Process- Development managers are responsible for developing the group.",
                });

            var service = new SolutionsService(dbContext, mapper.Object);
            service.AddSolutionAsync(solutionBindingModel);
            Assert.True(dbContext.Solutions.Any(n => n.Name == solutionBindingModel.Name));
            Assert.True(dbContext.Solutions.Any(a => a.Image255X155 == solutionBindingModel.Image255X155));
            Assert.True(dbContext.Solutions.Any(b => b.About == solutionBindingModel.About));
        }

        [Fact]
        public void GetAllSolutionsForAdminShouldGetSolutionsCorrectly()
        {
            var mockList = new List<AdminSolutionViewModel>
            {
                new AdminSolutionViewModel
                {
                    Name = "Business Solutions",
                    Image255X155 = "http://specthemes.com/redbiz/redbiz-5/img/content/services/service-1b.jpg",
                    About = "A business solution comes in terms of marketing and advertising, payroll,accounting market research and investigation, among the other essential Business Technology .",
                },
                new AdminSolutionViewModel
                {
                    Name = "Development Manager",
                    Image255X155 = "http://specthemes.com/redbiz/redbiz-5/img/content/services/service-2b.jpg",
                    About = "Career Development Process- Development managers are responsible for developing the group.",
                }
            };

            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Get_All_Solutions_for_Admin_Db")
                .Options;
            var dbContext = new IntillegioContext(options);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<IEnumerable<AdminSolutionViewModel>>(
                    dbContext.Solutions))
                .Returns(mockList);

            var solutionCount = 6;

            for (int i = 0; i < solutionCount; i++)
            {
                dbContext.Solutions.Add(new Solution());
            }

            dbContext.SaveChanges();
            var service = new SolutionsService(dbContext, mapper.Object);

            var allSolutions = service.GetAllSolutionsForAdmin();

            Assert.NotNull(allSolutions);
        }
    }
}

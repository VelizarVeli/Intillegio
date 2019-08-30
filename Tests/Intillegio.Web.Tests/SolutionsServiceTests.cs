using System.Collections.Generic;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Data.Data;
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
        public void GetAllSolutionsShouldGetSolutionsCorrecly()
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
                .UseInMemoryDatabase(databaseName: "Get_All_Articles_Db")
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
    }
}

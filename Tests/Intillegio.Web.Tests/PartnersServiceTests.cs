using System;
using System.Collections.Generic;
using System.Globalization;
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
  public  class PartnersServiceTests
    {
        [Fact]
        public void GetPartnersLogosShouldGetPartnersLogosCorrecly()
        {
            var mockList = new List<PartnerViewModel>
            {
                new PartnerViewModel
                {
                    Name = "Google",
                    Logo155X75 = "https://i.postimg.cc/3wD5nJWy/Google.png",
                    About = "Our mission is to organize the world’s information and make it universally accessible and useful.",
                },
                new PartnerViewModel
                {
                    Name = "NASA",
                    Logo155X75 = "https://i.postimg.cc/zfMDGcHh/8867-Microsoft-5-F00-Logo-2-D00-for-2-D00-screen.jpg",
                    About = "Our people and their stories are what makes us one of the world’s most dynamic companies.",
                },
                new PartnerViewModel
                {
                    Name = "Microsoft",
                    Logo155X75 = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e5/NASA_logo.svg/1920px-NASA_logo.svg.png",
                    About = "The National Aeronautics and Space Administration (NASA, /ˈnæsə/) is an independent agency of the United States Federal Government responsible for the civilian space program, as well as aeronautics and aerospace research. NASA was established in 1958, succeeding the National Advisory Committee for Aeronautics (NACA).",
                }
            };

            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Get_All_Articles_Db")
                .Options;
            var dbContext = new IntillegioContext(options);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<IEnumerable<PartnerViewModel>>(
                    dbContext.Partners))
                .Returns(mockList);

            var partnerCount = 3;

            for (int i = 0; i < partnerCount; i++)
            {
                dbContext.Partners.Add(new Partner());
            }

            dbContext.SaveChanges();
            var service = new PartnersService(dbContext, mapper.Object);

            var allPartners = service.GetPartnersLogos();

            Assert.NotNull(allPartners);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
   public class EventsServiceTests
    {
        [Fact]
        public void GetAllEventsShouldGetEventsCorrectly()
        {
            var mockList = new List<EventViewModel>
            {
                new EventViewModel
                {
                    StartDateTime = DateTime.ParseExact("2019-08-22 0:00", "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture),
                    EndTime = DateTime.ParseExact("2019-08-23 3:00", "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture),
                    Name = "BNI Gathering",
                    Place = "Elias Canneti Centre",
                    Town = "Ruse, Bulgaria",
                    Image540X360 = "https://media.licdn.com/dms/image/C5612AQFTYJDHoEc7eQ/article-cover_image-shrink_423_752/0?e=1571875200&v=beta&t=RhecYVQlaqEqXMy0R7j1TW-B9Pca-ez2EOJlSFNIZ_o",
                    Image445X255 = "https://media.licdn.com/dms/image/C5612AQFTYJDHoEc7eQ/article-cover_image-shrink_423_752/0?e=1571875200&v=beta&t=RhecYVQlaqEqXMy0R7j1TW-B9Pca-ez2EOJlSFNIZ_o",
                    VideoLink = "https://www.youtube.com/watch?v=CbNkack6Bww&feature=youtu.be",
                    About = "The more KNOWLEDGE you SHARE, the more POINTS you will have. Exchange them for learning NEW SKILLS and SPECIAL AWARDS!",
                }
            };

            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Get_All_Events_Db")
                .Options;
            var dbContext = new IntillegioContext(options);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<IEnumerable<EventViewModel>>(
                    dbContext.Articles))
                .Returns(mockList);

            var eventsCount = 3;

            for (int i = 0; i < eventsCount; i++)
            {
                dbContext.Events.Add(new Event());
            }

            dbContext.SaveChanges();
            var service = new EventsService(dbContext, mapper.Object);

            var allEvents =  service.GetAllEvents();

            Assert.NotNull(allEvents);
        }

        [Fact]
        public void GetAllEventsForAdminShouldGetEventsCorrectly()
        {
            var mockList = new List<AdminEventViewModel>
            {
                new AdminEventViewModel
                {
                    StartDateTime = DateTime.ParseExact("2019-08-22 0:00", "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture),
                    Name = "BNI Gathering",
                    Place = "Elias Canneti Centre",
                    Town = "Ruse, Bulgaria",
                    Id = 1,
                }
            };

            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Get_All_Events_for_Admin_Db")
                .Options;
            var dbContext = new IntillegioContext(options);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<IEnumerable<AdminEventViewModel>>(
                    dbContext.Articles))
                .Returns(mockList);

            var eventsCount = 8;

            for (int i = 0; i < eventsCount; i++)
            {
                dbContext.Events.Add(new Event());
            }

            dbContext.SaveChanges();
            var service = new EventsService(dbContext, mapper.Object);

            var allEvents = service.GetAllEventsForAdmin();

            Assert.NotNull(allEvents);
        }
    }
}

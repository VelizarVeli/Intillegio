using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Data.Data;
using Intillegio.DTOs.BindingModels;
using Intillegio.Models;
using Intillegio.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Intillegio.Web.Tests
{
    public class AboutServiceTests
    {
        [Fact]
        public void GetAllTeamMembersShouldGetTeamMambersCorrecly()
        {
            var mockList = new List<TeamMemberViewModel>();
            mockList.Add(new TeamMemberViewModel
            {
                About = "Anne Smith (born July 1, 1959) is an educational psychologist",
                Name = "Ann Smith",
                Facebook = "lkjkljklasdf",
                Image350X290 = "lkjfasd",
                Instagram = "fdaasdf",
                Position = "fdasadf",
                Skype = "fdaasdf",
                Twitter = "fdaasdf"
            });

            mockList.Add(new TeamMemberViewModel
            {
                About = "Anne Smith (born July 1, 1959) is an educational psychologist",
                Name = "Ann Smith",
                Facebook = "lkjkljklasdf",
                Image350X290 = "lkjfasd",
                Instagram = "fdaasdf",
                Position = "fdasadf",
                Skype = "fdaasdf",
                Twitter = "fdaasdf"
            });
            var options = new DbContextOptionsBuilder<IntillegioContext>()
                    .UseInMemoryDatabase(databaseName: "Get_All_TeamMembers_Db")
                    .Options;
            var dbContext = new IntillegioContext(options);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<IEnumerable<TeamMemberViewModel>>(
                dbContext.TeamMembers))
            .Returns(mockList);

            var teamMembersCount = 5;

            for (int i = 0; i < teamMembersCount; i++)
            {
                dbContext.TeamMembers.Add(new TeamMember());
            }

            dbContext.SaveChanges();
            var service = new AboutService(dbContext, mapper.Object);

            var allTeamMembers = service.GetAllTeamMembers();

            Assert.NotNull(allTeamMembers);
            //Assert.Equal();
        }

        [Fact]
        public void TeamMemberBindingModelGetTeamMemberDetailsAsyncShouldReturnTeamMemberDetailsCorrectly()
        {
            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Get_TeamMember_Details_Db")
                .Options;

            var dbContext = new IntillegioContext(options);

            var service = new AboutService(dbContext, null);

            var teamMemberBindingModel = new TeamMemberBindingModel
            {
                Name = "Jack Semper",
                Position = "Majority Owner",
                About = "Born and raised in Pretoria, South Africa, Jack moved to Canada when he was 17 to attend Queen\'s University.",
                PhoneNumber = "(+123) 123 456 789",
                Email = "semper@gmail.com",
                Image350X290 = "http://specthemes.com/redbiz/redbiz-5/img/team/team-05.jpg",
                Facebook = "https://www.facebook.com/baianodesalvadorBA",
                Twitter = "https://twitter.com/jpsemper",
                Instagram = "https://www.instagram.com/tennillejack/",
                Skype = "AnnSmith",
                Linkedin = "https://www.linkedin.com/company/semper/"
            };
            var teamMember1 = dbContext
                .TeamMembers
                .Include(a => a.ActivitiesAndSkills)
                .Include(p => p.ProffessionalSkills)
                .SingleOrDefaultAsync(i => i.Id == 1);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<TeamMemberBindingModel>(teamMember1))
                .Returns(teamMemberBindingModel);
            service.GetTeamMemberDetailsAsync(1);

            var teamMember = dbContext.TeamMembers.FirstOrDefault();

            Assert.NotNull(teamMember);
            Assert.Equal(teamMemberBindingModel.Name, teamMember.Name);
            Assert.Equal(teamMemberBindingModel.Position, teamMember.Position);
            Assert.Equal(teamMemberBindingModel.About, teamMember.About);
            Assert.Equal(teamMemberBindingModel.PhoneNumber, teamMember.PhoneNumber);
            Assert.Equal(teamMemberBindingModel.Email, teamMember.Email);
            Assert.Equal(teamMemberBindingModel.Image350X290, teamMember.Image350X290);
            Assert.Equal(teamMemberBindingModel.Facebook, teamMember.Facebook);
            Assert.Equal(teamMemberBindingModel.Twitter, teamMember.Twitter);
            Assert.Equal(teamMemberBindingModel.Instagram, teamMember.Instagram);
            Assert.Equal(teamMemberBindingModel.Skype, teamMember.Skype);
            Assert.Equal(teamMemberBindingModel.Linkedin, teamMember.Linkedin);
        }

        [Fact]
        public void AddTeamMemberAsyncShouldReturnTeamMemberCorrectly()
        {
            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Get_TeamMember_Details_Db")
                .Options;

            var dbContext = new IntillegioContext(options);

            var service = new AboutService(dbContext, null);

            var teamMemberBindingModel = new TeamMemberBindingModel
            {
                Name = "Jack Semper",
                Position = "Majority Owner",
                About = "Born and raised in Pretoria, South Africa, Jack moved to Canada when he was 17 to attend Queen\'s University.",
                PhoneNumber = "(+123) 123 456 789",
                Email = "semper@gmail.com",
                Image350X290 = "http://specthemes.com/redbiz/redbiz-5/img/team/team-05.jpg",
                Facebook = "https://www.facebook.com/baianodesalvadorBA",
                Twitter = "https://twitter.com/jpsemper",
                Instagram = "https://www.instagram.com/tennillejack/",
                Skype = "AnnSmith",
                Linkedin = "https://www.linkedin.com/company/semper/"
            };

            service.GetTeamMemberDetailsAsync(1);

            var teamMember = dbContext.TeamMembers.FirstOrDefault();

            Assert.NotNull(teamMember);
            Assert.Equal(teamMemberBindingModel.Name, teamMember.Name);
            Assert.Equal(teamMemberBindingModel.Position, teamMember.Position);
            Assert.Equal(teamMemberBindingModel.About, teamMember.About);
            Assert.Equal(teamMemberBindingModel.PhoneNumber, teamMember.PhoneNumber);
            Assert.Equal(teamMemberBindingModel.Email, teamMember.Email);
            Assert.Equal(teamMemberBindingModel.Image350X290, teamMember.Image350X290);
            Assert.Equal(teamMemberBindingModel.Facebook, teamMember.Facebook);
            Assert.Equal(teamMemberBindingModel.Twitter, teamMember.Twitter);
            Assert.Equal(teamMemberBindingModel.Instagram, teamMember.Instagram);
            Assert.Equal(teamMemberBindingModel.Skype, teamMember.Skype);
            Assert.Equal(teamMemberBindingModel.Linkedin, teamMember.Linkedin);
        }
    }
}

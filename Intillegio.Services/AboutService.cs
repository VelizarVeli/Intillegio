using System.Collections.Generic;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Data.Data;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Intillegio.Services
{
    public class AboutService : BaseService, IAboutService
    {
        public AboutService(IntillegioContext dbContext, IMapper mapper, UserManager<IntillegioUser> userManager) 
            : base(dbContext, mapper, userManager)
        {
        }

        public IEnumerable<TeamMemberViewModel> GetAllTeamMembers()
        {
            var allTeamMembers = Mapper.Map<IEnumerable<TeamMemberViewModel>>(
                DbContext.TeamMembers);
            return allTeamMembers;
        }
    }
}

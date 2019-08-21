using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Data.Data;
using Intillegio.DTOs.BindingModels;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public async Task<TeamMemberBindingModel> GetTeamMemberDetailsAsync(int id)
        {
            var teamMember = await DbContext.TeamMembers.SingleOrDefaultAsync(i => i.Id == id);

            var teamMemberDto = Mapper.Map<TeamMemberBindingModel>(teamMember);

            return teamMemberDto;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.Data.Data;
using Intillegio.DTOs.BindingModels;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Intillegio.Services
{
    public class AboutService : BaseService, IAboutService
    {
        public AboutService(IntillegioContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
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
            var teamMember = await DbContext
                .TeamMembers
                .Include(a => a.ActivitiesAndSkills)
                .Include(p => p.ProffessionalSkills)
                .SingleOrDefaultAsync(i => i.Id == id);

            var teamMemberDto = Mapper.Map<TeamMemberBindingModel>(teamMember);

            return teamMemberDto;
        }

        public IEnumerable<AdminTeamMemberViewModel> GetTeamMembersForAdmin()
        {
            var allTeamMembers = Mapper.Map<IEnumerable<AdminTeamMemberViewModel>>(
                DbContext.TeamMembers);
            return allTeamMembers;
        }

        public async Task<AdminTeamMemberBindingModel> GetTeamMemberDetailsForAdminAsync(int id)
        {
            var teamMember = await DbContext
                .TeamMembers
                .Include(a => a.ActivitiesAndSkills)
                .Include(p => p.ProffessionalSkills)
                .SingleOrDefaultAsync(i => i.Id == id);

            var teamMemberDto = Mapper.Map<AdminTeamMemberBindingModel>(teamMember);

            return teamMemberDto;
        }

        public async Task DeleteTeamMemberAsync(int id)
        {
            var teamMember = DbContext.TeamMembers.SingleOrDefault(e => e.Id == id);
            if (teamMember != null)
            {
                DbContext.TeamMembers.Remove(teamMember);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task AddTeamMemberAsync(AdminTeamMemberBindingModel teamMember)
        {
            var model = this.Mapper.Map<TeamMember>(teamMember);
            await DbContext.TeamMembers.AddAsync(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task TeamMemberEditAsync(AdminTeamMemberBindingModel teamMember, int modelId)
        {
            var model = DbContext.TeamMembers.FirstOrDefault(i => i.Id == modelId);
            
            Mapper.Map(teamMember, model);
            DbContext.TeamMembers.Update(model);
            await DbContext.SaveChangesAsync();
        }
    }
}

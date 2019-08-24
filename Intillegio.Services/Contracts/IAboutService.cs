using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.DTOs.BindingModels;
using Intillegio.DTOs.BindingModels.Admin;

namespace Intillegio.Services.Contracts
{
   public interface IAboutService
    {
        IEnumerable<TeamMemberViewModel> GetAllTeamMembers();
        Task<TeamMemberBindingModel> GetTeamMemberDetailsAsync(int id);
        IEnumerable<AdminTeamMemberViewModel> GetTeamMembersForAdmin();
        Task<AdminTeamMemberBindingModel> GetTeamMemberDetailsForAdminAsync(int id);

    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;
using Intillegio.DTOs.BindingModels;

namespace Intillegio.Services.Contracts
{
   public interface IAboutService
    {
        IEnumerable<TeamMemberViewModel> GetAllTeamMembers();
        Task<TeamMemberBindingModel> GetTeamMemberDetailsAsync(int id);
    }
}

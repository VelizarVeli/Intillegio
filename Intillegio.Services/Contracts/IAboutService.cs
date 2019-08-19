using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;

namespace Intillegio.Services.Contracts
{
   public interface IAboutService
    {
        Task<IEnumerable<TeamMemberViewModel>> GetAllTeamMembers();
    }
}

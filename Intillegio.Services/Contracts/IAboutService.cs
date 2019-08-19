using System.Collections.Generic;
using Intillegio.Common.ViewModels;

namespace Intillegio.Services.Contracts
{
   public interface IAboutService
    {
        IEnumerable<TeamMemberViewModel> GetAllTeamMembers();
    }
}

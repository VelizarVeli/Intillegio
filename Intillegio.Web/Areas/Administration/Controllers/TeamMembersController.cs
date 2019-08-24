using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Intillegio.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class TeamMembersController : BaseController
    {
        private readonly IAboutService _aboutService;
        private readonly UserManager<IntillegioUser> _currentUser;

        public TeamMembersController(IAboutService aboutService, UserManager<IntillegioUser> currentUser)
        {
            _aboutService = aboutService;
            _currentUser = currentUser;
        }

        public IActionResult TeamMembers()
        {
            var allTeamMembers = _aboutService.GetTeamMembersForAdmin();

            return View(GlobalConstants.AdminAreaPath + "TeamMembers/TeamMembers.cshtml", allTeamMembers);
        }

        public IActionResult AddTeamMember()
        {
            return View(GlobalConstants.AdminAreaPath + "TeamMembers/AddMember.cshtml");
        }

        public async Task<IActionResult> TeamMemberDetails(int id)
        {
            var teamMemberDetails = await _aboutService.GetTeamMemberDetailsForAdminAsync(id);

            if (teamMemberDetails == null)
            {
                return RedirectToAction(ActionConstants.TeamMembers);
            }

            return View("TeamMemberDetails", teamMemberDetails);
        }
    }
}
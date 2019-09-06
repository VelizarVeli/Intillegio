using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Areas.Administration.Controllers
{
    public class TeamMembersController : AdminController
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
            var allTeamMembersForAdmin = _aboutService.GetTeamMembersForAdmin();

            return View(GlobalConstants.AdminAreaPath + "TeamMembers/TeamMembers.cshtml", allTeamMembersForAdmin);
        }

        public IActionResult AddTeamMember()
        {
            return View(GlobalConstants.AdminAreaPath + "TeamMembers/AddTeamMember.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> AddTeamMember(AdminTeamMemberBindingModel model)
        {
            await _aboutService.AddTeamMemberAsync(model);

            return RedirectToAction("TeamMembers");
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

        public async Task<IActionResult> DeleteTeamMemberDetails(int id)
        {
            var deleteDetails = await _aboutService.GetTeamMemberDetailsForAdminAsync(id);

            return View("DeleteTeamMember", deleteDetails);
        }

        public async Task<IActionResult> DeleteTeamMember(int id)
        {
            await _aboutService.DeleteTeamMemberAsync(id);
            return RedirectToAction("TeamMembers");
        }

        public async Task<IActionResult> EditTeamMember(int id)
        {
            var editDetails = await _aboutService.GetTeamMemberDetailsForAdminAsync(id);

            return View("EditTeamMember", editDetails);
        }

        [HttpPost]
        public async Task<IActionResult> TeamMemberEdit(int id, AdminTeamMemberBindingModel model)
        {
            await _aboutService.TeamMemberEditAsync(model, id);
            return RedirectToAction("TeamMembers");
        }
    }
}
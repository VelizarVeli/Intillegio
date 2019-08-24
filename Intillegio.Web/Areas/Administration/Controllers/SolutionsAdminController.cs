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
    public class SolutionsAdminController : BaseController
    {
        private readonly ISolutionsService _solutionsService;
        private readonly UserManager<IntillegioUser> _currentUser;

        public SolutionsAdminController(ISolutionsService solutionsService, UserManager<IntillegioUser> currentUser)
        {
            _solutionsService = solutionsService;
            _currentUser = currentUser;
        }

        public IActionResult SolutionsAdmin()
        {
            var allSolutionsForAdmin = _solutionsService.GetAllSolutionsForAdmin();

            return View(GlobalConstants.AdminAreaPath + "SolutionsAdmin/SolutionsAdmin.cshtml", allSolutionsForAdmin);
        }
    }
}
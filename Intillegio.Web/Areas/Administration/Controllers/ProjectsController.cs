using Intillegio.Common.Constants;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Intillegio.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Areas.Administration.Controllers
{
    public class ProjectsController : BaseController
    {
        private readonly IProjectsService _projectsService;
        private readonly UserManager<IntillegioUser> _currentUser;

        public ProjectsController(IProjectsService projectsService, UserManager<IntillegioUser> currentUser)
        {
            _projectsService = projectsService;
            _currentUser = currentUser;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AllProjects()
        {
            var allProjects = _projectsService.AllProjects();
            return View(GlobalConstants.AdminAreaPath + "Projects/AllProjects.cshtml", allProjects);
        }
    }
}
using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Intillegio.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ProjectsController : BaseController
    {
        private readonly IProjectsService _projectsService;
        private readonly UserManager<IntillegioUser> _currentUser;

        public ProjectsController(IProjectsService projectsService, UserManager<IntillegioUser> currentUser)
        {
            _projectsService = projectsService;
            _currentUser = currentUser;
        }

        public async Task<IActionResult> AllProjects()
        {
            var projects = await _projectsService.GetAllProjects();
            return View("Projects", projects);
        }

        public async Task<IActionResult> ProjectDetails(int id)
        {
            var projectDetails = await _projectsService.GetProjectDetailsAsync(id);
            if (projectDetails == null)
            {
                return RedirectToAction(ActionConstants.Projects);
            }

            return View("ProjectDetails", projectDetails);
        }
    }
}
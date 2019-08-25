using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.DTOs.BindingModels;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Intillegio.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Intillegio.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class ProjectsAdminController : BaseController
    {
        private readonly IProjectsService _projectsService;
        private readonly UserManager<IntillegioUser> _currentUser;

        public ProjectsAdminController(IProjectsService projectsService, UserManager<IntillegioUser> currentUser)
        {
            _projectsService = projectsService;
            _currentUser = currentUser;
        }

        public async Task<IActionResult> ProjectsAdmin()
        {
            var allProjectsForAdmin = await _projectsService.GetAllProjectsForAdmin();
            return View(GlobalConstants.AdminAreaPath + "ProjectsAdmin/ProjectsAdmin.cshtml", allProjectsForAdmin);
        }

        public async Task<IActionResult> ProjectDetails(int id)
        {
            var projectsDetails = await _projectsService.GetProjectDetailsForAdminAsync(id);

            if (projectsDetails == null)
            {
                return RedirectToAction(ActionConstants.ProjectsAdmin);
            }

            return View("ProjectDetails", projectsDetails);
        }

        public IActionResult AddProject()
        {
            var projectList = new List<SelectListItem>();
            projectList.Add(new SelectListItem
            {
                Text = "Select",
                Value = ""
            });

            foreach (Stage eVal in Enum.GetValues(typeof(Stage)))
            {
                projectList.Add(new SelectListItem { Text = Enum.GetName(typeof(Stage), eVal), Value = eVal.ToString() });
            }

            ViewBag.Stage = projectList;
            //ViewData["ReturnUrl"] = returnUrl;
            return View(GlobalConstants.AdminAreaPath + "ProjectsAdmin/AddProject.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectBindingModel model)
        {
            await _projectsService.AddProject(model);
            return RedirectToAction("AllProjects");
        }
    }
}
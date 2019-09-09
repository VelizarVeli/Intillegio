using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Intillegio.Web.Areas.Administration.Controllers
{
    public class ProjectsAdminController : AdminController
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

        public async Task<IActionResult> DeleteProjectDetails(int id)
        {
            var deleteDetails = await _projectsService.GetProjectDetailsForAdminAsync(id);

            return View("DeleteProject", deleteDetails);
        }

        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectsService.DeleteProjectAsync(id);
            return RedirectToAction("ProjectsAdmin");
        }

        public  async Task<IActionResult> AddProject()
        {
            var categories = await _projectsService.GetAllCategories();
            var deptList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Select",
                    Value = ""
                }
            };
            deptList.AddRange(categories.Select(category => new SelectListItem {Text = category.CategoryName}));

            var partners = await _projectsService.GetAllPartners();
            var partList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Select",
                    Value = ""
                }
            };
            partList.AddRange(partners.Select(partner => new SelectListItem {Text = partner.Name}));

            var stageList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Select",
                    Value = ""
                }
            };
            foreach (Stage eVal in Enum.GetValues(typeof(Stage)))
            {
                stageList.Add(new SelectListItem { Text = Enum.GetName(typeof(Stage), eVal), Value = eVal.ToString() });
            }

            ViewBag.Stage = stageList;
            ViewBag.Partner = partList;
            ViewBag.Category = deptList;

            return View(GlobalConstants.AdminAreaPath + "ProjectsAdmin/AddProject.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(AdminProjectBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _projectsService.AddProjectAsync(model);

            return RedirectToAction("ProjectsAdmin");
        }

        public async Task<IActionResult> EditProject(int id)
        {
            var editDetails = await _projectsService.GetProjectDetailsForAdminEditAsync(id);

            return View("EditProject", editDetails);
        }

        [HttpPost]
        public async Task<IActionResult> ProjectEdit(int id, AdminEditProjectBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("ProjectsAdmin");
            }
            await _projectsService.ProjectEditAsync(model, id);
            return RedirectToAction("ProjectsAdmin");
        }
    }
}
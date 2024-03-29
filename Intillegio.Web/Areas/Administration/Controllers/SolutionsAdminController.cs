﻿using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Areas.Administration.Controllers
{
    public class SolutionsAdminController : AdminController
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

        public async Task<IActionResult> SolutionDetails(int id)
        {
            var solutionDetails = await _solutionsService.GetSolutionDetailsForAdminAsync(id);

            if (solutionDetails == null)
            {
                return RedirectToAction(ActionConstants.SolutionsAdmin);
            }

            return View("SolutionDetails", solutionDetails);
        }

        public IActionResult AddSolution()
        {
            return View(GlobalConstants.AdminAreaPath + "SolutionsAdmin/AddSolution.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> AddSolution(AdminSolutionBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _solutionsService.AddSolutionAsync(model);

            return RedirectToAction("SolutionsAdmin");
        }

        public async Task<IActionResult> DeleteSolutionDetails(int id)
        {
            var deleteDetails = await _solutionsService.GetSolutionDetailsForAdminAsync(id);

            return View("DeleteSolution", deleteDetails);
        }

        public async Task<IActionResult> DeleteSolution(int id)
        {
            await _solutionsService.DeleteSolutionAsync(id);
            return RedirectToAction("SolutionDetails");
        }

        public async Task<IActionResult> EditSolution(int id)
        {
            var editDetails = await _solutionsService.GetSolutionDetailsForAdminAsync(id);

            return View("EditSolution", editDetails);
        }

        [HttpPost]
        public async Task<IActionResult> SolutionEdit(int id, AdminSolutionBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("EditSolution");
            }
            await _solutionsService.SolutionEditAsync(model, id);
            return RedirectToAction("SolutionsAdmin");
        }
    }
}
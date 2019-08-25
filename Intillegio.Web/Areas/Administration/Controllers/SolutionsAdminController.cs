﻿using System.Threading.Tasks;
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

        public async Task<IActionResult> SolutionDetails(int id)
        {
            var solutionDetails = await _solutionsService.GetSolutionDetailsForAdminAsync(id);

            if (solutionDetails == null)
            {
                return RedirectToAction(ActionConstants.SolutionsAdmin);
            }

            return View("SolutionDetails", solutionDetails);
        }

        public IActionResult CheckEdit()
        {
            return View();
        }

        public IActionResult CheckEditorForCreate()
        {
            return View();
        }

        public IActionResult CheckEditorForDelete()
        {
            return View();
        }
    }
}
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
    public class PartnersAdminController : BaseController
    {
        private readonly IPartnersService _partnersService;
        private readonly UserManager<IntillegioUser> _currentUser;

        public PartnersAdminController(IPartnersService partnersService, UserManager<IntillegioUser> currentUser)
        {
            _partnersService = partnersService;
            _currentUser = currentUser;
        }

        public async Task<IActionResult> PartnersAdmin()
        {
            var allPartnersForAdmin = await _partnersService.GetPartnersForAdmin();

            return View(GlobalConstants.AdminAreaPath + "PartnersAdmin/PartnersAdmin.cshtml", allPartnersForAdmin);
        }

        public async Task<IActionResult> PartnerDetails(int id)
        {
            var partnerDetails = await _partnersService.GetPartnerDetailsForAdminAsync(id);

            if (partnerDetails == null)
            {
                return RedirectToAction(ActionConstants.PartnersAdmin);
            }

            return View("PartnerDetails", partnerDetails);
        }
    }
}
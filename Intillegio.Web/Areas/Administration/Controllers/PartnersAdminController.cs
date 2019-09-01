using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.DTOs.BindingModels.Admin;
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

        public IActionResult AddPartner()
        {
            return View(GlobalConstants.AdminAreaPath + "PartnersAdmin/AddPartner.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> AddPartner(AdminPartnerBindingModel model)
        {
            await _partnersService.AddPartnerAsync(model);

            return RedirectToAction("PartnersAdmin");
        }

        public async Task<IActionResult> DeletePartnerDetails(int id)
        {
            var deleteDetails = await _partnersService.GetPartnerDetailsForAdminAsync(id);

            return View("DeletePartner", deleteDetails);
        }

        public async Task<IActionResult> DeletePartner(int id)
        {
            await _partnersService.DeletePartnerAsync(id);
            return RedirectToAction("PartnersAdmin");
        }

        public async Task<IActionResult> EditPartner(int id)
        {
            var editDetails = await _partnersService.GetPartnerDetailsForAdminAsync(id);

            return View("EditPartner", editDetails);
        }

        [HttpPost]
        public async Task<IActionResult> PartnerEdit(int id, AdminPartnerBindingModel model)
        {
            await _partnersService.PartnerEditAsync(model, id);
            return RedirectToAction("PartnersAdmin");
        }

        public async Task<IActionResult> UsersAdmin()
        {
            var allUsersForAdmin = await _partnersService.GetUsersForAdmin();

            return View(GlobalConstants.AdminAreaPath + "PartnersAdmin/UsersAdmin.cshtml", allUsersForAdmin);
        }

        public IActionResult AsignRole(string id)
        {
             _partnersService.AsignRole(id);

            return RedirectToAction("PartnersAdmin");
        }
    }
}
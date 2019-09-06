using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Areas.Administration.Controllers
{
    public class QuickLinksAdminController : AdminController
    {
        private readonly IQuickLinksService _quickLinksService;

        public QuickLinksAdminController(IQuickLinksService quickLinksService)
        {
            _quickLinksService = quickLinksService;
        }

        public async Task<IActionResult> QuickLinksAdmin()
        {
            var allQuickLinksForAdmin = await _quickLinksService.GetAllQuickLinks();

            return View(GlobalConstants.AdminAreaPath + "QuickLinksAdmin/QuickLinksAdmin.cshtml", allQuickLinksForAdmin);
        }

        public async Task<IActionResult> QuickLinkDetails(int id)
        {
            var quickLinkDetails = await _quickLinksService.GetQuickLinkDetailsForAdminAsync(id);

            if (quickLinkDetails == null)
            {
                return RedirectToAction(ActionConstants.QuickLinksAdmin);
            }

            return View("QuickLinkDetails", quickLinkDetails);
        }

        public IActionResult AddQuickLink()
        {
            return View(GlobalConstants.AdminAreaPath + "QuickLinksAdmin/AddQuickLink.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> AddQuickLink(AdminQuickLinkBindingModel model)
        {
            await _quickLinksService.AddQuickLinkAsync(model);

            return RedirectToAction("QuickLinksAdmin");
        }

        public async Task<IActionResult> DeleteQuickLinkDetails(int id)
        {
            var deleteDetails = await _quickLinksService.GetQuickLinkDetailsForAdminAsync(id);

            return View("DeleteQuickLink", deleteDetails);
        }

        public async Task<IActionResult> DeleteQuickLink(int id)
        {
            await _quickLinksService.DeleteQuickLinkAsync(id);
            return RedirectToAction("QuickLinksAdmin");
        }

        public async Task<IActionResult> EditQuickLink(int id)
        {
            var editDetails = await _quickLinksService.GetQuickLinkDetailsForAdminAsync(id);

            return View("EditQuickLink", editDetails);
        }

        [HttpPost]
        public async Task<IActionResult> QuickLinkEdit(int id, AdminQuickLinkBindingModel model)
        {
            await _quickLinksService.QuickLinkEditAsync(model, id);
            return RedirectToAction("QuickLinksAdmin");
        }
    }
}
using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.Common.ViewModels;
using Intillegio.DTOs.BindingModels;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Intillegio.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class SolutionsController : BaseController
    {
        private readonly ISolutionsService _solutionsService;
        private readonly UserManager<IntillegioUser> _currentUser;

        public SolutionsController(ISolutionsService solutionsService, UserManager<IntillegioUser> currentUser)
        {
            _solutionsService = solutionsService;
            _currentUser = currentUser;
        }

        public IActionResult AllSolutions()
        {
            var solutions = _solutionsService.GetAllSolutions();
            return View("Solutions", solutions);
        }

        public async Task<IActionResult> SolutionDetails(int id)
        {
            var allSolutions = _solutionsService.GetAllSolutions();
            var solutionDetails = await _solutionsService.GetSolutionDetailsAsync(id);
            var message = new EmailCallback();
            if (solutionDetails == null)
            {
                return RedirectToAction(ActionConstants.Solutions);
            }

            var services = new ServicesViewModel
            {
                AllSolutions = allSolutions,
                Solution = solutionDetails,
            };

            ViewBag.Message = message;

            return View("SolutionDetails", services);
        }
    }
}

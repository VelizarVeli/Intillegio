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
    }
}

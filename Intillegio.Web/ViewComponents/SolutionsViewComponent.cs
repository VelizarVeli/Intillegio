using System.Threading.Tasks;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.ViewComponents
{
    public class SolutionsViewComponent : ViewComponent
    {
        private readonly ISolutionsService _solutionsService;

        public SolutionsViewComponent(ISolutionsService solutionsService)
        {
            _solutionsService = solutionsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _solutionsService.GetSolutionNamesForDropDownList();

            return View(model);
        }
    }
}

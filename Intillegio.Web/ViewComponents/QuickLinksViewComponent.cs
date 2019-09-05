using System.Threading.Tasks;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.ViewComponents
{
    public class QuickLinksViewComponent : ViewComponent
    {
        private readonly IQuickLinksService _quickLinksService;

        public QuickLinksViewComponent(IQuickLinksService quickLinksService)
        {
            _quickLinksService = quickLinksService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _quickLinksService.GetAllQuickLinks();

            return View(model);
        }
    }
}

using System.Threading.Tasks;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.ViewComponents
{
    public class ArticlesViewComponent : ViewComponent
    {
        private readonly IBlogService _blogService;

        public ArticlesViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _blogService.GetArticles();

            return View(model);
        }
    }
}

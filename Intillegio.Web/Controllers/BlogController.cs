
using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Intillegio.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BlogController : BaseController
    {
        private readonly IBlogService _blogService;
        private readonly UserManager<IntillegioUser> _currentUser;

        public BlogController(IBlogService blogService, UserManager<IntillegioUser> currentUser)
        {
            _blogService = blogService;
            _currentUser = currentUser;
        }
        public async Task<IActionResult> Blog()
        {
            var allArticles = await _blogService.GetAllArticles();
            return View("Blog", allArticles);
        }

        public async Task<IActionResult> ArticleDetails(int id)
        {
            var articleDetails = await _blogService.GetArticleDetailsAsync(id);
            if (articleDetails== null)
            {
                return RedirectToAction(ActionConstants.Blog);
            }

            return View(articleDetails);
        }
    }
}

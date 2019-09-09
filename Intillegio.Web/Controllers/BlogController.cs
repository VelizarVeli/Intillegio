
using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Intillegio.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BlogController : BaseController
    {
        private readonly IBlogService _blogService;
        private readonly UserManager<IntillegioUser> _currentUser;
        private readonly ILogger _logger;

        public BlogController(IBlogService blogService, UserManager<IntillegioUser> currentUser, ILogger<BlogController> logger)
        {
            _blogService = blogService;
            _currentUser = currentUser;
            _logger = logger;
        }

        public async Task<IActionResult> Blog()
        {
            var allArticles = await _blogService.GetAllArticles();
            return View("Blog", allArticles);
        }

        public async Task<IActionResult> ArticleDetails(int id)
        {
            if (id == 0)
            {
                _logger.LogWarning("Id is zero");
            }
            var articleDetails = await _blogService.GetArticleDetailsAsync(id);
            if (articleDetails== null)
            {
                return RedirectToAction(ActionConstants.Blog);
            }

            return View(articleDetails);
        }
    }
}

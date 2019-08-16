
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
        public IActionResult Blog()
        {
            var allArticles = _blogService.GetAllArticles();
            return View("Blog", allArticles);
        }
    }
}

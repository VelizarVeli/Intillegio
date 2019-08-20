using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Intillegio.Web.Models;

namespace Intillegio.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProjectsService _projectsService;
        private readonly IBlogService _recentArticles;

        public HomeController(IProjectsService projectsService, IBlogService recentArticles)
        {
            _projectsService = projectsService;
            _recentArticles = recentArticles;
        }

        public async Task<IActionResult> Index()
        {
            var allProjects = await _projectsService.GetAllProjects();
            var recentArticles = _recentArticles.GetAllArticles().Take(3);
            var homeModel = new HomeViewModel
            {
                Articles = recentArticles,
                Projects = allProjects
            };
            return this.View(homeModel);
        }

        public IActionResult Contact()
        {
            return this.View();
        }

        public IActionResult Faq()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

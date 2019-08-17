using System.Diagnostics;
using System.Linq;
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

        public IActionResult Index()
        {
            var allProjects = _projectsService.GetAllProjects().Take(6);
            var recentArticles = _recentArticles.GetAllArticles().Take(3);
            var homeModel = new HomeViewModel
            {
                Projects = allProjects,
                Articles = recentArticles
            };
            return this.View(homeModel);
        }

        public IActionResult About()
        {
            return this.View();
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

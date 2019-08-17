using System.Diagnostics;
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
            var lastProjects = _projectsService.LastProjects();
            var recentArticles = _recentArticles.GetAllArticles();
            var homeModel = new HomeViewModel
            {
                Projects = lastProjects,
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

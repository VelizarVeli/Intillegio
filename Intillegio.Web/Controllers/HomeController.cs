using System.Diagnostics;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Intillegio.Web.Models;

namespace Intillegio.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProjectsService _projectsService;

        public HomeController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        public IActionResult Index()
        {
            var lastProjects = _projectsService.LastProjects();
            return this.View(lastProjects);
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

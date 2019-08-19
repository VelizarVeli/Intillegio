using System.Threading.Tasks;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public async Task<IActionResult> About()
        {
            var teamMembers = await _aboutService.GetAllTeamMembers();
            return View("About", teamMembers);
        }
    }
}

﻿using System.Linq;
using Intillegio.Common.ViewModels;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IAboutService _aboutService;
        private readonly ISolutionsService _solutionService;

        public AboutController(IAboutService aboutService, ISolutionsService solutionService)
        {
            _aboutService = aboutService;
            _solutionService = solutionService;
        }
        public IActionResult About()
        {
            var teamMembers = _aboutService.GetAllTeamMembers();
            var top4Solutions = _solutionService.GetAllSolutions().Take(4);

            var aboutUs = new AboutUsViewModel
            {
                Solutions = top4Solutions,
                TeamMembers = teamMembers
            };
            return View("About", aboutUs);
        }
    }
}

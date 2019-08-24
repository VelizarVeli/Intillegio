using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Intillegio.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class ArticlesAdminController : BaseController
    {
        private readonly IBlogService _articlesService;
        private readonly UserManager<IntillegioUser> _currentUser;

        public ArticlesAdminController(IBlogService articlesService, UserManager<IntillegioUser> currentUser)
        {
            _articlesService = articlesService;
            _currentUser = currentUser;
        }

        public async Task<IActionResult> ArticlesAdmin()
        {
            var allArticles = await _articlesService.GetAllArticlesForAdmin();

            return View(GlobalConstants.AdminAreaPath + "ArticlesAdmin/ArticlesAdmin.cshtml", allArticles);
        }
    }
}
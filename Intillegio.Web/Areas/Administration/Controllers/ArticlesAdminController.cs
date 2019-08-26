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

        public async Task<IActionResult> ArticleDetails(int id)
        {
            var articleDetails = await _articlesService.GetArticleDetailsForAdminAsync(id);

            if (articleDetails == null)
            {
                return RedirectToAction(ActionConstants.ArticlesAdmin);
            }

            return View("ArticleDetails", articleDetails);
        }

        public async Task<IActionResult> DeleteArticleDetails(int id)
        {
            var deleteDetails = await _articlesService.GetArticleDetailsForAdminAsync(id);

            return View("DeleteArticle", deleteDetails);
        }

        public async Task<IActionResult> DeleteArticle(int id)
        {
            await _articlesService.DeleteArticleAsync(id);
            return RedirectToAction("ArticlesAdmin");
        }
    }
}
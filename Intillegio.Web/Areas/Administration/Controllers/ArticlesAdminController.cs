using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Intillegio.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var categories = await _articlesService.GetAllCategories();
            var categoryCount = categories.Count();
            ViewBag.CategoryCount = categoryCount;
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

        public async Task<IActionResult> AddArticle()
        {
            var categories = await _articlesService.GetAllCategories();
            var deptList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Select",
                    Value = ""
                }
            };
            foreach (var category in categories)
            {
                deptList.Add(new SelectListItem { Text = category.CategoryName });
            }

            ViewBag.Category = deptList;

            return View(GlobalConstants.AdminAreaPath + "ArticlesAdmin/AddArticle.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(AdminArticleBindingModel model)
        {
            await _articlesService.AddArticleAsync(model);

            return RedirectToAction("ArticlesAdmin");
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

        public async Task<IActionResult> EditArticle(int id)
        {
            var editDetails = await _articlesService.GetArticleDetailsForAdminEditAsync(id);

            return View("EditArticle", editDetails);
        }

        [HttpPost]
        public async Task<IActionResult> ArticleEdit(int id, AdminEditArticleBindingModel model)
        {
            await _articlesService.ArticleEditAsync(model, id);
            return RedirectToAction("ArticlesAdmin");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.Data.Data;
using Intillegio.DTOs.BindingModels;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Intillegio.Services
{
    public class BlogService : BaseService, IBlogService
    {
        public BlogService(IntillegioContext dbContext, IMapper mapper, UserManager<IntillegioUser> userManager)
            : base(dbContext, mapper, userManager)
        {
        }

        public async Task<IEnumerable<ArticleViewModel>> GetAllArticles()
        {
            var allArticles = await DbContext.Articles.Select(v => new ArticleViewModel()
            {
                Name = v.Name,
                CategoryName = v.CategoryName.CategoryName,
                Id = v.Id,
                Image65X65 = v.Image65X65,
                Image825X530 = v.Image825X530,
                Image390X245 = v.Image390X245,
                Image350X220 = v.Image350X220,
                Content = v.Content,
                VideoImage400X250 = v.VideoImage400X250,
                Date = v.Date

            }).ToListAsync();

            //var allArticles = Mapper.Map<IEnumerable<ArticleViewModel>>(
            //    DbContext.Articles.OrderByDescending(a => a.Date));
            return allArticles;
        }

        public async Task<IEnumerable<ArticleViewModel>> GetArticles()
        {
            var articles = await DbContext.Articles.OrderByDescending(a => a.Date).ToListAsync();

            var allArticles = Mapper.Map<ICollection<ArticleViewModel>>(articles);

            return allArticles;
        }

        public async Task<ArticleBindingModel> GetArticleDetailsAsync(int id)
        {
            var articleModel = await DbContext.Articles.SingleOrDefaultAsync(e => e.Id == id);
            var article = Mapper.Map<ArticleBindingModel>(articleModel);

            return article;
        }

        public async Task<IEnumerable<AdminArticleViewModel>> GetAllArticlesForAdmin()
        {
            var allArticles = await DbContext.Articles.Select(v => new AdminArticleViewModel()
            {
                Name = v.Name,
                CategoryName = v.CategoryName.CategoryName,
                Id = v.Id,
                Date = v.Date

            }).ToListAsync();
            return allArticles;
        }

        public async Task<AdminArticleBindingModel> GetArticleDetailsForAdminAsync(int id)
        {
            var articleModel = await DbContext
                .Articles
                .Include(a => a.CategoryName)
                .SingleOrDefaultAsync(e => e.Id == id);

            var article = Mapper.Map<AdminArticleBindingModel>(articleModel);
            article.Category = articleModel.CategoryName.CategoryName;

            return article;
        }

        public async Task AddArticleAsync(AdminArticleBindingModel article)
        {
            var model = Mapper.Map<Article>(article);
            model.Date = DateTime.UtcNow;
            model.CategoryId = DbContext.Categories.FirstOrDefault(ca =>
                string.Equals(ca.CategoryName, article.Category, StringComparison.Ordinal)).Id;
            await DbContext.Articles.AddAsync(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteArticleAsync(int id)
        {
            var article = DbContext.Articles.SingleOrDefault(e => e.Id == id);
            if (article != null)
            {
                DbContext.Articles.Remove(article);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var allCategories = await DbContext.Categories.ToListAsync();

            return allCategories;
        }

        public async Task ArticleEditAsync(AdminEditArticleBindingModel article, int id)
        {
            var model = DbContext.Articles.FirstOrDefault(i => i.Id == id);

            Mapper.Map(article, model);
            DbContext.Articles.Update(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task<AdminEditArticleBindingModel> GetArticleDetailsForAdminEditAsync(int id)
        {
            var article = await DbContext
                .Articles
                .Include(a => a.Comments)
                .SingleOrDefaultAsync(i => i.Id == id);

            var eventDto = Mapper
                .Map<AdminEditArticleBindingModel>(article);
            var category = await DbContext.Categories.SingleOrDefaultAsync(c => c.Id == article.CategoryId);
            eventDto.Category = category.CategoryName;
            return eventDto;
        }
    }
}

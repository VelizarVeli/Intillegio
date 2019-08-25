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

        public Task<BlogViewModel> BlogArticles()
        {
            throw new System.NotImplementedException();
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
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Data.Data;
using Intillegio.DTOs.BindingModels;
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

        public IEnumerable<ArticleViewModel> GetAllArticles()
        {
            var allArticles = Mapper.Map<IEnumerable<ArticleViewModel>>(
                DbContext.Articles.OrderByDescending(a => a.Date));
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
    }
}

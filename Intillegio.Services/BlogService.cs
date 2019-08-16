using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Data.Data;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;

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
    }
}

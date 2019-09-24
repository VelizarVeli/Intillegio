using System.Linq;
using AutoMapper;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.Data.Data;
using Intillegio.Services.Contracts;

namespace Intillegio.Services
{
    public class UsersService : BaseService, IUsersService
    {
        public UsersService(IntillegioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public UsersPostsCategoriesViewModel GetAllInfo()
        {
            var users = DbContext.Users.Count();
            var posts = DbContext.Articles.Count();
            var categories = DbContext.Categories.Count();
            var info = new UsersPostsCategoriesViewModel
            {
                NumberOfUsers = users,
                NumberOfPosts = posts,
                NumberOfCategories = categories
            };

            return info;
        }
    }
}

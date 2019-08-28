using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common;
using Intillegio.Common.Exceptions;
using Intillegio.Data.Data;
using Intillegio.Models;
using Microsoft.AspNetCore.Identity;

namespace Intillegio.Services
{
    public abstract class BaseService
    {
        protected BaseService(IntillegioContext dbContext,
            IMapper mapper,
            UserManager<IntillegioUser> userManager)
        {
            DbContext = dbContext;
            Mapper = mapper;
            userManager = UserManager;
        }

        protected IntillegioContext DbContext { get; }

        protected IMapper Mapper { get; }

        protected UserManager<IntillegioUser> UserManager { get;  set; }

        protected async Task<IntillegioUser> GetUserByIdAsync(string id)
        {
            var user = await this.UserManager.FindByIdAsync(id);

            return user;
        }
    }
}

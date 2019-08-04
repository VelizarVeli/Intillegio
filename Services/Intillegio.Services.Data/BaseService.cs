using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Intillegio.Services.Data
{
    public abstract class BaseService
    {
        protected BaseService(
            //ApplicationDbContext dbContext,
            IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            //this.DbContext = dbContext;
            this.Mapper = mapper;
            this.UserManager = userManager;
        }

        //protected ApplicationDbContext DbContext { get; private set; }

        protected IMapper Mapper { get; private set; }

        protected UserManager<ApplicationUser> UserManager { get; private set; }
    }
}

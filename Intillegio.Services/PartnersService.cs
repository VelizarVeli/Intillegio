using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common.Constants;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.Data.Data;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Intillegio.Services
{
    public class PartnersService : BaseService, IPartnersService
    {
        private readonly SignInManager<IntillegioUser> _signInManager;

        public PartnersService(IntillegioContext dbContext, IMapper mapper, SignInManager<IntillegioUser> signInManager)
            : base(dbContext, mapper)
        {
            _signInManager = signInManager;
        }

        public async Task<IEnumerable<PartnerViewModel>> GetPartnersLogos()
        {
           var partners = await DbContext.Partners.ToListAsync();
            var partnersLogos = Mapper.Map<ICollection<PartnerViewModel>>(partners);
            
            return partnersLogos;
        }

        public async Task<AdminJunctionPartnersBindingModel> GetPartnersForAdmin()
        {
            var partners = await DbContext.Partners.ToListAsync();
            var partnersInfo = Mapper.Map<ICollection<AdminPartnerViewModel>>(partners);
            var usersCount = DbContext.Users.Count();
            var partnersJunction = new AdminJunctionPartnersBindingModel
            {
                Partners = partnersInfo,
                UsersCount = usersCount - 1
            };

            return partnersJunction;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersForAdmin()
        {
            var users = await DbContext.Users.ToListAsync();
            var usersInfo = Mapper.Map<ICollection<UserViewModel>>(users);

            return usersInfo;
        }

        public async Task<AdminPartnerBindingModel> GetPartnerDetailsForAdminAsync(int id)
        {
            var partner = await DbContext
                .Partners
                .Include(fps => fps.Projects)
                .SingleOrDefaultAsync(i => i.Id == id);

            var partnerDto = Mapper.Map<AdminPartnerBindingModel>(partner);

            return partnerDto;
        }

        public async Task DeletePartnerAsync(int id)
        {
            var partner = DbContext.Partners.SingleOrDefault(e => e.Id == id);
            if (partner != null)
            {
                DbContext.Partners.Remove(partner);
                await DbContext.SaveChangesAsync();
            }
        }

        public void AsignRole(string id)
        {
            var user =  DbContext.Users.FirstOrDefault(a => a.Id == id);

           var roleResult = _signInManager.UserManager.AddToRoleAsync(user, GlobalConstants.PartnerRoleName).Result;
        }

        public async Task AddPartnerAsync(AdminPartnerBindingModel partner)
        {
            var model = this.Mapper.Map<Partner>(partner);
            await DbContext.Partners.AddAsync(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task PartnerEditAsync(AdminPartnerBindingModel partner, int modelId)
        {
            var model = DbContext.Partners.FirstOrDefault(i => i.Id == modelId);

            Mapper.Map(partner, model);
            DbContext.Partners.Update(model);
            await DbContext.SaveChangesAsync();
        }
    }
}

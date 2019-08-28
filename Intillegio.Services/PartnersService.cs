using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common;
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
        public PartnersService(IntillegioContext dbContext, IMapper mapper, UserManager<IntillegioUser> userManager)
            : base(dbContext, mapper, userManager)
        {
        }

        public async Task<IEnumerable<PartnerViewModel>> GetPartnersLogos()
        {
           var partners = await DbContext.Partners.ToListAsync();
            var partnersLogos = Mapper.Map<ICollection<PartnerViewModel>>(partners);
            
            return partnersLogos;
        }

        public async Task<IEnumerable<AdminPartnerViewModel>> GetPartnersForAdmin()
        {
            var partners = await DbContext.Partners.ToListAsync();
            var partnersInfo = Mapper.Map<ICollection<AdminPartnerViewModel>>(partners);

            return partnersInfo;
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

        public async Task AddPartnerAsync(AdminPartnerBindingModel partner)
        {
            var model = this.Mapper.Map<Partner>(partner);
            await DbContext.Partners.AddAsync(model);
            await DbContext.SaveChangesAsync();
        }
    }
}

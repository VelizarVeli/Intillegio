using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Data.Data;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Intillegio.Services
{
    public class QuickLinksService : BaseService, IQuickLinksService
    {
        public QuickLinksService(IntillegioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<QuickLinksViewModel>> GetAllQuickLinks()
        {
            var quickLinks = await DbContext.QuickLinks.ToListAsync();
            var quickLinksDto = Mapper.Map<ICollection<QuickLinksViewModel>>(quickLinks);

            return quickLinksDto;
        }

        public async Task<AdminQuickLinkBindingModel> GetQuickLinkDetailsForAdminAsync(int id)
        {
            var quickLink = await DbContext
                .QuickLinks
                .SingleOrDefaultAsync(i => i.Id == id);

            var quickLinkDto = Mapper.Map<AdminQuickLinkBindingModel>(quickLink);

            return quickLinkDto;
        }

        public async Task DeleteQuickLinkAsync(int id)
        {
            var quickLink = DbContext.QuickLinks.SingleOrDefault(e => e.Id == id);
            if (quickLink != null)
            {
                DbContext.QuickLinks.Remove(quickLink);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task AddQuickLinkAsync(AdminQuickLinkBindingModel quickLink)
        {
            var model = this.Mapper.Map<QuickLink>(quickLink);
            await DbContext.QuickLinks.AddAsync(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task QuickLinkEditAsync(AdminQuickLinkBindingModel quickLink, int modelId)
        {
            var model = DbContext.QuickLinks.FirstOrDefault(i => i.Id == modelId);

            Mapper.Map(quickLink, model);
            DbContext.QuickLinks.Update(model);
            await DbContext.SaveChangesAsync();
        }
    }
}

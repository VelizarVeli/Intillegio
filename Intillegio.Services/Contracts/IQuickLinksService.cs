using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;
using Intillegio.DTOs.BindingModels.Admin;

namespace Intillegio.Services.Contracts
{
    public interface IQuickLinksService
    {
        Task<IEnumerable<QuickLinksViewModel>> GetAllQuickLinks();
        Task<AdminQuickLinkBindingModel> GetQuickLinkDetailsForAdminAsync(int id);
        Task DeleteQuickLinkAsync(int id);
        Task AddQuickLinkAsync(AdminQuickLinkBindingModel partner);
        Task QuickLinkEditAsync(AdminQuickLinkBindingModel partner, int modelId);
    }
}

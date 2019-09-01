using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.DTOs.BindingModels.Admin;

namespace Intillegio.Services.Contracts
{
    public interface IPartnersService
    {
        Task<IEnumerable<PartnerViewModel>> GetPartnersLogos();
        Task<AdminJunctionPartnersBindingModel> GetPartnersForAdmin();
        Task<IEnumerable<UserViewModel>> GetUsersForAdmin();
        Task<AdminPartnerBindingModel> GetPartnerDetailsForAdminAsync(int id);
        Task DeletePartnerAsync(int id);
        void AsignRole(string id);
        Task AddPartnerAsync(AdminPartnerBindingModel partner);
        Task PartnerEditAsync(AdminPartnerBindingModel partner, int modelId);
    }
}

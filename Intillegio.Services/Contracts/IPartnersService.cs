using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;

namespace Intillegio.Services.Contracts
{
    public interface IPartnersService
    {
        Task<IEnumerable<PartnerViewModel>> GetPartnersLogos();
        Task<IEnumerable<AdminPartnerViewModel>> GetPartnersForAdmin();
    }
}

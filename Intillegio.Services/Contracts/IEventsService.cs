using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.DTOs.BindingModels;
using Intillegio.DTOs.BindingModels.Admin;

namespace Intillegio.Services.Contracts
{
    public interface IEventsService
    {
        IEnumerable<EventViewModel> GetAllEvents();
        Task<EventBindingModel> GetEventDetailsAsync(int id);
        IEnumerable<AdminEventViewModel> GetAllEventsForAdmin();
        Task<AdminEventBindingModel> GetEventDetailsForAdminAsync(int id);
        Task DeleteEventAsync(int id);
    }
}

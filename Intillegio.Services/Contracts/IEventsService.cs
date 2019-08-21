using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;
using Intillegio.DTOs.BindingModels;

namespace Intillegio.Services.Contracts
{
   public interface IEventsService
    {
        IEnumerable<EventViewModel> GetAllEvents();
        Task<EventBindingModel> GetEventDetailsAsync(int id);
    }
}

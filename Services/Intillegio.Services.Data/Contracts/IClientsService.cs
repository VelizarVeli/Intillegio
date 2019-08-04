using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Web.ViewModels;

namespace Intillegio.Services.Data.Contracts
{
    public interface IClientsService
    {
        Task<IEnumerable<AllClientsViewModels>> AllClients();
    }
}

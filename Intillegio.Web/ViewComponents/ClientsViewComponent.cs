using System.Threading.Tasks;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.ViewComponents
{
    public class ClientsViewComponent : ViewComponent
    {
        private readonly IClientsService _clientsService;

        public ClientsViewComponent(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _clientsService.GetClientsLogos();

            return View(model);
        }
    }
}

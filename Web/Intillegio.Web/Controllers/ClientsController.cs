using System.Threading.Tasks;
using Intillegio.Services.Data.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        //public async Task<IActionResult> Clients()
        //{
        //    var allClients = await _clientsService.AllClients();
        //    return RedirectToAction("Index", "Home", allClients);
        //}
    }
}
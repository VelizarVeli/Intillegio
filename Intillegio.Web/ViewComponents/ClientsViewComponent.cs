using System.Threading.Tasks;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.ViewComponents
{
    public class ClientsViewComponent : ViewComponent
    {
        private readonly IPartnersService _partnersService;

        public ClientsViewComponent(IPartnersService partnersService)
        {
            _partnersService = partnersService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _partnersService.GetPartnersLogos();

            return View(model);
        }
    }
}

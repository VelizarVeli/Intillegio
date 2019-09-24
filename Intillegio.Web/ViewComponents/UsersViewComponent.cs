using System.Threading.Tasks;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.ViewComponents
{
    public class UsersViewComponent : ViewComponent
    {
        private readonly IUsersService _usersService;

        public UsersViewComponent(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var model =  _usersService.GetAllInfo();

            return View(model);
        }
    }
}

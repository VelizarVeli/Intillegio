using Intillegio.Common.Constants;
using Intillegio.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Areas.Administration.Controllers
{
    public class DashboardController : BaseController
    {
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [Area("Administration")]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
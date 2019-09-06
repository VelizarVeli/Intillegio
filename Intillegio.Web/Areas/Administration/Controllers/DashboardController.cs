using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Areas.Administration.Controllers
{
    public class DashboardController : AdminController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
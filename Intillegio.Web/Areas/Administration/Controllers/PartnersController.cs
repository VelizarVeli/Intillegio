using Intillegio.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Areas.Administration.Controllers
{
    public class PartnersController : BaseController
    {
        public IActionResult AllPartners()
        {
            return View();
        }
    }
}
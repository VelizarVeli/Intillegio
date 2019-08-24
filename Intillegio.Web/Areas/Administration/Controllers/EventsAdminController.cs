using Intillegio.Common.Constants;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Intillegio.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class EventsAdminController : BaseController
    {
        private readonly IEventsService _eventsService;
        private readonly UserManager<IntillegioUser> _currentUser;

        public EventsAdminController(IEventsService eventsService, UserManager<IntillegioUser> currentUser)
        {
            _eventsService = eventsService;
            _currentUser = currentUser;
        }

        public IActionResult EventsAdmin()
        {
            var allEvents = _eventsService.GetAllEventsForAdmin();

            return View(GlobalConstants.AdminAreaPath + "EventsAdmin/EventsAdmin.cshtml", allEvents);
        }
    }
}
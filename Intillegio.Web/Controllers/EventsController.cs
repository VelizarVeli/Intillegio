using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Controllers
{
    public class EventsController : BaseController
    {
        private readonly IEventsService _eventsService;

        public EventsController(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }

        public IActionResult Events()
        {
            var events = _eventsService.GetAllEvents();
            return View("Events", events);
        }
    }
}
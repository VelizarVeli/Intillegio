using System.Threading.Tasks;
using Intillegio.Common.Constants;
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

        public async Task<IActionResult> EventDetails(int id)
        {
            var eventDetails = await _eventsService.GetEventDetailsAsync(id);
            if (eventDetails == null)
            {
                return RedirectToAction(ActionConstants.Events);
            }

            return View("EventDetails", eventDetails);
        }
    }
}
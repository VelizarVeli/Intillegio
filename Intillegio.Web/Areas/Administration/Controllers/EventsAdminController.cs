using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.DTOs.BindingModels.Admin;
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

        public async Task<IActionResult> EventDetails(int id)
        {
            var eventDetails = await _eventsService.GetEventDetailsForAdminAsync(id);

            if (eventDetails == null)
            {
                return RedirectToAction(ActionConstants.EventsAdmin);
            }

            return View("EventDetails", eventDetails);
        }

        public  IActionResult AddEvent()
        {
            return View(GlobalConstants.AdminAreaPath + "EventsAdmin/AddEvent.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(AdminEventBindingModel model)
        {
            await _eventsService.AddEventAsync(model);

            return RedirectToAction("EventsAdmin");
        }

        public async Task<IActionResult> DeleteEventDetails(int id)
        {
            var deleteDetails = await _eventsService.GetEventDetailsForAdminAsync(id);

            return View("DeleteEvent", deleteDetails);
        }

        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _eventsService.DeleteEventAsync(id);
            return RedirectToAction("EventsAdmin");
        }
    }
}
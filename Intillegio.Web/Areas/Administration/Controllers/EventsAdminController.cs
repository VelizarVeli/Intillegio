using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Areas.Administration.Controllers
{
    public class EventsAdminController : AdminController
    {
        private readonly IEventsService _eventsService;

        public EventsAdminController(IEventsService eventsService)
        {
            _eventsService = eventsService;
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
            if (!ModelState.IsValid)
            {
                return View();
            }
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

        public async Task<IActionResult> EditEvent(int id)
        {
            var editDetails = await _eventsService.GetEventDetailsForAdminEditAsync(id);

            return View("EditEvent", editDetails);
        }

        [HttpPost]
        public async Task<IActionResult> EventEdit(int id, AdminEditEventBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("EditEvent");
            }
            await _eventsService.EventEditAsync(model, id);
            return RedirectToAction("EventsAdmin");
        }
    }
}
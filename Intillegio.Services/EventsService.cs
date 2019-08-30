using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.Data.Data;
using Intillegio.DTOs.BindingModels;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Intillegio.Services
{
    public class EventsService : BaseService, IEventsService
    {
        public EventsService(IntillegioContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public IEnumerable<EventViewModel> GetAllEvents()
        {
            var allEvents = Mapper.Map<IEnumerable<EventViewModel>>(
                DbContext.Events.OrderByDescending(a => a.StartDateTime));
            return allEvents;
        }

        public async Task<EventBindingModel> GetEventDetailsAsync(int id)
        {
            var eventure = await DbContext
                .Events
                .Include(i => i.EventImages)
                .SingleOrDefaultAsync(i => i.Id == id);

            var eventDto = Mapper.Map<EventBindingModel>(eventure);
            eventDto.StartDate = eventure.StartDateTime.Date;
            eventDto.StartTime = eventure.StartDateTime;
            return eventDto;
        }

        public IEnumerable<AdminEventViewModel> GetAllEventsForAdmin()
        {
            var allEvents = Mapper.Map<IEnumerable<AdminEventViewModel>>(
                DbContext.Events.OrderByDescending(a => a.StartDateTime));
            return allEvents;
        }

        public async Task<AdminEventBindingModel> GetEventDetailsForAdminAsync(int id)
        {
            var eventure = await DbContext
                .Events
                .Include(a => a.EventImages)
                .SingleOrDefaultAsync(i => i.Id == id);

            var teamMemberDto = Mapper.Map<AdminEventBindingModel>(eventure);

            return teamMemberDto;
        }

        public async Task DeleteEventAsync(int id)
        {
            var eventure = DbContext.Events.SingleOrDefault(e => e.Id == id);
            if (eventure != null)
            {
                DbContext.Events.Remove(eventure);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task AddEventAsync(AdminEventBindingModel eventure)
        {
            var model = this.Mapper.Map<Event>(eventure);
            await DbContext.Events.AddAsync(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task EventEditAsync(AdminEditEventBindingModel eventure, int id)
        {
            var model = DbContext.Events.FirstOrDefault(i => i.Id == id);

            Mapper.Map(eventure, model);
            DbContext.Events.Update(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task<AdminEditEventBindingModel> GetEventDetailsForAdminEditAsync(int id)
        {
            var eventure = await DbContext
                .Events
                .Include(a => a.EventImages)
                .SingleOrDefaultAsync(i => i.Id == id);

            var eventDto = Mapper
                .Map<AdminEditEventBindingModel>(eventure);
            return eventDto;
        }
    }
}

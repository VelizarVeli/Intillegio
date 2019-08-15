using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Data.Data;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Intillegio.Services
{
    public class ClientsService : BaseService, IClientsService
    {
        public ClientsService(IntillegioContext dbContext, IMapper mapper, UserManager<IntillegioUser> userManager)
            : base(dbContext, mapper, userManager)
        {
        }

        public async Task<IEnumerable<PartnerViewModel>> GetClientsLogos()
        {
           var clients = await DbContext.Partners.ToListAsync();
            var clientsLogos = Mapper.Map<ICollection<PartnerViewModel>>(clients);
            
            return clientsLogos;
        }
    }
}

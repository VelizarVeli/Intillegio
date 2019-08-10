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
    public class ProjectsService : BaseService, IProjectsService
    {
        public ProjectsService(IntillegioContext dbContext, IMapper mapper, UserManager<IntillegioUser> userManager)
            : base(dbContext, mapper, userManager)
        {
        }

        public IEnumerable<LastProjectsViewModel> LastProjects()
        {
            //var lastProjects = await DbContext
            //    .Projects
            //    .OrderByDescending(a => a.StartingDate)
            //    .Select(a => new LastProjectsViewModel
            //    {
            //        Id = a.Id,
            //        CategoryName = a.Category.Name,
            //        Image = a.Image,
            //        Name = a.Name,
            //        Stage = a.Stage.ToString()
            //    })
            //    .Take(6)
            //    .ToListAsync();
            //var projects = await DbContext.Projects.ToListAsync().OrderByDescending(p=>p.StartingDate).Take(6);
            //var lastProjects =  Mapper.Map<ICollection<LastProjectsViewModel>>(
            //    projects);
            var lastProjects = Mapper.Map<IEnumerable<LastProjectsViewModel>>(
                DbContext.Projects.OrderByDescending(a => a.StartingDate).Take(6));
            return lastProjects;
        }
    }
}

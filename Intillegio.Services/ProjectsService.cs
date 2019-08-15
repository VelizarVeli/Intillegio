using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common;
using Intillegio.Common.BindingModels;
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

        public IEnumerable<ProjectViewModel> LastProjects()
        {
            //var lastProjects = await DbContext
            //    .Projects
            //    .OrderByDescending(a => a.StartingDate)
            //    .Select(a => new ProjectViewModel
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
            //var lastProjects =  Mapper.Map<ICollection<ProjectViewModel>>(
            //    projects);
            var lastProjects = Mapper.Map<IEnumerable<ProjectViewModel>>(
                DbContext.Projects.OrderByDescending(a => a.StartingDate).Take(6));
            return lastProjects;
        }

        public IEnumerable<ProjectViewModel> AllProjects()
        {
            var allProjects = Mapper.Map<IEnumerable<ProjectViewModel>>(
                DbContext.Projects.OrderByDescending(a => a.StartingDate));
            return allProjects;
        }

        public async Task AddProject(ProjectBindingModel project)
        {
            CoreValidator.ThrowIfNull(project);

            var model = this.Mapper.Map<Project>(project);
            await DbContext.Projects.AddAsync(model);
            await this.DbContext.SaveChangesAsync();
        }
    }
}

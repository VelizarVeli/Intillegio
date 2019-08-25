using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.Data.Data;
using Intillegio.DTOs.BindingModels;
using Intillegio.DTOs.BindingModels.Admin;
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

        public async Task<IEnumerable<ProjectViewModel>> GetAllProjects()
        {
            var allProjects = await DbContext.Projects.Select(v => new ProjectViewModel
            {
                Name = v.Name,
                CategoryName = v.Category.CategoryName,
                Id = v.Id,
                Image350X350 = v.Image350X350,
                Stage = v.Stage.ToString()
            }).ToListAsync();

            return allProjects;
        }

        public async Task<ProjectBindingModel> GetProjectDetailsAsync(int id)
        {
            var project = await DbContext.Projects
                    .Select(v => new ProjectBindingModel
                    {
                        Category = v.Category.CategoryName,
                        Partner = v.Partner.Name,
                        Image350X350 = v.Image350X350,
                        Image1110X450 = v.Image1110X450,
                        Image360X240 = v.Image360X240,
                        Stage = v.Stage.ToString(),
                        StartingDate = v.StartingDate,
                        Name = v.Name,
                        Id = v.Id,
                        Features = v.Features
                    })
                .Include(a => a.RelatedProjects)
                .Include(b => b.Features)
                .SingleOrDefaultAsync(i => i.Id == id);

            //var projectDto = Mapper.Map<ProjectBindingModel>(project);

            return project;
        }

        public async Task<IEnumerable<AdminProjectViewModel>> GetAllProjectsForAdmin()
        {
            var allProjects = await DbContext.Projects.Select(v => new AdminProjectViewModel
            {
                Name = v.Name,
                CategoryName = v.Category.CategoryName,
                Id = v.Id,
                Stage = v.Stage.ToString()
            }).ToListAsync();

            return allProjects;
        }

        public async Task<AdminProjectBindingModel> GetProjectDetailsForAdminAsync(int id)
        {
            var projectDto = await DbContext
                .Projects
                .Select(p => new AdminProjectBindingModel
                {
                    Category = p.Category.CategoryName,
                    Features = p.Features.Select(f => new ProjectFeature
                    {
                        Name = f.ProjectFeature.Name
                    }).ToList(),
                    Id = p.Id,
                    Image1110X450 = p.Image1110X450,
                    Image350X350 = p.Image350X350,
                    Image360X240 = p.Image360X240,
                    Name = p.Name,
                    Partner = p.Partner.Name,
                    ProjectInfo = p.ProjectInfo,
                    RelatedProjects = p.RelatedProjects,
                    Stage = p.Stage.ToString(),
                    StartingDate = p.StartingDate,
                })
                .Include(a => a.RelatedProjects)
                .SingleOrDefaultAsync(i => i.Id == id);


            //var projectDto = Mapper
            //    .Map<AdminProjectBindingModel>(DbContext
            //        .Projects
            //        .SingleOrDefault(i => i.Id == id));

            return projectDto;
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

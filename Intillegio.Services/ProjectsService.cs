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
    public class ProjectsService : BaseService, IProjectsService
    {
        public ProjectsService(IntillegioContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
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
                        Features = v.Features,
                        ProjectInfo = v.ProjectInfo
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

            return projectDto;
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = DbContext.Projects.SingleOrDefault(e => e.Id == id);
            if (project != null)
            {
                DbContext.Projects.Remove(project);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task AddProjectAsync(AdminProjectBindingModel project)
        {
            var model = this.Mapper.Map<Project>(project);
            model.CategoryId = DbContext.Categories.FirstOrDefault(c => c.CategoryName == project.Category).Id;
            model.PartnerId = DbContext.Partners.FirstOrDefault(p => p.Name == project.Partner).Id;
            await DbContext.Projects.AddAsync(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var allCategories = await DbContext.Categories.ToListAsync();

            return allCategories;
        }

        public async Task<IEnumerable<Partner>> GetAllPartners()
        {
            var allPartners = await DbContext.Partners.ToListAsync();

            return allPartners;
        }

        public async Task ProjectEditAsync(AdminEditProjectBindingModel project, int id)
        {
            var model = DbContext.Projects.FirstOrDefault(i => i.Id == id);

            Mapper.Map(project, model);
            DbContext.Projects.Update(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task<AdminEditProjectBindingModel> GetProjectDetailsForAdminEditAsync(int id)
        {
            var project = await DbContext
                .Projects
                .Include(a => a.RelatedProjects)
                .SingleOrDefaultAsync(i => i.Id == id);

            var projectDto = Mapper
                .Map<AdminEditProjectBindingModel>(project);
            var category = await DbContext.Categories.SingleOrDefaultAsync(c => c.Id == project.CategoryId);
            var partner = await DbContext.Partners.SingleOrDefaultAsync(p => p.Id == project.PartnerId);
            projectDto.Partner = partner.Name;
            projectDto.Category = category.CategoryName;
            return projectDto;
        }
    }
}

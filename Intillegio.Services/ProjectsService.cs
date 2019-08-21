﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common;
using Intillegio.Common.ViewModels;
using Intillegio.Data.Data;
using Intillegio.DTOs.BindingModels;
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

        public async Task AddProject(ProjectBindingModel project)
        {
            CoreValidator.ThrowIfNull(project);

            var model = this.Mapper.Map<Project>(project);
            await DbContext.Projects.AddAsync(model);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task<ProjectBindingModel> GetProjectDetailsAsync(int id)
        {
            var project = await DbContext.Projects.SingleOrDefaultAsync(i => i.Id == id);

            var projectDto = Mapper.Map<ProjectBindingModel>(project);

            return projectDto;
        }
    }
}

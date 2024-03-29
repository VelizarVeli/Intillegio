﻿using System.Collections.Generic;
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
    public class SolutionsService : BaseService, ISolutionsService
    {
        public SolutionsService(IntillegioContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public IEnumerable<SolutionViewModel> GetAllSolutions()
        {
            var allSolutions = Mapper.Map<IEnumerable<SolutionViewModel>>(
                DbContext.Solutions.OrderByDescending(a => a.Id));
            return allSolutions;
        }

        public async Task<IEnumerable<SolutionDropDownViewModel>> GetSolutionNamesForDropDownList()
        {
            var solutions = await DbContext.Solutions.OrderByDescending(a => a.Id).ToListAsync();

            var allSolutions = Mapper.Map<IEnumerable<SolutionDropDownViewModel>>(solutions);
            return allSolutions;
        }

        public async Task<SolutionBindingModel> GetSolutionDetailsAsync(int id)
        {
            var solution = await DbContext
                .Solutions
                .Include(fps => fps.FinancialPlanningStrategies)
                .SingleOrDefaultAsync(i => i.Id == id);

            var solutionDto = Mapper.Map<SolutionBindingModel>(solution);

            return solutionDto;
        }

        public IEnumerable<AdminSolutionViewModel> GetAllSolutionsForAdmin()
        {
            var allSolutions = Mapper.Map<IEnumerable<AdminSolutionViewModel>>(
                DbContext.Solutions.OrderBy(a => a.Id));
            return allSolutions;
        }

        public async Task<AdminSolutionBindingModel> GetSolutionDetailsForAdminAsync(int id)
        {
            var solution = await DbContext
                .Solutions
                .Include(fps => fps.FinancialPlanningStrategies)
                .SingleOrDefaultAsync(i => i.Id == id);

            var solutionDto = Mapper.Map<AdminSolutionBindingModel>(solution);

            return solutionDto;
        }

        public async Task DeleteSolutionAsync(int id)
        {
            var solution = DbContext.Solutions.SingleOrDefault(e => e.Id == id);
            if (solution != null)
            {
                DbContext.Solutions.Remove(solution);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task AddSolutionAsync(AdminSolutionBindingModel solution)
        {
            var model = Mapper.Map<Solution>(solution);
            await DbContext.Solutions.AddAsync(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task SolutionEditAsync(AdminSolutionBindingModel solution, int modelId)
        {
            var model = DbContext.Solutions.FirstOrDefault(i => i.Id == modelId);

            Mapper.Map(solution, model);
            DbContext.Solutions.Update(model);
            await DbContext.SaveChangesAsync();
        }
    }
}

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
    public class SolutionsService : BaseService, ISolutionsService
    {
        public SolutionsService(IntillegioContext dbContext, IMapper mapper, UserManager<IntillegioUser> userManager)
            : base(dbContext, mapper, userManager)
        {
        }

        public IEnumerable<SolutionViewModel> GetAllSolutions()
        {
            var allSolutions = Mapper.Map<IEnumerable<SolutionViewModel>>(
                DbContext.Solutions.OrderByDescending(a => a.Id));
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
            var model = this.Mapper.Map<Solution>(solution);
            await DbContext.Solutions.AddAsync(model);
            await DbContext.SaveChangesAsync();
        }
    }
}

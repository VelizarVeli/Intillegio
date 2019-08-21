using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Data.Data;
using Intillegio.DTOs.BindingModels;
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
    }
}

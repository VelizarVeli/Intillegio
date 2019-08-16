using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Data.Data;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Intillegio.Services
{
    public class SolutionsService : BaseService, ISolutionsService
    {
        public SolutionsService(IntillegioContext dbContext, IMapper mapper, UserManager<IntillegioUser> userManager) 
            : base(dbContext, mapper, userManager)
        {
        }

        public IEnumerable<SolutionViewModel> AllSolutions()
        {
            var allSolutions = Mapper.Map<IEnumerable<SolutionViewModel>>(
                DbContext.Solutions.OrderByDescending(a => a.Id));
            return allSolutions;
        }
    }
}

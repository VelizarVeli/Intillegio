using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;
using Intillegio.DTOs;

namespace Intillegio.Services.Contracts
{
    public interface ISolutionsService
    {
        IEnumerable<SolutionViewModel> GetAllSolutions();
        Task<SolutionBindingModel> GetSolutionDetailsAsync(int id);
    }
}

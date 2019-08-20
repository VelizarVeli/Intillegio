using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;

namespace Intillegio.Services.Contracts
{
    public interface ISolutionsService
    {
        IEnumerable<SolutionViewModel> GetAllSolutions();
        Task<SolutionViewModel> GetSolutionDetailsAsync(int id);
    }
}

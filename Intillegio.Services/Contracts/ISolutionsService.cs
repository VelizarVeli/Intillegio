using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.DTOs.BindingModels;
using Intillegio.DTOs.BindingModels.Admin;

namespace Intillegio.Services.Contracts
{
    public interface ISolutionsService
    {
        IEnumerable<SolutionViewModel> GetAllSolutions();
        Task<SolutionBindingModel> GetSolutionDetailsAsync(int id);
        IEnumerable<AdminSolutionViewModel> GetAllSolutionsForAdmin();
        Task<AdminSolutionBindingModel> GetSolutionDetailsForAdminAsync(int id);
    }
}

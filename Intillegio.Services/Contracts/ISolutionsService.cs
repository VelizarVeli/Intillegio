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
        Task<IEnumerable<SolutionDropDownViewModel>> GetSolutionNamesForDropDownList();
        Task<SolutionBindingModel> GetSolutionDetailsAsync(int id);
        IEnumerable<AdminSolutionViewModel> GetAllSolutionsForAdmin();
        Task<AdminSolutionBindingModel> GetSolutionDetailsForAdminAsync(int id);
        Task DeleteSolutionAsync(int id);
        Task AddSolutionAsync(AdminSolutionBindingModel solution);
        Task SolutionEditAsync(AdminSolutionBindingModel solution, int modelId);
    }
}

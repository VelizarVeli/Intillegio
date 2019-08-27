using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.DTOs.BindingModels;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.Models;

namespace Intillegio.Services.Contracts
{
    public interface IProjectsService
    {
        Task<IEnumerable<ProjectViewModel>> GetAllProjects();
        Task<ProjectBindingModel> GetProjectDetailsAsync(int id);
        Task<IEnumerable<AdminProjectViewModel>> GetAllProjectsForAdmin();
        Task<AdminProjectBindingModel> GetProjectDetailsForAdminAsync(int id);
        Task DeleteProjectAsync(int id);
        Task AddProjectAsync(AdminProjectBindingModel project);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<IEnumerable<Partner>> GetAllPartners();
    }
}

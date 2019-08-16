using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.BindingModels;
using Intillegio.Common.ViewModels;

namespace Intillegio.Services.Contracts
{
   public interface IProjectsService
   {
       IEnumerable<ProjectViewModel> LastProjects();
       IEnumerable<ProjectViewModel> GetAllProjects();
       Task AddProject(ProjectBindingModel project);
   }
}

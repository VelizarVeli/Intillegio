using System.Collections.Generic;
using Intillegio.Common.ViewModels;

namespace Intillegio.Services.Contracts
{
   public interface IProjectsService
   {
       IEnumerable<ProjectViewModel> LastProjects();
       IEnumerable<ProjectViewModel> AllProjects();
    }
}

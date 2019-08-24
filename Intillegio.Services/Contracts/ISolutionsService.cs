﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.DTOs.BindingModels;

namespace Intillegio.Services.Contracts
{
    public interface ISolutionsService
    {
        IEnumerable<SolutionViewModel> GetAllSolutions();
        Task<SolutionBindingModel> GetSolutionDetailsAsync(int id);
        IEnumerable<AdminSolutionViewModel> GetAllSolutionsForAdmin();
    }
}

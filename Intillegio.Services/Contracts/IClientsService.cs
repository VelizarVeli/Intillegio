﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;

namespace Intillegio.Services.Contracts
{
    public interface IClientsService
    {
        Task<IEnumerable<ClientViewModel>> GetClientsLogos();
    }
}

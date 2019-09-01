using System.Collections.Generic;
using Intillegio.Common.ViewModels.Admin;

namespace Intillegio.DTOs.BindingModels.Admin
{
   public class AdminJunctionPartnersBindingModel
    {
        public ICollection<AdminPartnerViewModel> Partners { get; set; }

        public int UsersCount { get; set; }
    }
}

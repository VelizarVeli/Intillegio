using System;

namespace Intillegio.Common.ViewModels.Admin
{
    public class UserViewModel
    {
        public string Username { get; set; }

        public Guid Id { get; set; }

        public string CurrentRole { get; set; }
    }
}

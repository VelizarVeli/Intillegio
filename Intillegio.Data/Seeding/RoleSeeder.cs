using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Intillegio.Data.Seeding
{
    public static class RoleSeeder
    {
        public static void SeedRoles(IServiceProvider provider)
        {
            var roleManager = provider.GetService<RoleManager<IdentityRole>>();
            var adminRoleExists = roleManager.RoleExistsAsync("Admin").Result;
            var userRoleExists = roleManager.RoleExistsAsync("User").Result;
            var clientRoleExists = roleManager.RoleExistsAsync("Client").Result;

            if (!adminRoleExists)
            {
                 roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!userRoleExists)
            {
                 roleManager.CreateAsync(new IdentityRole("User"));
            }

            if (!clientRoleExists)
            {
                 roleManager.CreateAsync(new IdentityRole("Client"));
            }
        }
    }
}

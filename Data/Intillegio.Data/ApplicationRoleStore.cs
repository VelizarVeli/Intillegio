namespace Intillegio.Data
{
    using System.Security.Claims;

    using Intillegio.Data.Models;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class ApplicationRoleStore : RoleStore<
        ApplicationRole,
        IntillegioContext,
        string,
        IdentityUserRole<string>,
        IdentityRoleClaim<string>>
    {
        public ApplicationRoleStore(IntillegioContext context, IdentityErrorDescriber describer = null)
            : base(context, describer)
        {
        }

        protected override IdentityRoleClaim<string> CreateRoleClaim(ApplicationRole role, Claim claim) =>
            new IdentityRoleClaim<string>
            {
                RoleId = role.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value,
            };
    }
}

namespace Identity.Infrastructure.Stores
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using Identity.Domain.Models;
    using Identity.Infrastructure.Persistence;

    public class CustomRoleStore : IRoleStore<ApplicationRole>
    {
        private readonly IdentityDbContext db;

        public CustomRoleStore(IdentityDbContext db) => this.db = db;

        public async Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            this.db.Roles.Add(role);
            await this.db.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            this.db.Roles.Remove(role);
            await this.db.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<ApplicationRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            if (!int.TryParse(roleId, out var id)) return null;
            return await this.db.Roles.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }

        public async Task<ApplicationRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
            => await this.db.Roles.FirstOrDefaultAsync(r => r.Name.ToUpper() == normalizedRoleName, cancellationToken);

        public Task<string> GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken)
            => Task.FromResult(role.Id.ToString());

        public Task<string> GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
            => Task.FromResult(role.Name);

        public Task SetRoleNameAsync(ApplicationRole role, string roleName, CancellationToken cancellationToken)
            => Task.CompletedTask;

        public Task<string> GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
            => Task.FromResult(role.Name.ToUpper());

        public Task SetNormalizedRoleNameAsync(ApplicationRole role, string normalizedName, CancellationToken cancellationToken)
            => Task.CompletedTask;

        public async Task<IdentityResult> UpdateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            this.db.Roles.Update(role);
            await this.db.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public void Dispose() { }
    }
}

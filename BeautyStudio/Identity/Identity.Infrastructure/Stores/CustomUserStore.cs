namespace Identity.Infrastructure.Stores
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using Identity.Domain.Models;
    using Identity.Infrastructure.Persistence;
 
    public class CustomUserStore :
        IUserPasswordStore<ApplicationUser>,
        IUserRoleStore<ApplicationUser>
    {
        private readonly IdentityDbContext db;

        public CustomUserStore(IdentityDbContext db) => this.db = db;

        // IUserStore
        public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            this.db.Users.Add(user);
            await this.db.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            this.db.Users.Remove(user);
            await this.db.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            if (!int.TryParse(userId, out var id)) return null;
            return await this.db.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public async Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
            => await this.db.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.UserName.ToUpper() == normalizedUserName, cancellationToken);

        public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
            => Task.FromResult(user.Id.ToString());

        public Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
            => Task.FromResult(user.UserName);

        public Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        { 
            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
            => Task.FromResult(user.UserName.ToUpper());

        public Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
            => Task.CompletedTask;

        public async Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            this.db.Users.Update(user);
            await this.db.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public void Dispose() { }

        // IUserPasswordStore
        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.UpdatePassword(passwordHash);
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
            => Task.FromResult(user.PasswordHash);

        public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
            => Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));

        // IUserRoleStore
        public async Task AddToRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
        {
            var role = await this.db.Roles.FirstOrDefaultAsync(r => r.Name == roleName, cancellationToken);
            if (role == null) throw new InvalidOperationException($"Role '{roleName}' not found.");

            this.db.UserRoles.Add(new UserRole(user.Id, role.Id));
            await this.db.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveFromRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
        {
            var role = await this.db.Roles.FirstOrDefaultAsync(r => r.Name == roleName, cancellationToken);
            if (role == null) return;

            var userRole = await this.db.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == user.Id && ur.RoleId == role.Id, cancellationToken);

            if (userRole != null)
            {
                this.db.UserRoles.Remove(userRole);
                await this.db.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user, CancellationToken cancellationToken)
            => await this.db.UserRoles
                .Where(ur => ur.UserId == user.Id)
                .Select(ur => ur.Role.Name)
                .ToListAsync(cancellationToken);

        public async Task<bool> IsInRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
            => await this.db.UserRoles
                .AnyAsync(ur => ur.UserId == user.Id && ur.Role.Name == roleName, cancellationToken);

        public async Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
            => await this.db.UserRoles
                .Where(ur => ur.Role.Name == roleName)
                .Select(ur => ur.User)
                .ToListAsync(cancellationToken);
    }
}

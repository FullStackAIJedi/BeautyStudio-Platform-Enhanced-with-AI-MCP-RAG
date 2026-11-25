namespace Identity.Infrastructure.Persistence.Repositories
{
    using Identity.Application.Queries.GetUsersList;
    using Identity.Application.Users;
    using Identity.Domain.Models;
    using Microsoft.EntityFrameworkCore;

    internal class UserRepository : IUserRepository
    {
        private readonly IdentityDbContext db;

        public UserRepository(IdentityDbContext db) => this.db = db;

        public async Task<ApplicationUser> Find(int id, CancellationToken cancellationToken = default)
            => await this.db.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        public async Task<ApplicationUser> FindByEmail(string email, CancellationToken cancellationToken = default)
            => await this.db.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

        public async Task<bool> Exists(string email, CancellationToken cancellationToken = default)
            => await this.db.Users.AnyAsync(u => u.Email == email, cancellationToken);

        public async Task Save(ApplicationUser user, CancellationToken cancellationToken = default)
        {
            this.db.Users.Update(user);
            await this.db.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<UserListItemOutputModel>> GetListings(
        string? search,
        int? roleLevel,
        int skip,
        int take,
        CancellationToken cancellationToken = default)
        {
            var query = this.db.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim().ToLower();
                query = query.Where(u =>
                    u.Email.ToLower().Contains(term) ||
                    u.UserName.ToLower().Contains(term) ||
                    u.FirstName.ToLower().Contains(term) ||
                    u.LastName.ToLower().Contains(term));
            }

            if (roleLevel.HasValue)
            {
                query = query.Where(u =>
                    u.UserRoles.Any(ur => ur.Role.RoleLevel == roleLevel.Value));
            }

            return await query
                .OrderBy(u => u.Id)
                .Skip(skip)
                .Take(take)
                .Select(u => new UserListItemOutputModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    RoleName = u.UserRoles
                        .Select(ur => ur.Role.Name)
                        .FirstOrDefault(),
                    RoleLevel = u.UserRoles
                        .Select(ur => ur.Role.RoleLevel)
                        .FirstOrDefault(),
                    IsActive = u.IsActive,
                    IsBlocked = u.IsBlocked,
                    CreatedAt = u.CreatedAt
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<int> Total(
            string? search,
            int? roleLevel,
            CancellationToken cancellationToken = default)
        {
            var query = this.db.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim().ToLower();
                query = query.Where(u =>
                    u.Email.ToLower().Contains(term) ||
                    u.UserName.ToLower().Contains(term) ||
                    u.FirstName.ToLower().Contains(term) ||
                    u.LastName.ToLower().Contains(term));
            }

            if (roleLevel.HasValue)
            {
                query = query.Where(u =>
                    u.UserRoles.Any(ur => ur.Role.RoleLevel == roleLevel.Value));
            }

            return await query.CountAsync(cancellationToken);
        }
    }
}

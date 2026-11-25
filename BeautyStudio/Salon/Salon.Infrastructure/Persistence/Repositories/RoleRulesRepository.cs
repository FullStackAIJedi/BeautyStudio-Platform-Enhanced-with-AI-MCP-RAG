namespace Salon.Infrastructure.Persistence.Repositories
{ 
    using Microsoft.EntityFrameworkCore;

    using Salon.Application.Admin;
    using Salon.Domain.Models.Roles;
    using Salon.Infrastructure.Persistence;

    internal class RoleRulesRepository : IRoleRulesRepository
    {
        private readonly SalonDbContext db;

        public RoleRulesRepository(SalonDbContext db) => this.db = db;

        public async Task<(List<int> PermissionCodes, List<int> ResponsibilityCodes)> GetRules(
            int roleId,
            CancellationToken cancellationToken = default)
        {
            var rules = await this.db.RoleRules
                .Where(r => r.RoleId == roleId)
                .ToListAsync(cancellationToken);

            var permissions = rules
                .Where(r => r.Type == 1)
                .Select(r => r.Code)
                .ToList();

            var responsibilities = rules
                .Where(r => r.Type == 2)
                .Select(r => r.Code)
                .ToList();

            return (permissions, responsibilities);
        }

        public async Task ReplaceRules(
            int roleId,
            List<int> permissionCodes,
            List<int> responsibilityCodes,
            CancellationToken cancellationToken = default)
        {
            var existing = await this.db.RoleRules
                .Where(r => r.RoleId == roleId)
                .ToListAsync(cancellationToken);

            this.db.RoleRules.RemoveRange(existing);

            var newRules = permissionCodes
                .Select(code => new RoleRule(roleId, 1, code))
                .Concat(responsibilityCodes.Select(code => new RoleRule(roleId, 2, code)))
                .ToList();

            await this.db.RoleRules.AddRangeAsync(newRules, cancellationToken);
            await this.db.SaveChangesAsync(cancellationToken);
        }

        public async Task AddRule(
            int roleId,
            int type,
            int code,
            CancellationToken cancellationToken = default)
        {
            var exists = await this.db.RoleRules
                .AnyAsync(r => r.RoleId == roleId && r.Type == type && r.Code == code,
                    cancellationToken);

            if (exists) return;

            await this.db.RoleRules.AddAsync(new RoleRule(roleId, type, code), cancellationToken);
            await this.db.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveRule(
            int roleId,
            int type,
            int code,
            CancellationToken cancellationToken = default)
        {
            var rule = await this.db.RoleRules
                .FirstOrDefaultAsync(r => r.RoleId == roleId && r.Type == type && r.Code == code,
                    cancellationToken);

            if (rule == null) return;

            this.db.RoleRules.Remove(rule);
            await this.db.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> HasRule(
            int roleId,
            int type,
            int code,
            CancellationToken cancellationToken = default)
            => await this.db.RoleRules
                .AnyAsync(r => r.RoleId == roleId && r.Type == type && r.Code == code,
                    cancellationToken);
    }
}

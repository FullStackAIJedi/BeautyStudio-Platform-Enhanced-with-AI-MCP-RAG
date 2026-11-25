namespace Salon.Application.Admin
{
    public interface IRoleRulesRepository
    {
        Task<(List<int> PermissionCodes, List<int> ResponsibilityCodes)> GetRules(
            int roleId,
            CancellationToken cancellationToken = default);

        Task ReplaceRules(
            int roleId,
            List<int> permissionCodes,
            List<int> responsibilityCodes,
            CancellationToken cancellationToken = default);

        Task AddRule(
            int roleId,
            int type,
            int code,
            CancellationToken cancellationToken = default);

        Task RemoveRule(
            int roleId,
            int type,
            int code,
            CancellationToken cancellationToken = default);

        Task<bool> HasRule(
            int roleId,
            int type,
            int code,
            CancellationToken cancellationToken = default);
    }
}

namespace Salon.Application.Admin.Queries.RoleRules
{
    public class GetRoleRulesOutputModel
    {
        public GetRoleRulesOutputModel(
            int roleId,
            List<int> permissionCodes,
            List<int> responsibilityCodes)
        {
            this.RoleId = roleId;
            this.PermissionCodes = permissionCodes;
            this.ResponsibilityCodes = responsibilityCodes;
        }

        public int RoleId { get; }
        public List<int> PermissionCodes { get; }
        public List<int> ResponsibilityCodes { get; }
    }
}

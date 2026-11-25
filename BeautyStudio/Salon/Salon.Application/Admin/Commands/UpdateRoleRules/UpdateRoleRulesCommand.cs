namespace Salon.Application.Admin.Commands.UpdateRoleRules
{
    using MediatR; 
    using SharedKernel.Results;

    public class UpdateRoleRulesCommand : IRequest<Result>
    {
        public int RoleId { get; set; }
        public List<int> PermissionCodes { get; set; } = new();
        public List<int> ResponsibilityCodes { get; set; } = new();
    }
}

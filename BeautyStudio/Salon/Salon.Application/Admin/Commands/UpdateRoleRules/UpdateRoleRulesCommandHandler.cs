namespace Salon.Application.Admin.Commands.UpdateRoleRules
{ 
    using MediatR;

    using Salon.Application.Admin; 
    using Salon.Domain.Specifications.Roles;

    using SharedKernel.Results; 
    using SharedKernel.Security;

    public class UpdateRoleRulesCommandHandler : IRequestHandler<UpdateRoleRulesCommand, Result>
    {
        private readonly IRoleRulesRepository roleRulesRepository;
        private readonly ICurrentUser currentUser;

        public UpdateRoleRulesCommandHandler(
            IRoleRulesRepository roleRulesRepository,
            ICurrentUser currentUser)
        {
            this.roleRulesRepository = roleRulesRepository;
            this.currentUser = currentUser;
        }

        public async Task<Result> Handle(
            UpdateRoleRulesCommand request,
            CancellationToken cancellationToken)
        {
            if (!RoleManagementScope.CanManage(this.currentUser.RoleLevel, request.RoleId))
                return "You don't have permission to manage rules for this role.";

            await this.roleRulesRepository.ReplaceRules(
                request.RoleId,
                request.PermissionCodes,
                request.ResponsibilityCodes,
                cancellationToken);

            return Result.Success;
        }
    }
}

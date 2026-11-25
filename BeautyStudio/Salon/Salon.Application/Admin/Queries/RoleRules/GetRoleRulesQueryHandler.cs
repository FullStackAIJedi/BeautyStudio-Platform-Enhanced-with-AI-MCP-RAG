namespace Salon.Application.Admin.Queries.RoleRules
{
    using MediatR; 

    public class GetRoleRulesQueryHandler : IRequestHandler<GetRoleRulesQuery, GetRoleRulesOutputModel>
    {
        private readonly IRoleRulesRepository roleRulesRepository;

        public GetRoleRulesQueryHandler(IRoleRulesRepository roleRulesRepository)
            => this.roleRulesRepository = roleRulesRepository;

        public async Task<GetRoleRulesOutputModel> Handle(
            GetRoleRulesQuery request,
            CancellationToken cancellationToken)
        {
            var rules = await this.roleRulesRepository.GetRules(request.RoleId, cancellationToken);

            return new GetRoleRulesOutputModel(
                request.RoleId,
                rules.PermissionCodes,
                rules.ResponsibilityCodes);
        }
    }
}

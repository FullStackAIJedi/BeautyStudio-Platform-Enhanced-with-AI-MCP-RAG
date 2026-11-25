namespace Salon.Application.Admin.Queries.RoleRules
{
    using MediatR;

    public class GetRoleRulesQuery : IRequest<GetRoleRulesOutputModel>
    {
        public int RoleId { get; set; }
    }
}

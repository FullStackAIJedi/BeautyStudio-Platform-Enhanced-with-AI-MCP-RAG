namespace Identity.Application.Commands.AssignRole
{
    using Identity.Application.Common;
    using MediatR;

    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand, Result>
    {
        private readonly IIdentity identity;

        public AssignRoleCommandHandler(IIdentity identity) => this.identity = identity;

        public async Task<Result> Handle(
            AssignRoleCommand request,
            CancellationToken cancellationToken)
            => await this.identity.AssignRole(request.UserId, request.RoleId);
    }
}

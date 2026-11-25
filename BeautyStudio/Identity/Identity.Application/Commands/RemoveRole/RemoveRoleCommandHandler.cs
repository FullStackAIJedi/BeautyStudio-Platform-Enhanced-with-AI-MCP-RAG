namespace Identity.Application.Commands.RemoveRole
{
    using Identity.Application.Common;
    using MediatR;

    public class RemoveRoleCommandHandler : IRequestHandler<RemoveRoleCommand, Result>
    {
        private readonly IIdentity identity;

        public RemoveRoleCommandHandler(IIdentity identity) => this.identity = identity;

        public async Task<Result> Handle(
            RemoveRoleCommand request,
            CancellationToken cancellationToken)
            => await this.identity.RemoveRole(request.UserId, request.RoleId);
    }
}

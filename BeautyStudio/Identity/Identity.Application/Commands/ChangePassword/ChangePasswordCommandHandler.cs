namespace Identity.Application.Commands.ChangePassword
{
    using Identity.Application.Common;
    using MediatR;

    using SharedKernel.Security;

    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Result>
    {
        private readonly ICurrentUser currentUser;
        private readonly IIdentity identity;

        public ChangePasswordCommandHandler(ICurrentUser currentUser, IIdentity identity)
        {
            this.currentUser = currentUser;
            this.identity = identity;
        }

        public async Task<Result> Handle(
            ChangePasswordCommand request,
            CancellationToken cancellationToken)
            => await this.identity.ChangePassword(new ChangePasswordInputModel(
                this.currentUser.UserId,
                request.CurrentPassword,
                request.NewPassword));
    }
}

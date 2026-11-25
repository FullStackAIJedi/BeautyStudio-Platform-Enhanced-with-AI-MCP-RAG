namespace Identity.Application.Commands.LoginUser
{
    using Identity.Application.Common;
    using MediatR;

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginSuccessModel>>
    {
        private readonly IIdentity identity;

        public LoginUserCommandHandler(IIdentity identity) => this.identity = identity;

        public async Task<Result<LoginSuccessModel>> Handle(
            LoginUserCommand request,
            CancellationToken cancellationToken)
        {
            var result = await this.identity.Login(request);

            if (!result.Succeeded)
                return Result<LoginSuccessModel>.Failure(result.Errors);

            return result.Data;
        }
    }
}

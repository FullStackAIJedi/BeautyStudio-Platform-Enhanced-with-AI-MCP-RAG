namespace Identity.Application.Commands.RegisterClient
{
    using Identity.Application.Common;
    using MediatR;

    public class RegisterClientCommandHandler : IRequestHandler<RegisterClientCommand, Result<RegisterClientOutputModel>>
    {
        private readonly IIdentity identity;

        public RegisterClientCommandHandler(IIdentity identity) => this.identity = identity;

        public async Task<Result<RegisterClientOutputModel>> Handle(
            RegisterClientCommand request,
            CancellationToken cancellationToken)
        {
            var result = await this.identity.RegisterClient(request);

            if (!result.Succeeded)
                return Result<RegisterClientOutputModel>.Failure(result.Errors);

            return new RegisterClientOutputModel(result.Data.UserId);
        }
    }
}

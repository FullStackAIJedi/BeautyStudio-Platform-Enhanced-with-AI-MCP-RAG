namespace Identity.Application.Commands.RegisterEmployee
{ 
    using Identity.Application.Common;
    using MediatR;

    public class RegisterEmployeeCommandHandler : IRequestHandler<RegisterEmployeeCommand, Result<RegisterEmployeeOutputModel>>
    {
        private readonly IIdentity identity;

        public RegisterEmployeeCommandHandler(IIdentity identity) => this.identity = identity;

        public async Task<Result<RegisterEmployeeOutputModel>> Handle(
            RegisterEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var result = await this.identity.RegisterEmployee(request, request.RoleId);

            if (!result.Succeeded)
                return Result<RegisterEmployeeOutputModel>.Failure(result.Errors);

            return new RegisterEmployeeOutputModel(result.Data.UserId);
        }
    }
}

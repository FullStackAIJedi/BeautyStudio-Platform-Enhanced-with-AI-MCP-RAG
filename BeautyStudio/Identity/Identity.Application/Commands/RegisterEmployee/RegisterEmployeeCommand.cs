namespace Identity.Application.Commands.RegisterEmployee
{ 
    using Identity.Application.Common;
    using MediatR;

    public class RegisterEmployeeCommand : UserInputModel, IRequest<Result<RegisterEmployeeOutputModel>>
    {
        public int RoleId { get; set; }
    }
}

namespace Identity.Application.Commands.LoginUser
{ 
    using Identity.Application.Common;
    using MediatR;

    public class LoginUserCommand : UserInputModel, IRequest<Result<LoginSuccessModel>>
    {
    }
}

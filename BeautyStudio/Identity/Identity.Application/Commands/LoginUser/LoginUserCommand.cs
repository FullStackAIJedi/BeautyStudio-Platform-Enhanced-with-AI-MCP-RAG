namespace Identity.Application.Commands.LoginUser
{ 
    using Identity.Application.Common;
    using MediatR;

    public class LoginUserCommand : LoginUserModel, IRequest<Result<LoginSuccessModel>>
    { }
}

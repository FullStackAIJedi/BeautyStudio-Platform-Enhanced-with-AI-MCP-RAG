namespace Identity.Application.Commands.RegisterClient
{
    using MediatR;
    using Identity.Application.Common;

    public class RegisterClientCommand : UserInputModel, IRequest<Result<RegisterClientOutputModel>>
    {
    }
}

namespace Identity.Application.Commands.ChangePassword
{ 
    using Identity.Application.Common;
    using MediatR;

    public class ChangePasswordCommand : IRequest<Result>
    {
        public string CurrentPassword { get; set; } = default!;
        public string NewPassword { get; set; } = default!;
    }
}

namespace Identity.Application.Commands.LoginUser
{ 
    using FluentValidation;

    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            this.RuleFor(u => u.Email).EmailAddress().NotEmpty();
            this.RuleFor(u => u.Password).NotEmpty();
        }
    }
}

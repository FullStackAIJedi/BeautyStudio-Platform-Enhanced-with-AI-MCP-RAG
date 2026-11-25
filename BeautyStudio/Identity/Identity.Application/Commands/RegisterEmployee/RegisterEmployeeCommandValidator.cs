namespace Identity.Application.Commands.RegisterEmployee
{  
    using FluentValidation; 
    using Identity.Domain.Models;

    public class RegisterEmployeeCommandValidator : AbstractValidator<RegisterEmployeeCommand>
    {
        public RegisterEmployeeCommandValidator()
        {
            this.RuleFor(u => u.Email)
                .EmailAddress()
                .NotEmpty();

            this.RuleFor(u => u.Password)
                .MinimumLength(ModelConstants.User.MinPasswordLength)
                .NotEmpty();

            this.RuleFor(u => u.UserName).NotEmpty();
            this.RuleFor(u => u.FirstName).NotEmpty();
            this.RuleFor(u => u.LastName).NotEmpty();
            this.RuleFor(u => u.RoleId).InclusiveBetween(1, 10);
        }
    }
}

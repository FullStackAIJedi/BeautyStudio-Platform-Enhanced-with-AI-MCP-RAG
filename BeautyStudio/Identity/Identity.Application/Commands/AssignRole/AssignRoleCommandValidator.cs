namespace Identity.Application.Commands.AssignRole
{
    using FluentValidation;

    public class AssignRoleCommandValidator : AbstractValidator<AssignRoleCommand>
    {
        public AssignRoleCommandValidator()
        {
            this.RuleFor(a => a.UserId).GreaterThan(0);
            this.RuleFor(a => a.RoleId).InclusiveBetween(1, 10);
        }
    }
}

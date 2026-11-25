namespace Salon.Application.Admin.Commands.UpdateRoleRules
{
    using FluentValidation;

    public class UpdateRoleRulesCommandValidator : AbstractValidator<UpdateRoleRulesCommand>
    {
        public UpdateRoleRulesCommandValidator()
        {
            this.RuleFor(u => u.RoleId).InclusiveBetween(1, 10);
        }
    }
}

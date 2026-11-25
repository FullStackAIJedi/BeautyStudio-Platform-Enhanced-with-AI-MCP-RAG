namespace Salon.Application.Admin.Commands.AdjustEmployeePoints
{
    using FluentValidation;

    public class AdjustEmployeePointsCommandValidator : AbstractValidator<AdjustEmployeePointsCommand>
    {
        public AdjustEmployeePointsCommandValidator()
        {
            this.RuleFor(a => a.EmployeeId).GreaterThan(0);
            this.RuleFor(a => a.PointsDelta).NotEqual(0);
            this.RuleFor(a => a.Reason).InclusiveBetween(1, 6);
        }
    }
}

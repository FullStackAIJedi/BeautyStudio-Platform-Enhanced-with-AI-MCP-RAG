namespace Salon.Application.Admin.Commands.AdjustEmployeePoints
{
    using MediatR; 

    using Salon.Application.Employees;
    using SharedKernel.Results;
    using SharedKernel.Security;

    public class AdjustEmployeePointsCommandHandler : IRequestHandler<AdjustEmployeePointsCommand, Result>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICurrentUser currentUser;

        public AdjustEmployeePointsCommandHandler(
            IEmployeeRepository employeeRepository,
            ICurrentUser currentUser)
        {
            this.employeeRepository = employeeRepository;
            this.currentUser = currentUser;
        }

        public async Task<Result> Handle(
            AdjustEmployeePointsCommand request,
            CancellationToken cancellationToken)
        {
            var employee = await this.employeeRepository.Find(request.EmployeeId, cancellationToken);
            if (employee == null) return "Employee not found.";

            // Prevent an employee from penalizing themselves
            if (employee.UserId == this.currentUser.UserId && request.PointsDelta < 0)
                return "You cannot penalize yourself.";

            employee.AdjustPoints(request.PointsDelta, request.Reason, request.Description, this.currentUser.UserId);

            await this.employeeRepository.Save(employee, cancellationToken);
            return Result.Success;
        }
    }
}

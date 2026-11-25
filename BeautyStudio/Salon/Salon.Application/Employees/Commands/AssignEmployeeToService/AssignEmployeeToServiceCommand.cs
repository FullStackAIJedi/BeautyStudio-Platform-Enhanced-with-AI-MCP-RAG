namespace Salon.Application.Employees.Commands.AssignEmployeeToService
{
    using MediatR;
    using SharedKernel.Results;

    public class AssignEmployeeToServiceCommand : IRequest<Result>
    {
        public int ServiceId { get; set; }
        public int EmployeeId { get; set; }
    }
}

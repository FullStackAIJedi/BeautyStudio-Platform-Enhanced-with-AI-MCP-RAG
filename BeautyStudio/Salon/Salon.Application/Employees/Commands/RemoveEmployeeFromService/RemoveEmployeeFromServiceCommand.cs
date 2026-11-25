namespace Salon.Application.Employees.Commands.RemoveEmployeeFromService
{
    using MediatR;
    using SharedKernel.Results;

    public record RemoveEmployeeFromServiceCommand(int ServiceId, int EmployeeId) : IRequest<Result>;
}

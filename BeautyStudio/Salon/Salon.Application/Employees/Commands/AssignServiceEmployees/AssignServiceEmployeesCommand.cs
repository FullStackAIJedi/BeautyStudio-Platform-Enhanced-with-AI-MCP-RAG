namespace Salon.Application.Employees.Commands.AssignEmployeesToService
{
    using System.Collections.Generic;

    using MediatR; 
    using SharedKernel.Results;

    public class AssignServiceEmployeesCommand : IRequest<Result>
    {
        public int ServiceId { get; set; }
        public List<int> EmployeeIds { get; set; } = new();
    }
}

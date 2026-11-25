namespace Salon.Application.Employees.Queries.GetServiceEmployees
{
    using System.Collections.Generic;

    using MediatR;
    using Salon.Application.Employees.Queries.Common;

    public record GetServiceEmployeesQuery(int ServiceId) : IRequest<IEnumerable<EmployeeOutputModel>>;
}

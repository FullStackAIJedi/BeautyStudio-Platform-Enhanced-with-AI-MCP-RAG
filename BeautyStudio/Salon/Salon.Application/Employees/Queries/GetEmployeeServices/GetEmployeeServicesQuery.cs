namespace Salon.Application.Employees.Queries.GetEmployeeServices
{
    using System.Collections.Generic;

    using MediatR;
    using Salon.Application.Services.Queries.Common;
  
    public record GetEmployeeServicesQuery(int EmployeeId) : IRequest<IEnumerable<ServiceOutputModel>>;
}

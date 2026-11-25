namespace Salon.Application.Employees.Queries.Details
{
    using MediatR;
    using Salon.Application.Common;

    public class EmployeeDetailsQuery : EntityCommand<int>, IRequest<EmployeeDetailsOutputModel>
    {
    }
}

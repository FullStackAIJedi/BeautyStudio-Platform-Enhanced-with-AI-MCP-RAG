namespace Salon.Application.Employees.Queries.GetServiceEmployees
{
    using MediatR;

    using Salon.Application.Employees.Queries.Common;
    using Salon.Application.Services;

    public class GetServiceEmployeesQueryHandler : IRequestHandler<GetServiceEmployeesQuery, IEnumerable<EmployeeOutputModel>>
    {
        private readonly IServiceRepository serviceRepository;
        public GetServiceEmployeesQueryHandler(IServiceRepository serviceRepository) => this.serviceRepository = serviceRepository;

        public async Task<IEnumerable<EmployeeOutputModel>> Handle(GetServiceEmployeesQuery request, CancellationToken cancellationToken)
            => await this.serviceRepository.GetServiceEmployees(request.ServiceId, cancellationToken);
    }
}

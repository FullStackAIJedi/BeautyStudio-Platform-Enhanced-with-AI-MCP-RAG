namespace Salon.Application.Services
{
    using Salon.Application.Employees.Queries.Common;
    using Salon.Application.Services.Queries.Details; 
    using Salon.Domain.Models.Services;

    using SharedKernel.Models;

    public interface IServiceRepository
    {
        Task<Service> Find(int id, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
        Task Save(Service service, CancellationToken cancellationToken = default);
        Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<Service> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);
        Task<ServiceDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);
        Task<int> Total(Specification<Service> specification, CancellationToken cancellationToken = default);


        Task<IEnumerable<EmployeeOutputModel>> GetServiceEmployees(int serviceId, CancellationToken cancellationToken);
        Task AssignEmployeesToService(int serviceId, List<int> employeeIds, CancellationToken cancellationToken);
    }
}


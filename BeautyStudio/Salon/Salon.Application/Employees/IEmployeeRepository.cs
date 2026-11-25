namespace Salon.Application.Employees
{
    using Salon.Application.Employees.Commands.AddCertifications;
    using Salon.Application.Employees.Commands.AddSkills;
    using Salon.Application.Employees.Queries.Details;
    using Salon.Application.Services.Queries.Common;
    using Salon.Domain.Models.Employees;

    using SharedKernel.Models;

    public interface IEmployeeRepository
    {
        Task<Employee> Find(int id, CancellationToken cancellationToken = default);
        Task<Employee> FindByUserId(int userId, CancellationToken cancellationToken = default);
        Task Save(Employee employee, CancellationToken cancellationToken = default);
        Task<IEnumerable<TOutputModel>> GetListings<TOutputModel>(
            Specification<Employee> specification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);
        Task<EmployeeDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);
        Task<int> Total(Specification<Employee> specification, CancellationToken cancellationToken = default);



        Task<IEnumerable<ServiceOutputModel>> GetEmployeeServices(int employeeId, CancellationToken cancellationToken);
        Task AssignEmployeeToService(int employeeId, int serviceId, CancellationToken cancellationToken);
        Task RemoveEmployeeFromService(int employeeId, int serviceId, CancellationToken cancellationToken);
        Task AddSkills(int employeeId, List<SkillDto> skills, CancellationToken cancellationToken);
        Task DeleteSkills(int employeeId, List<int> skillIds, CancellationToken cancellationToken);
        Task AddCertifications(int employeeId, List<CertDto> certs, CancellationToken cancellationToken);
        Task DeleteCertifications(int employeeId, List<int> certIds, CancellationToken cancellationToken);
    }
}

namespace Salon.Application.Employees.Queries.Common
{
    using AutoMapper;
    using Salon.Application.Common.Mapping;
    using Salon.Domain.Models.Employees;

    public class EmployeeOutputModel : IMapFrom<Employee>
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public string JobTitle { get; private set; } = default!;
        public int RoleId { get; private set; }
        public int ExperienceYears { get; private set; }

        public virtual void Mapping(Profile mapper)
            => mapper.CreateMap<Employee, EmployeeOutputModel>();
    }
}

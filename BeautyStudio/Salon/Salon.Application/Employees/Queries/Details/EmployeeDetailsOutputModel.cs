namespace Salon.Application.Employees.Queries.Details
{
    using AutoMapper;
    using Salon.Application.Employees.Queries.Common;
    using Salon.Domain.Models.Employees;

    public class EmployeeDetailsOutputModel : EmployeeOutputModel
    {
        public string? Bio { get; private set; }
        public string? ProfilePhotoUrl { get; private set; }
        public int TotalPortfolioItems { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Employee, EmployeeDetailsOutputModel>()
                .IncludeBase<Employee, EmployeeOutputModel>();
    }
}

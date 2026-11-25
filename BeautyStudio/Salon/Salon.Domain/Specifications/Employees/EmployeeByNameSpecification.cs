namespace Salon.Domain.Specifications.Employees
{
    using System.Linq.Expressions;
     
    using Salon.Domain.Models.Employees;
    using SharedKernel.Models;

    public class EmployeeByNameSpecification : Specification<Employee>
    {
        private readonly string? name;

        public EmployeeByNameSpecification(string? name) => this.name = name;

        protected override bool Include => !string.IsNullOrEmpty(this.name);

        public override Expression<Func<Employee, bool>> ToExpression()
            => employee => employee.FirstName.ToLower().Contains(this.name!.ToLower())
                        || employee.LastName.ToLower().Contains(this.name!.ToLower());
    }
}

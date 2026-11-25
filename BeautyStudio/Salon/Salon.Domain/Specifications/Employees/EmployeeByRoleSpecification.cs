namespace Salon.Domain.Specifications.Employees
{
    using System.Linq.Expressions;
     
    using Salon.Domain.Models.Employees;
    using SharedKernel.Models;

    public class EmployeeByRoleSpecification : Specification<Employee>
    {
        private readonly int? roleId;

        public EmployeeByRoleSpecification(int? roleId) => this.roleId = roleId;

        protected override bool Include => this.roleId != null;

        public override Expression<Func<Employee, bool>> ToExpression()
            => employee => employee.RoleId == this.roleId;
    }
}

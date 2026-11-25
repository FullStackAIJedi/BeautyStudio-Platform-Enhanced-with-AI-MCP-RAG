namespace Salon.Application.Admin.Commands.AssignRole
{
    using MediatR;
     
    using Salon.Application.Employees;
    using Salon.Domain.Specifications.Roles;

    using SharedKernel.Results;
    using SharedKernel.Security;

    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand, Result>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICurrentUser currentUser;

        public AssignRoleCommandHandler(
            IEmployeeRepository employeeRepository,
            ICurrentUser currentUser)
        {
            this.employeeRepository = employeeRepository;
            this.currentUser = currentUser;
        }


        public async Task<Result> Handle(
            AssignRoleCommand request,
            CancellationToken cancellationToken)
        { 
            if (!RoleManagementScope.CanManage(this.currentUser.RoleLevel, request.RoleId))
                return "You don't have permission to assign this role.";

            var employee = await this.employeeRepository.Find(request.EmployeeId, cancellationToken);
            if (employee == null) return "Employee not found.";

            employee.ChangeRole(request.RoleId);

            await this.employeeRepository.Save(employee, cancellationToken);
            return Result.Success;
        }
    }
}

namespace Salon.Application.Admin.Commands.AssignRole
{
    using MediatR; 
    using SharedKernel.Results;

    public class AssignRoleCommand : IRequest<Result>
    {
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
    }
}

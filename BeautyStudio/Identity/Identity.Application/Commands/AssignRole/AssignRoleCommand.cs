namespace Identity.Application.Commands.AssignRole
{ 
    using Identity.Application.Common;
    using MediatR;

    public class AssignRoleCommand : IRequest<Result>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}

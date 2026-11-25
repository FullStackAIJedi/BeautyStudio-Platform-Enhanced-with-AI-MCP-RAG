namespace Identity.Application.Commands.RemoveRole
{
    using Identity.Application.Common;
    using MediatR;

    public class RemoveRoleCommand : IRequest<Result>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}

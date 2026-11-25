namespace Identity.Application.Queries.GetUsersList
{
    using MediatR;

    public class GetUsersListQuery : IRequest<GetUsersListOutputModel>
    {
        public string? Search { get; set; }
        public int? RoleLevel { get; set; }
        public int Page { get; set; } = 1;
    }
}

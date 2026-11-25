namespace Identity.Application.Queries.GetUserById
{
    using MediatR;

    public class GetUserByIdQuery : IRequest<UserDetailsOutputModel>
    {
        public int UserId { get; set; }
    }
}

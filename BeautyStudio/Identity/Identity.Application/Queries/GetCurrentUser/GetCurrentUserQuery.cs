namespace Identity.Application.Queries.GetCurrentUser
{  
    using MediatR;

    public class GetCurrentUserQuery : IRequest<CurrentUserOutputModel>
    {
    }
}

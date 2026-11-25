namespace Identity.Application.Queries.GetUserById
{
    using Identity.Application.Common.Exceptions;
    using Identity.Application.Users;
    using MediatR;

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsOutputModel>
    {
        private readonly IUserRepository userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
            => this.userRepository = userRepository;

        public async Task<UserDetailsOutputModel> Handle(
            GetUserByIdQuery request,
            CancellationToken cancellationToken)
        {
            var user = await this.userRepository.Find(request.UserId, cancellationToken);
            if (user == null) throw new NotFoundException(nameof(GetUserByIdQuery), request.UserId);
            return new UserDetailsOutputModel(user);
        }
    }
}

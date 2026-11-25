namespace Identity.Application.Queries.GetCurrentUser
{ 
    using Identity.Application.Users;
    using MediatR;

    using SharedKernel.Security;

    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, CurrentUserOutputModel>
    {
        private readonly ICurrentUser currentUser;
        private readonly IUserRepository userRepository;

        public GetCurrentUserQueryHandler(
            ICurrentUser currentUser,
            IUserRepository userRepository)
        {
            this.currentUser = currentUser;
            this.userRepository = userRepository;
        }

        public async Task<CurrentUserOutputModel> Handle(
            GetCurrentUserQuery request,
            CancellationToken cancellationToken)
        {
            var user = await this.userRepository.Find(this.currentUser.UserId, cancellationToken);
            return new CurrentUserOutputModel(user);
        }
    }
}

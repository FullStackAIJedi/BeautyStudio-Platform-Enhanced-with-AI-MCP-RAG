namespace Identity.Application.Queries.GetUsersList
{ 
    using Identity.Application.Users;
    using MediatR;

    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, GetUsersListOutputModel>
    {
        private const int UsersPerPage = 20;

        private readonly IUserRepository userRepository;

        public GetUsersListQueryHandler(IUserRepository userRepository)
            => this.userRepository = userRepository;

        public async Task<GetUsersListOutputModel> Handle(
            GetUsersListQuery request,
            CancellationToken cancellationToken)
        {
            var skip = (request.Page - 1) * UsersPerPage;

            var users = await this.userRepository.GetListings(
                request.Search,
                request.RoleLevel,
                skip,
                UsersPerPage,
                cancellationToken);

            var total = await this.userRepository.Total(
                request.Search,
                request.RoleLevel,
                cancellationToken);

            var totalPages = (int)Math.Ceiling((double)total / UsersPerPage);

            return new GetUsersListOutputModel(users, request.Page, totalPages);
        }
    }
}

namespace Identity.Application.Queries.GetUsersList
{ 
    public class GetUsersListOutputModel
    {
        public GetUsersListOutputModel(
            IEnumerable<UserListItemOutputModel> users,
            int page,
            int totalPages)
        {
            this.Users = users;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<UserListItemOutputModel> Users { get; }
        public int Page { get; }
        public int TotalPages { get; }
    } 
}

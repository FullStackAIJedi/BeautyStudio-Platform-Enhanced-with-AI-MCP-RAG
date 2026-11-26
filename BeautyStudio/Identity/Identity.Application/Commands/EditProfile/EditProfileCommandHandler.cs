namespace Identity.Application.Commands.EditProfile
{
    using MediatR;

    using Identity.Application.Common;
    using SharedKernel.Security;

    public class EditProfileCommandHandler : IRequestHandler<EditProfileCommand, Result>
    {
        private readonly ICurrentUser currentUser;
        private readonly IIdentity identity;

        public EditProfileCommandHandler(
            ICurrentUser currentUser,
            IIdentity identity)
        {
            this.currentUser = currentUser;
            this.identity = identity;
        }

        public async Task<Result> Handle(
            EditProfileCommand request,
            CancellationToken cancellationToken)
            => await this.identity.EditProfile(
                this.currentUser.UserId, 
                request.FirstName, 
                request.LastName, 
                request.PhoneNumber);
    }
}

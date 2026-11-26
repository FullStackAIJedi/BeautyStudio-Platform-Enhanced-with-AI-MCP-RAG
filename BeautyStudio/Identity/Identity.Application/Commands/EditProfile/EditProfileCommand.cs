namespace Identity.Application.Commands.EditProfile
{
    using MediatR;
    using Identity.Application.Common;

    public class EditProfileCommand : IRequest<Result>
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
    }
}

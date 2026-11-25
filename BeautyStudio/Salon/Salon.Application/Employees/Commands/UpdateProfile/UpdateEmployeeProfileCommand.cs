namespace Salon.Application.Employees.Commands.UpdateProfile
{ 
    using MediatR;
    using SharedKernel.Results;

    public class UpdateEmployeeProfileCommand : IRequest<Result>
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Bio { get; set; } = default!;
        public string ProfilePhotoUrl { get; set; } = default!;
    }
}

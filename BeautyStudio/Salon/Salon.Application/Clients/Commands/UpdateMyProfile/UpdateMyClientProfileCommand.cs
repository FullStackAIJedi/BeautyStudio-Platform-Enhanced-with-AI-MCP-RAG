namespace Salon.Application.Clients.Commands.UpdateMyProfile
{
    using MediatR;
    using SharedKernel.Results;

    public class UpdateMyClientProfileCommand : IRequest<Result>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? HairType { get; set; }
        public string? HairLength { get; set; }
        public string? HairColor { get; set; }
        public string? ScalpType { get; set; }
        public string? Allergies { get; set; }
        public string? Sensitivities { get; set; }
    }
}

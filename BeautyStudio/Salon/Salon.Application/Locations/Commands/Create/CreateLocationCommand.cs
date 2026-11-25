namespace Salon.Application.Locations.Commands.Create
{
    using MediatR;
    using Salon.Application.Locations.Commands.Common;

    public class CreateLocationCommand : LocationCommand<CreateLocationCommand>, IRequest<CreateLocationOutputModel>
    { }
}

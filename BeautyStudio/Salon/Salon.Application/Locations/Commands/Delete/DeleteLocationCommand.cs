namespace Salon.Application.Locations.Commands.Delete
{
    using MediatR;

    using Salon.Application.Common;
    using SharedKernel.Results;

    public class DeleteLocationCommand : EntityCommand<int>, IRequest<Result>
    { }
}

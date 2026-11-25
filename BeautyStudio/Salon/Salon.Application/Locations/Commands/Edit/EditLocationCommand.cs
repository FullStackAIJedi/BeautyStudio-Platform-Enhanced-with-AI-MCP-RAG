namespace Salon.Application.Locations.Commands.Edit
{
    using MediatR;
     
    using Salon.Application.Locations.Commands.Common;
    using SharedKernel.Results;

    public class EditLocationCommand : LocationCommand<EditLocationCommand>, IRequest<Result>
    { }
}

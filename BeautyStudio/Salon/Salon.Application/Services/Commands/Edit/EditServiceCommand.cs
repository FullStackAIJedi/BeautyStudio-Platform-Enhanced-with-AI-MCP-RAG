namespace Salon.Application.Services.Commands.Edit
{
    using MediatR;
 
    using Salon.Application.Services.Commands.Common;
    using SharedKernel.Results;

    public class EditServiceCommand : ServiceCommand<EditServiceCommand>, IRequest<Result>
    { }
}

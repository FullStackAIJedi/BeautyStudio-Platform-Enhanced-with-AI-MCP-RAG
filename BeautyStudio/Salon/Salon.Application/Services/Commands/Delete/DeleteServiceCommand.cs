namespace Salon.Application.Services.Commands.Delete
{  
    using MediatR;

    using Salon.Application.Common;
    using SharedKernel.Results;

    public class DeleteServiceCommand : EntityCommand<int>, IRequest<Result>
    { }
}

namespace Salon.Application.Services.Commands.Create
{ 
    using MediatR;
    using Salon.Application.Services.Commands.Common;

    public class CreateServiceCommand : 
        ServiceCommand<CreateServiceCommand>, IRequest<CreateServiceOutputModel>
    { }
}

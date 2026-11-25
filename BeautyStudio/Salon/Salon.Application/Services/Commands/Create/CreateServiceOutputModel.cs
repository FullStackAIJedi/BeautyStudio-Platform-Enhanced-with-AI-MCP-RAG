namespace Salon.Application.Services.Commands.Create
{
    public class CreateServiceOutputModel
    {
        public CreateServiceOutputModel(int serviceId) => this.ServiceId = serviceId;
        public int ServiceId { get; }
    }
}

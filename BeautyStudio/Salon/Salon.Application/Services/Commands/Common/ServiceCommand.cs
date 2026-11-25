namespace Salon.Application.Services.Commands.Common
{
    using Salon.Application.Common;

    public abstract class ServiceCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int DurationMinutes { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}

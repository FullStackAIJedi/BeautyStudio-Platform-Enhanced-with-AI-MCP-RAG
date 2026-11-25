namespace SharedKernel.Models
{
    public interface IEntity
    {
        IReadOnlyCollection<IDomainEvent> Events { get; }
        void ClearEvents();
    }
}

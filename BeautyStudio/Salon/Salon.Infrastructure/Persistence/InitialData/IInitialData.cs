namespace Salon.Infrastructure.Persistence.InitialData
{
    public interface IInitialData
    {
        Type EntityType { get; }
        IEnumerable<object> GetData();
    }
}

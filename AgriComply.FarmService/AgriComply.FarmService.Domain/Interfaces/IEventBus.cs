namespace AgriComply.FarmerService.Domain.Interfaces
{
    using AgriComply.FarmerService.Domain.Events;
    using System.Threading.Tasks;

    public interface IEventBus
    {
        void Publish(DomainEvent domainEvent);
        Task PublishAsync(DomainEvent domainEvent);
    }
}

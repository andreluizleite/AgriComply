using AgriComply.FarmerService.Domain.Interfaces;
using AgriComply.FarmerService.Domain.Events;

namespace AgriComply.FarmerService.Infrastructure.EventBus
{
    public class InMemoryEventBus : IEventBus
    {
        public void Publish(DomainEvent domainEvent)
        {
            // Logic to publish the event
            Console.WriteLine($"Event published: {domainEvent.GetType().Name}");
        }

        public async Task PublishAsync(DomainEvent domainEvent)
        {
            Console.WriteLine($"Event published: {domainEvent.GetType().Name}");
        }
    }
}

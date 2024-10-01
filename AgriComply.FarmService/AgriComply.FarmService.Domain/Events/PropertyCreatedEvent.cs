using AgriComply.FarmerService.Domain.Events;
using AgriComply.PropertyService.Domain.Aggregates;

namespace AgriComply.PropertyService.Domain.Events
{
    public class PropertyCreatedEvent: DomainEvent
    {
        public Property Property { get; }

        public PropertyCreatedEvent(Property property)
        {
            Property = property;
        }
    }
}

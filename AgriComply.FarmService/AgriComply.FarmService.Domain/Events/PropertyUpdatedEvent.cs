using AgriComply.FarmerService.Domain.Events;
using AgriComply.PropertyService.Domain.Aggregates;

namespace AgriComply.PropertyService.Domain.Events
{
    public class PropertyUpdatedEvent: DomainEvent
    {
        public Property Property { get; }

        public PropertyUpdatedEvent(Property property)
        {
            Property = property;
        }
    }
}

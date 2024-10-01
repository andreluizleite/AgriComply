
using AgriComply.FarmerService.Domain.Aggregates;

namespace AgriComply.FarmerService.Domain.Events
{
    public class FarmerUpdatedEvent: DomainEvent
    {
        public Farmer Farmer { get; }

        public FarmerUpdatedEvent(Farmer farmer)
        {
            Farmer = farmer;
        }
    }
}

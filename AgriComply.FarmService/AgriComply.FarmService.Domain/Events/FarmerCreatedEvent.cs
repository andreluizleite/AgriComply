using AgriComply.FarmerService.Domain.Aggregates;

namespace AgriComply.FarmerService.Domain.Events
{
    public class FarmerCreatedEvent: DomainEvent
    {
        public Farmer Farmer { get; }

        public FarmerCreatedEvent(Farmer farmer)
        {
            Farmer = farmer;
        }
    }
}

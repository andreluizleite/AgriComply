using AgriComply.FarmerService.Domain.Aggregates;

namespace AgriComply.FarmerService.Domain.Events
{
    public class FarmerOnboardedEvent : DomainEvent
    {
        public Farmer Farmer { get; }

        public FarmerOnboardedEvent(Farmer farmer)
        {
            Farmer = farmer;
        }
    }
}

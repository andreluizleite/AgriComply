using AgriComply.FarmerService.Domain;
using AgriComply.PropertyService.Domain.Events;
using AgriComply.PropertyService.Domain.ValueObjects;

namespace AgriComply.PropertyService.Domain.Aggregates
{
    public class Property: AggregateRoot
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public Location Location { get; private set; }
        public Guid FarmerId { get; private set; }

        public Property(Guid id, string description, Location location, Guid farmerId)
        {
            Id = id;
            Description = description;
            Location = location;
            FarmerId = farmerId;
        }

        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
            RaiseEvent(new PropertyUpdatedEvent(this));
        }
    }
}

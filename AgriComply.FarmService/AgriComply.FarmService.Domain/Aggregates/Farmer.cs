using AgriComply.FarmerService.Domain.Events;
using AgriComply.FarmerService.Domain.ValueObjects;

namespace AgriComply.FarmerService.Domain.Aggregates
{
    public class Farmer : AggregateRoot
    {
        public string Name { get; private set; }
        public Status Status { get; private set; }

        public Farmer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Farmer name cannot be null or empty.", nameof(name));

            Name = name;
            Status = Status.Pending();
        }

        public void Onboard()
        {
            if (Status.Value == "Onboarded")
                throw new InvalidOperationException("Farmer is already onboarded.");

            Status = Status.Onboarded(); // Change status to Onboarded
            RaiseEvent(new FarmerOnboardedEvent(this));
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("New name cannot be null or empty.", nameof(newName));

            Name = newName;
            RaiseEvent(new FarmerUpdatedEvent(this));
        }
    }
}

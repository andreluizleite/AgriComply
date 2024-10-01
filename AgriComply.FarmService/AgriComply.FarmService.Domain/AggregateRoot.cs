using AgriComply.FarmerService.Domain.Events;

namespace AgriComply.FarmerService.Domain
{
    public abstract class AggregateRoot
    {
        private readonly List<DomainEvent> _domainEvents = new();

        // Method to raise a domain event
        protected void RaiseEvent(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        // Method to retrieve all domain events
        public IReadOnlyList<DomainEvent> GetDomainEvents() => _domainEvents.AsReadOnly();

        // Method to clear domain events after they have been processed
        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}

using AgriComply.ComplianceService.Domain.Events;
using AgriComply.ComplianceService.Domain.ValueObjects;

namespace AgriComply.ComplianceService.Domain.Aggregates
{
    public class Compliance : AggregateRoot
    {
        public Guid Id { get; private set; }
        public Guid PropertyId { get; private set; }
        public ComplianceStatus Status { get; private set; }
        public DateTime CheckedDate { get; private set; }

        public Compliance(Guid id, Guid propertyId, ComplianceStatus status)
        {
            Id = id;
            PropertyId = propertyId;
            Status = status;
            CheckedDate = DateTime.UtcNow;
        }

        public void UpdateStatus(ComplianceStatus newStatus)
        {
            Status = newStatus;
            RaiseEvent(new ComplianceUpdatedEvent(this));
        }
    }
}

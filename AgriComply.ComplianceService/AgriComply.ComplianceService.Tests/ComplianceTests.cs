using AgriComply.ComplianceService.Domain.Aggregates;
using AgriComply.ComplianceService.Domain.ValueObjects;
using AgriComply.ComplianceService.Domain.Events;

namespace AgriComply.ComplianceService.Tests
{
    public class ComplianceTests
    {
        [Fact]
        public void Compliance_ShouldInitialize_WithValidValues()
        {
            // Arrange
            var complianceId = Guid.NewGuid();
            var propertyId = Guid.NewGuid();
            var status = ComplianceStatus.UnderReview;

            // Act
            var compliance = new Compliance(complianceId, propertyId, status);

            // Assert
            Assert.Equal(complianceId, compliance.Id);
            Assert.Equal(propertyId, compliance.PropertyId);
            Assert.Equal(status, compliance.Status);
            Assert.True((DateTime.UtcNow - compliance.CheckedDate).TotalSeconds < 1); // Check if CheckedDate is set close to now
        }

        [Fact]
        public void UpdateStatus_ShouldChangeStatus_AndRaiseEvent()
        {
            // Arrange
            var complianceId = Guid.NewGuid();
            var propertyId = Guid.NewGuid();
            var initialStatus = ComplianceStatus.UnderReview;
            var newStatus = ComplianceStatus.Compliant;
            var compliance = new Compliance(complianceId, propertyId, initialStatus);

            // Act
            compliance.UpdateStatus(newStatus);

            // Assert
            Assert.Equal(newStatus, compliance.Status); // Check that the status was updated
            var events = compliance.GetDomainEvents(); // Retrieve raised domain events
            Assert.Single(events); // Ensure only one event was raised
            Assert.IsType<ComplianceUpdatedEvent>(events[0]); // Check if the correct event was raised
        }

        [Fact]
        public void UpdateStatus_WhenStatusAlreadyCompliant_ShouldUpdateStatus()
        {
            // Arrange
            var complianceId = Guid.NewGuid();
            var propertyId = Guid.NewGuid();
            var initialStatus = ComplianceStatus.Compliant;
            var newStatus = ComplianceStatus.NonCompliant;
            var compliance = new Compliance(complianceId, propertyId, initialStatus);

            // Act
            compliance.UpdateStatus(newStatus);

            // Assert
            Assert.Equal(newStatus, compliance.Status); // Check that the status was updated
            var events = compliance.GetDomainEvents(); // Retrieve raised domain events
            Assert.Single(events); // Ensure only one event was raised
            Assert.IsType<ComplianceUpdatedEvent>(events[0]); // Check if the correct event was raised
        }
    }
}

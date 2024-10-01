using Xunit;
using AgriComply.FarmerService.Domain.Aggregates;
using AgriComply.FarmerService.Domain.Events;
using AgriComply.FarmerService.Domain.ValueObjects;

namespace AgriComply.FarmerService.Tests
{
    public class FarmerTests
    {
        [Fact]
        public void Onboard_ShouldSetStatusToOnboarded_AndRaiseEvent()
        {
            // Arrange
            var farmerName = "Andre Leite"; // Ensure non-empty name
            var farmer = new Farmer(farmerName);

            // Act
            farmer.Onboard(); // This should change the status and raise an event

            // Assert
            Assert.Equal(Status.Onboarded().Value, farmer.Status.Value); // Check if the status is "Onboarded"
            var events = farmer.GetDomainEvents(); // Retrieve raised domain events from AggregateRoot
            Assert.Single(events); // Ensure only one event was raised
            Assert.IsType<FarmerOnboardedEvent>(events[0]); // Check if the raised event is FarmerOnboardedEvent
        }

        [Fact]
        public void UpdateFarmer_ShouldChangeFarmerName_AndRaiseEvent()
        {
            // Arrange
            var farmerName = "Andre Leite";
            var newFarmerName = "Maria";
            var farmer = new Farmer(farmerName);

            // Act
            farmer.UpdateName(newFarmerName); // Update farmer's name

            // Assert
            Assert.Equal(newFarmerName, farmer.Name); // Check if the name has changed
            var events = farmer.GetDomainEvents(); // Retrieve raised domain events
            Assert.Single(events); // Ensure only one event was raised
            Assert.IsType<FarmerUpdatedEvent>(events[0]); // Check if the correct event was raised
        }

        [Fact]
        public void Onboard_WhenAlreadyOnboarded_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var farmerName = "John Doe";
            var farmer = new Farmer(farmerName);
            farmer.Onboard(); // First onboarding should succeed

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => farmer.Onboard()); // Second onboarding should fail
            Assert.Equal("Farmer is already onboarded.", exception.Message); // Ensure the correct exception message is thrown
        }
    }
}

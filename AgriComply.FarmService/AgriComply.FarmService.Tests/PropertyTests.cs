using AgriComply.PropertyService.Domain.Aggregates;
using AgriComply.PropertyService.Domain.ValueObjects;
using AgriComply.PropertyService.Domain.Events;

namespace AgriComply.PropertyService.Tests
{
    public class PropertyTests
    {
        [Fact]
        public void Property_ShouldInitialize_WithValidValues()
        {
            // Arrange
            var propertyId = Guid.NewGuid();
            var description = "Test Property";
            var location = new Location(51.5074, -0.1278); 
            var farmerId = Guid.NewGuid();

            // Act
            var property = new Property(propertyId, description, location, farmerId);

            // Assert
            Assert.Equal(propertyId, property.Id);
            Assert.Equal(description, property.Description);
            Assert.Equal(location, property.Location);
            Assert.Equal(farmerId, property.FarmerId);
        }

        [Fact]
        public void UpdateDescription_ShouldChangeDescription_AndRaiseEvent()
        {
            // Arrange
            var propertyId = Guid.NewGuid();
            var initialDescription = "Old Description";
            var newDescription = "New Description";
            var location = new Location(51.5074, -0.1278);
            var farmerId = Guid.NewGuid();
            var property = new Property(propertyId, initialDescription, location, farmerId);

            // Act
            property.UpdateDescription(newDescription);

            // Assert
            Assert.Equal(newDescription, property.Description); // Check description change
            var events = property.GetDomainEvents(); // Retrieve raised domain events
            Assert.Single(events); // Ensure only one event was raised
            Assert.IsType<PropertyUpdatedEvent>(events[0]); // Check if the correct event was raised
        }
    }
}

using Xunit;
using AgriComply.FarmerService.Domain.ValueObjects;
using System;

namespace AgriComply.FarmerService.Tests
{
    public class StatusTests
    {
        [Fact]
        public void CreateStatus_Onboarded_ShouldCreateStatus()
        {
            // Act
            var status = Status.Onboarded();

            // Assert
            Assert.Equal("Onboarded", status.Value);
        }

        [Fact]
        public void CreateStatus_Pending_ShouldCreateStatus()
        {
            // Act
            var status = Status.Pending();

            // Assert
            Assert.Equal("Pending", status.Value);
        }

        [Fact]
        public void CreateStatus_Verified_ShouldCreateStatus()
        {
            // Act
            var status = Status.Verified();

            // Assert
            Assert.Equal("Verified", status.Value);
        }

        [Fact]
        public void CreateStatus_Suspended_ShouldCreateStatus()
        {
            // Act
            var status = Status.Suspended();

            // Assert
            Assert.Equal("Suspended", status.Value);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")] // Only whitespace
        public void CreateStatus_WithInvalidValue_ShouldThrowArgumentException(string invalidValue)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Status(invalidValue));
        }

        [Fact]
        public void Equals_WhenSameValue_ShouldReturnTrue()
        {
            // Arrange
            var status1 = Status.Onboarded();
            var status2 = Status.Onboarded();

            // Act
            bool areEqual = status1.Equals(status2);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void Equals_WhenDifferentValue_ShouldReturnFalse()
        {
            // Arrange
            var status1 = Status.Onboarded();
            var status2 = Status.Pending();

            // Act
            bool areEqual = status1.Equals(status2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void ToString_ShouldReturnValue()
        {
            // Arrange
            var status = Status.Verified();

            // Act
            string result = status.ToString();

            // Assert
            Assert.Equal("Verified", result);
        }

        [Fact]
        public void GetHashCode_ShouldReturnSameValue_ForEqualObjects()
        {
            // Arrange
            var status1 = Status.Suspended();
            var status2 = Status.Suspended();

            // Act
            int hashCode1 = status1.GetHashCode();
            int hashCode2 = status2.GetHashCode();

            // Assert
            Assert.Equal(hashCode1, hashCode2);
        }
    }
}

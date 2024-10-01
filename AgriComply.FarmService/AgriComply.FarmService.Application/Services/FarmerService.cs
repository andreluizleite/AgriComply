using AgriComply.FarmerService.Application.Interfaces;
using AgriComply.FarmerService.Domain.Aggregates;
using AgriComply.FarmerService.Domain.Events;
using AgriComply.FarmerService.Domain.Interfaces;

namespace AgriComply.FarmerService.Application.Services
{
    public class FarmerService : IFarmerService
    {
        private readonly IFarmerRepository _farmerRepository;
        private readonly IEventBus _eventBus;

        public FarmerService(IFarmerRepository farmerRepository, IEventBus eventBus)
        {
            _farmerRepository = farmerRepository;
            _eventBus = eventBus;
        }

        public async Task OnboardFarmerAsync(string farmerName)
        {
            try
            {
                // Validate farmer name
                if (string.IsNullOrWhiteSpace(farmerName))
                {
                    throw new ArgumentException("Farmer name cannot be empty.", nameof(farmerName));
                }

                // Create a new Farmer aggregate
                var farmer = new Farmer(farmerName);
                farmer.Onboard(); // This will raise the FarmerOnboardedEvent

                // Save the farmer to the repository
                await _farmerRepository.AddAsync(farmer);

                // Handle domain events
                await HandleFarmerOnboardedAsync(farmer);
            }
            catch (Exception ex)
            {
                // Log the error (consider using a logging library)
                throw new ApplicationException("Error onboarding farmer.", ex);
            }
        }

        private async Task HandleFarmerOnboardedAsync(Farmer farmer)
        {
            var events = farmer.GetDomainEvents();

            foreach (var domainEvent in events)
            {
                if (domainEvent is FarmerOnboardedEvent)
                {
                    // Perform necessary actions for the FarmerOnboardedEvent
                    await _eventBus.PublishAsync(domainEvent);
                }
            }

            // Clear the events after processing
            farmer.ClearDomainEvents();
        }
    }
}

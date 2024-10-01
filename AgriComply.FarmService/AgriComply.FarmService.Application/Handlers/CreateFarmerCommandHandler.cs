using AgriComply.FarmerService.Application.Commands;
using AgriComply.FarmerService.Application.Interfaces;
using MediatR;

namespace AgriComply.FarmerService.Application.Handlers
{
    public class CreateFarmerCommandHandler : IRequestHandler<CreateFarmerCommand, Unit>
    {
        private readonly IFarmerService _farmerService;

        public CreateFarmerCommandHandler(IFarmerService farmerService)
        {
            _farmerService = farmerService;
        }

        public async Task<Unit> Handle(CreateFarmerCommand request, CancellationToken cancellationToken)
        {
            // Call the service to onboard the farmer
            await _farmerService.OnboardFarmerAsync(request.FarmerName);

            // Return Unit to indicate the command has been handled
            return await Task.FromResult(Unit.Value); // Placeholder for async operations if needed
        }
    }
}

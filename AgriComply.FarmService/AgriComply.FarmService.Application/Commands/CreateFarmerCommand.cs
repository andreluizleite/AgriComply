using MediatR;

namespace AgriComply.FarmerService.Application.Commands
{
    public class CreateFarmerCommand : IRequest<Unit>
    {
        public string FarmerName { get; }

        public CreateFarmerCommand(string farmerName)
        {
            FarmerName = farmerName;
        }
    }
}
    
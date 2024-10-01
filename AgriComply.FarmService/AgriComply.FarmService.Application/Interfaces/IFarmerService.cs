using System.Threading.Tasks;

namespace AgriComply.FarmerService.Application.Interfaces
{
    public interface IFarmerService
    {
        Task OnboardFarmerAsync(string farmerName);
    }
}

using AgriComply.FarmerService.Domain.Aggregates;

namespace AgriComply.FarmerService.Domain.Interfaces
{
    public interface IFarmerRepository
    {
        void Add(Farmer farmer);
        Farmer GetById(Guid id);
        IEnumerable<Farmer> GetAll();
        Task AddAsync(Farmer farmer);
    }
}

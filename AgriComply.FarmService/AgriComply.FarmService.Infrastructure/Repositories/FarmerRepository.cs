using AgriComply.FarmerService.Domain.Aggregates;
using AgriComply.FarmerService.Domain.Interfaces;

namespace AgriComply.FarmerService.Infrastructure.Repositories
{
    public class FarmerRepository : IFarmerRepository
    {
        private readonly ApplicationDbContext _context;

        public FarmerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Farmer farmer)
        {
            _context.Farmers.Add(farmer);
            // Consider adding SaveChanges() here if immediate saving is required.
        }

        public Farmer GetById(Guid id)
        {
            return _context.Farmers.Find(id);
        }

        public IEnumerable<Farmer> GetAll()
        {
            return _context.Farmers.ToList();
        }

        public async Task AddAsync(Farmer farmer)
        {
            await _context.Farmers.AddAsync(farmer);
            // Save changes can be called here if you want to persist immediately
            // await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

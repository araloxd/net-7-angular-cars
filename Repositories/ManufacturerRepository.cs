using Microsoft.EntityFrameworkCore;
using net_7_angular_cars.Contexts;
using net_7_angular_cars.Models;

namespace net_7_angular_cars.Repositories
{
    public class ManufacturerRepository : BaseRepository<Manufacturer>
    {
        public ManufacturerRepository(ApplicationDbContext context) : base(context) { }
        public async Task<IEnumerable<Manufacturer>> GetManufacturers()
        {
            return await GetAllAsync();
        }

        public async Task<Manufacturer?> GetManufacturerByNameAsync(string manufacturerName)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.Name == manufacturerName);
        }
    }
}

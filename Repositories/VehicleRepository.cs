using Microsoft.EntityFrameworkCore;
using net_7_angular_cars.Contexts;
using net_7_angular_cars.Models;

namespace net_7_angular_cars.Repositories
{
    public class VehicleRepository : IRepository<Vehicle>
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return  _context.Vehicles
                .Include(v => v.Category)
                .Include(v => v.User)
                .Include(v => v.Manufacturer)
                .ToList();
        }
        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _context.Vehicles
                .Include(v => v.Category)
                .Include(v => v.User)
                .Include(v => v.Manufacturer)
                .ToListAsync();
        }

        public Vehicle GetById(int id)
        {
            return _context.Vehicles.Find(id);
        }

        public void Add(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        public void Update(int id, Vehicle vehicle)
        {
            var existingVehicle = _context.Vehicles.Find(id);
            if (existingVehicle != null)
            {
                existingVehicle.OwnerName = vehicle.OwnerName;
                existingVehicle.Manufacturer = vehicle.Manufacturer;
                existingVehicle.YearOfManufacture = vehicle.YearOfManufacture;

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
            }
        }

        public Task AddAsync(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}

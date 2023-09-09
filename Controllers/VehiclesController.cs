using Microsoft.AspNetCore.Mvc;
using net_7_angular_cars.Models;
using net_7_angular_cars.Repositories;

namespace net_7_angular_cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {

        private readonly IRepository<Vehicle> _vehicleRepository;
        private readonly ManufacturerRepository _manufacturerRepository;
        private readonly CategoryRepository _categoryRepository;

        public VehiclesController(
            IRepository<Vehicle> vehicleRepository,
            IRepository<Manufacturer> manufacturerRepository,
            IRepository<Category> categoryRepository)
        {
            _vehicleRepository = vehicleRepository;
            _manufacturerRepository = manufacturerRepository as ManufacturerRepository;
            _categoryRepository = categoryRepository as CategoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> Get()
        {
            var vehicles = await _vehicleRepository.GetAllAsync();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public ActionResult<Vehicle> GetById(int id)
        {
            var vehicle = _vehicleRepository.GetById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpPost]
        public new async Task<ActionResult<Vehicle>> Add(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                Category category = await _categoryRepository.GetCategoryByWeight(vehicle.Weight);
                if(category == null)
                {
                    throw new Exception("Not Category in that weight range");
                }

                Manufacturer manufacturer = await _manufacturerRepository.GetManufacturerByNameAsync(vehicle.Manufacturer.Name);

                if (category == null)
                {
                    throw new Exception("Not found manufacturer");
                }

                vehicle.Category = category;
                vehicle.Manufacturer = manufacturer;

                //vehicle.CategoryId = category.Id;
                _vehicleRepository.Add(vehicle);
                return CreatedAtAction(nameof(GetById), new { id = vehicle.Id }, vehicle);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Vehicle vehicle)
        {
            var existingVehicle = _vehicleRepository.GetById(id);
            if (existingVehicle == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _vehicleRepository.Update(id, vehicle);
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var vehicle = _vehicleRepository.GetById(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _vehicleRepository.Delete(id);
            return NoContent();
        }
    }
}

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

        public VehiclesController(IRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
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
        public ActionResult<Vehicle> Add(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
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

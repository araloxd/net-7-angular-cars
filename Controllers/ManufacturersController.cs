using Microsoft.AspNetCore.Mvc;
using net_7_angular_cars.Models;
using net_7_angular_cars.Repositories;

namespace net_7_angular_cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : BaseController<Manufacturer, IRepository<Manufacturer>>
    {
        public ManufacturersController(IRepository<Manufacturer> categoryRepository)
            : base(categoryRepository)
        {
        }
    }
}
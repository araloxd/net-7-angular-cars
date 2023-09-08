using Microsoft.AspNetCore.Mvc;
using net_7_angular_cars.Models;
using net_7_angular_cars.Repositories;

namespace net_7_angular_cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<User, IRepository<User>>
    {
        public UsersController(IRepository<User> userRepository): base(userRepository){}

        [HttpPost]
        public new async Task Create(User entity)
        {
            await Repository.AddAsync(entity);
        }

    }
}

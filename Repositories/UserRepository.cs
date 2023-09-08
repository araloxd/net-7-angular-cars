using net_7_angular_cars.Contexts;
using net_7_angular_cars.Models;

namespace net_7_angular_cars.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

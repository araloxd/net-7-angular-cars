using net_7_angular_cars.Contexts;
using net_7_angular_cars.Models;

namespace net_7_angular_cars.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(ApplicationDbContext context) : base(context){}
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await GetAllAsync();
        }
    }
}

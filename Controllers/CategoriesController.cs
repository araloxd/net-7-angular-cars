using Microsoft.AspNetCore.Mvc;
using net_7_angular_cars.Models;
using net_7_angular_cars.Repositories;

namespace net_7_angular_cars.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : BaseController<Category, IRepository<Category>>
    {
        public CategoriesController(IRepository<Category> categoryRepository)
            : base(categoryRepository)
        {
        }
    }
}

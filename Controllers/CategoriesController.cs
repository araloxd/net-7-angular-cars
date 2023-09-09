using Microsoft.AspNetCore.Mvc;
using net_7_angular_cars.Models;
using net_7_angular_cars.Repositories;

namespace net_7_angular_cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController<Category, IRepository<Category>>
    {
        CategoryRepository _categoryRepository;
        public CategoriesController(IRepository<Category> categoryRepository)
            : base(categoryRepository)
        {
            _categoryRepository = categoryRepository as CategoryRepository;
        }

        [HttpPost]
        public new async Task Create(Category entity)
        {
            await _categoryRepository.AddAsync(entity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Category newCategory)
        {
            var existingCategory = Repository.GetById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // This changes should be in a service, to create a layer in the middle of the repos and controllers.
                existingCategory.MinWeight = newCategory.MinWeight;
                existingCategory.MaxWeight = newCategory.MaxWeight;
                existingCategory.Name = newCategory.Name;
                existingCategory.Icon = newCategory.Icon;

                Repository.Update(existingCategory);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public new void Delete(int id)
        {
            Repository.Delete(id);
        }
    }
}

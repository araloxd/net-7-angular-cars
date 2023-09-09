using Microsoft.EntityFrameworkCore;
using net_7_angular_cars.Contexts;
using net_7_angular_cars.Models;

namespace net_7_angular_cars.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public ApplicationDbContext Context { get; }

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await GetAllAsync();
        }

        public async Task<Category?>GetCategoryByWeight(decimal weight)
        {
           return await _dbSet.FirstOrDefaultAsync(c => weight >= c.MinWeight && weight <= c.MaxWeight);
        }

        public new async Task AddAsync(Category newCategory)
        {
            var categories = base.GetAll();
            // Validations should be done with fluent or service.
            if (!HasNoOverlaps(categories, newCategory))
            {
                throw new Exception("Categories are overlaped");
            }

            categories.Append(newCategory);

            if (!HasNoGaps(categories))
            {
                throw new Exception("Can't be a gap between categories");
            }

            base.AddAsync(newCategory);

        }

        public new async Task Update(Category existingCategory)
        {
            base.Update(existingCategory);
        }

        public new Task Delete(Category category)
        {
            return Delete(category);
        }

        // Following code should be in a Service

        public bool HasNoOverlaps(IEnumerable<Category> categories, Category newCategory)
        {
            foreach (var existingCategory in categories)
            {
                if (!(newCategory.MaxWeight <= existingCategory.MinWeight || newCategory.MinWeight >= existingCategory.MaxWeight))
                {
                    return false;
                }
            }

            return true;
        }

        public bool HasNoGaps(IEnumerable<Category> categories)
        {
            var sortedCategories = categories.OrderBy(c => c.MinWeight).ToList();

            for (int i = 1; i < sortedCategories.Count; i++)
            {
                if (sortedCategories[i].MinWeight - 1 != sortedCategories[i - 1].MaxWeight)
                {
                    return false;
                }
            }

            return true;
        }


    }
}

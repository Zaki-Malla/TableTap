using Microsoft.EntityFrameworkCore;
using TableTap.Models;

namespace TableTap.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TTContext _context;
        public CategoryRepository(TTContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryModel>> GetAllCategorysAsync()
        {
            return await _context.TbCategories
                .Include(p => p.Menu)
                .ToListAsync();
        }

        public async Task<CategoryModel> GetCategoryByIdAsync(int id)
        {
            return await _context.TbCategories
                .Include(p => p.Menu)
                .FirstOrDefaultAsync(p => p.MenuId == id);
        }

        public async Task AddCategoryAsync(CategoryModel category)
        {
            await _context.TbCategories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(CategoryModel category)
        {
            _context.TbCategories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.TbCategories.FindAsync(id);
            if (category != null)
            {
                _context.TbCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

    }
}

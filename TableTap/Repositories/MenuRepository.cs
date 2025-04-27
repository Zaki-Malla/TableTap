using Microsoft.EntityFrameworkCore;
using TableTap.Models;

namespace TableTap.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly TTContext _context;
        public MenuRepository(TTContext context)
        {
            _context = context;
        }

        public async Task<List<MenuModel>> GetAllMenusAsync()
        {
            return await _context.TbMenus
                .Include(p => p.Establishment)
                .ToListAsync();
        }

        public async Task<MenuModel> GetMenuByIdAsync(int id)
        {
            return await _context.TbMenus
                .Include(p => p.Establishment)
                .FirstOrDefaultAsync(p => p.MenuId == id);
        }

        public async Task AddMenuAsync(MenuModel menu)
        {
            await _context.TbMenus.AddAsync(menu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMenuAsync(MenuModel menu)
        {
            _context.TbMenus.Update(menu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuAsync(int id)
        {
            var menu = await _context.TbMenus.FindAsync(id);
            if (menu != null)
            {
                _context.TbMenus.Remove(menu);
                await _context.SaveChangesAsync();
            }
        }
    }
}


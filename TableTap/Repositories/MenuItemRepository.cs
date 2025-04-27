using Microsoft.EntityFrameworkCore;
using TableTap.Models;

namespace TableTap.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly TTContext _context;
        public MenuItemRepository(TTContext context)
        {
            _context = context;
        }

        public async Task<List<MenuItemModel>> GetAllMenuItemsAsync()
        {
            return await _context.TbMenuItems
                .Include(p =>p.Category)
                .ToListAsync();
        }

        public async Task<MenuItemModel> GetMenuItemByIdAsync(int id)
        {
            return await _context.TbMenuItems
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.MenuItemId == id);
        }

        public async Task AddMenuItemAsync(MenuItemModel menuItem)
        {
            await _context.TbMenuItems.AddAsync(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMenuItemAsync(MenuItemModel menuItem)
        {
            _context.TbMenuItems.Update(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuItemAsync(int id)
        {
            var menuItem = await _context.TbMenuItems.FindAsync(id);
            if (menuItem != null)
            {
                _context.TbMenuItems.Remove(menuItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}


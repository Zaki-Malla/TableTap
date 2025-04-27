using TableTap.Models;

namespace TableTap.Repositories
{
    public interface IMenuItemRepository
    {
        Task<List<MenuItemModel>> GetAllMenuItemsAsync();

        Task<MenuItemModel> GetMenuItemByIdAsync(int id);
        Task AddMenuItemAsync(MenuItemModel menuItem);

        Task UpdateMenuItemAsync(MenuItemModel menuItem);

        Task DeleteMenuItemAsync(int id);
    }
}

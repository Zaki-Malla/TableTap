using TableTap.Models;

namespace TableTap.Repositories
{
    public interface IMenuRepository
    {
        Task<List<MenuModel>> GetAllMenusAsync();

        Task<MenuModel> GetMenuByIdAsync(int id);
        Task AddMenuAsync(MenuModel menu);

        Task UpdateMenuAsync(MenuModel menu);

        Task DeleteMenuAsync(int id);
    }
}

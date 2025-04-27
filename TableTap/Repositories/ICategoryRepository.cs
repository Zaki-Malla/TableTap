using TableTap.Models;

namespace TableTap.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModel>> GetAllCategorysAsync();

        Task<CategoryModel> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CategoryModel category);

        Task UpdateCategoryAsync(CategoryModel category);

        Task DeleteCategoryAsync(int id);
    }
}

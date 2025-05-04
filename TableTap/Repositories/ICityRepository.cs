using Microsoft.AspNetCore.Mvc.RazorPages;
using TableTap.Models;

namespace TableTap.Repositories
{
    public interface ICityRepository
    {
        Task<List<CityModel>> GetAllCitysAsync();

        Task<CityModel> GetCityByIdAsync(int id);
        Task AddCityAsync(CityModel city);

        Task UpdateCityAsync(CityModel city);

        Task DeleteCityAsync(int id);
        Task ToggleCityStatusAsync(int id);
    }
}

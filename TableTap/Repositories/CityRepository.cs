using Microsoft.EntityFrameworkCore;
using TableTap.Models;

namespace TableTap.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly TTContext _context;

        public CityRepository(TTContext context)
        {
            _context = context;
        }

        public async Task<List<CityModel>> GetAllCitysAsync()
        {
            return await _context.TbCity
                .Include(p => p.Establishments)
                .ToListAsync();
        }

        public async Task<CityModel> GetCityByIdAsync(int id)
        {
            return await _context.TbCity
                .Include(p => p.Establishments)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddCityAsync(CityModel city)
        {
            await _context.TbCity.AddAsync(city);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCityAsync(CityModel city)
        {
            _context.TbCity.Update(city);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCityAsync(int id)
        {
            var City = await _context.TbCity.FindAsync(id);
            if (City != null)
            {
                _context.TbCity.Remove(City);
                await _context.SaveChangesAsync();
            }
        }
    }
}

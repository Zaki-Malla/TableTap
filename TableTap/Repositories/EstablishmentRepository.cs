using Microsoft.EntityFrameworkCore;
using TableTap.Models;
using TableTap.Models.HelperModels;

namespace TableTap.Repositories
{
    public class EstablishmentRepository : IEstablishmentRepository
    {
            private readonly TTContext _context;

            public EstablishmentRepository(TTContext context)
            {
                _context = context;
            }

            public async Task<List<EstablishmentModel>> GetAllEstablishmentsAsync()
            {
                return await _context.TbEstablishment
                    .Include(p => p.City)
                    .ToListAsync();
            }

            public async Task<EstablishmentModel> GetEstablishmentByIdAsync(int id)
            {
                return await _context.TbEstablishment
                    .Include(p => p.City)
                    .FirstOrDefaultAsync(p => p.Id == id);
            }

            public async Task AddEstablishmentAsync(EstablishmentModel establishment)
            {
                await _context.TbEstablishment.AddAsync(establishment);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateEstablishmentAsync(EstablishmentModel establishment)
            {
                _context.TbEstablishment.Update(establishment);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteEstablishmentAsync(int id)
            {
                var Establishment = await _context.TbEstablishment.FindAsync(id);
                if (Establishment != null)
                {
                    _context.TbEstablishment.Remove(Establishment);
                    await _context.SaveChangesAsync();
                }
            }
    }
}

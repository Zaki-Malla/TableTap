using TableTap.Models;
using TableTap.Models.HelperModels;
namespace TableTap.Repositories
{
    public interface IEstablishmentRepository
    {
        Task<List<EstablishmentModel>> GetAllEstablishmentsAsync();

        Task<EstablishmentModel> GetEstablishmentByIdAsync(int id);
        Task AddEstablishmentAsync(EstablishmentModel establishment);

        Task UpdateEstablishmentAsync(EstablishmentModel establishment);

        Task DeleteEstablishmentAsync(int id);
    }
}

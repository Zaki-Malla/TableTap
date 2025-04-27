using TableTap.Models;

namespace TableTap.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<List<SubscriptionModel>> GetAllSubscriptionsAsync();

        Task<SubscriptionModel> GetSubscriptionByIdAsync(int id);
        Task AddSubscriptionAsync(SubscriptionModel subscription);

        Task UpdateSubscriptionAsync(SubscriptionModel subscription);

        Task DeleteSubscriptionAsync(int id);
    }
}

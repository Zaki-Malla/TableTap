using TableTap.Models;

namespace TableTap.Repositories
{
    public interface ISubscriptionPlanRepository
    {
        Task<List<SubscriptionPlanModel>> GetAllSubscriptionPlansAsync();

        Task<SubscriptionPlanModel> GetSubscriptionPlanByIdAsync(int id);
        Task AddSubscriptionPlanAsync(SubscriptionPlanModel subscriptionPlan);

        Task UpdateSubscriptionPlanAsync(SubscriptionPlanModel subscriptionPlan);

        Task DeleteSubscriptionPlanAsync(int id);
    }
}

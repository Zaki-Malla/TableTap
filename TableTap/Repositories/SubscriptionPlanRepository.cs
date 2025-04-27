using Microsoft.EntityFrameworkCore;
using TableTap.Models;

namespace TableTap.Repositories
{
    public class SubscriptionPlanRepository : ISubscriptionPlanRepository
    {
        private readonly TTContext _context;

        public SubscriptionPlanRepository(TTContext context)
        {
            _context = context;
        }

        public async Task<List<SubscriptionPlanModel>> GetAllSubscriptionPlansAsync()
        {
            return await _context.TbSubscriptionPlan
                .Include(p => p.Subscriptions)
                .ToListAsync();
        }

        public async Task<SubscriptionPlanModel> GetSubscriptionPlanByIdAsync(int id)
        {
            return await _context.TbSubscriptionPlan
                .Include(p => p.Subscriptions)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddSubscriptionPlanAsync(SubscriptionPlanModel subscriptionPlan)
        {
            await _context.TbSubscriptionPlan.AddAsync(subscriptionPlan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubscriptionPlanAsync(SubscriptionPlanModel subscriptionPlan)
        {
            _context.TbSubscriptionPlan.Update(subscriptionPlan);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubscriptionPlanAsync(int id)
        {
            var SubscriptionPlan = await _context.TbSubscriptionPlan.FindAsync(id);
            if (SubscriptionPlan != null)
            {
                _context.TbSubscriptionPlan.Remove(SubscriptionPlan);
                await _context.SaveChangesAsync();
            }
        }
    }
}

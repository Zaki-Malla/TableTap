using Microsoft.EntityFrameworkCore;
using TableTap.Models;

namespace TableTap.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly TTContext _context;

        public SubscriptionRepository(TTContext context)
        {
            _context = context;
        }

        public async Task<List<SubscriptionModel>> GetAllSubscriptionsAsync()
        {
            return await _context.TbSubscription
                .Include(p => p.Establishment)
                .Include(p => p.Plan)
                .ToListAsync();
        }

        public async Task<SubscriptionModel> GetSubscriptionByIdAsync(int id)
        {
            return await _context.TbSubscription
                .Include(p => p.Establishment)
                .Include(p => p.Plan)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddSubscriptionAsync(SubscriptionModel subscription)
        {
            await _context.TbSubscription.AddAsync(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubscriptionAsync(SubscriptionModel subscription)
        {
            _context.TbSubscription.Update(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubscriptionAsync(int id)
        {
            var Subscription = await _context.TbSubscription.FindAsync(id);
            if (Subscription != null)
            {
                _context.TbSubscription.Remove(Subscription);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TableTap.Models;

namespace TableTap.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly TTContext _context;

        public PaymentMethodRepository(TTContext context)
        {
            _context = context;
        }

        public async Task<List<PaymentMethodModel>> GetAllPaymentMethodsAsync()
        {
            return await _context.TbPaymentMethod
                .Include(m => m.PaymentRequests)
                .ThenInclude(r => r.Establishment)
                .ToListAsync();
        }

        public async Task<PaymentMethodModel> GetPaymentMethodByIdAsync(int id)
        {
            return await _context.TbPaymentMethod
                .Include(m => m.PaymentRequests)
                .ThenInclude(r => r.Establishment)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddPaymentMethodAsync(PaymentMethodModel method)
        {
            await _context.TbPaymentMethod.AddAsync(method); 
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePaymentMethodAsync(PaymentMethodModel method)
        {
            _context.TbPaymentMethod.Update(method); 
            await _context.SaveChangesAsync();
        }

        public async Task DeletePaymentMethodAsync(int id)
        {
            var method = await _context.TbPaymentMethod.FindAsync(id);
            if (method != null)
            {
                _context.TbPaymentMethod.Remove(method);
                await _context.SaveChangesAsync();
            }
        }
    }
}

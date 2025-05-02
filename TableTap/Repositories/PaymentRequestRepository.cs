using Microsoft.EntityFrameworkCore;
using TableTap.Models;

namespace TableTap.Repositories
{
    public class PaymentRequestRepository : IPaymentRequestRepository
    {
        private readonly TTContext _context;

        public PaymentRequestRepository(TTContext context)
        {
            _context = context;
        }
        public async Task<List<PaymentRequestModel>> GetAllPaymentRequestsAsync()
        {
            return await _context.TbPaymentRequest
                .Include(r => r.Establishment) 
                .Include(r => r.PaymentMethod) 
                .ToListAsync();
        }

        public async Task<PaymentRequestModel> GetPaymentRequestByIdAsync(int id)
        {
            return await _context.TbPaymentRequest
                .Include(r => r.Establishment) 
                .Include(r => r.PaymentMethod) 
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddPaymentRequestAsync(PaymentRequestModel request)
        {
            await _context.TbPaymentRequest.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePaymentRequestAsync(PaymentRequestModel request)
        {
            _context.TbPaymentRequest.Update(request);
            await _context.SaveChangesAsync(); 
        }

        public async Task DeletePaymentRequestAsync(int id)
        {
            var request = await _context.TbPaymentRequest.FindAsync(id);
            if (request != null)
            {
                _context.TbPaymentRequest.Remove(request);
                await _context.SaveChangesAsync();
            }
        }
    }
}

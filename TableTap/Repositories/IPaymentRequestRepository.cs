using TableTap.Models;

namespace TableTap.Repositories
{
    public interface IPaymentRequestRepository
    {
        Task<List<PaymentRequestModel>> GetAllPaymentRequestsAsync();
        Task<PaymentRequestModel> GetPaymentRequestByIdAsync(int id); 
        Task AddPaymentRequestAsync(PaymentRequestModel request); 
        Task UpdatePaymentRequestAsync(PaymentRequestModel request);
        Task DeletePaymentRequestAsync(int id);
    }
}

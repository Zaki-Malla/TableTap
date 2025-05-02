using TableTap.Models;

namespace TableTap.Repositories
{
    public interface IPaymentMethodRepository
    {
        Task<List<PaymentMethodModel>> GetAllPaymentMethodsAsync(); 
        Task<PaymentMethodModel> GetPaymentMethodByIdAsync(int id); 
        Task AddPaymentMethodAsync(PaymentMethodModel method); 
        Task UpdatePaymentMethodAsync(PaymentMethodModel method); 
        Task DeletePaymentMethodAsync(int id); 
    }
}

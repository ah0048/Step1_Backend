using Microsoft.EntityFrameworkCore;
using Step1_Backend.Models;

namespace Step1_Backend.Repositories.PaymentOrderRepository
{
    public class PaymentOrderRepository : IPaymentOrderRepository
    {
        private readonly AppDbContext _dbContext;
        public PaymentOrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(PaymentOrder obj)
        {
            await _dbContext.PaymentOrders.AddAsync(obj);
        }

        public async Task DeleteAsync(int id)
        {
            PaymentOrder? paymentOrder = await GetByIdAsync(id);
            if (paymentOrder != null)
            {
                _dbContext.PaymentOrders.Remove(paymentOrder);
            }
        }

        public Task EditAsync(PaymentOrder obj)
        {
            if (obj != null)
            {
                _dbContext.Attach(obj);
                _dbContext.Entry(obj).State = EntityState.Modified;
            }
            return Task.CompletedTask;
        }

        public async Task<List<PaymentOrder>> GetAllAsync()
        {
            return await _dbContext.PaymentOrders.ToListAsync();
        }

        public async Task<PaymentOrder?> GetByIdAsync(int id)
        {
            return await _dbContext.PaymentOrders.FindAsync(id);
        }
    }
}

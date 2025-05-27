using Microsoft.EntityFrameworkCore;
using Netronix.API.Data;
using Netronix.API.Models.Domains;

namespace Netronix.API.Repositories
{
    public class SQLOrderRepository : IOrderRepository
    {
        private readonly NetronixDbContext dbContext;

        public SQLOrderRepository(NetronixDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Order> CreateAsync(Order order)
        {
            order.Id = Guid.NewGuid(); 
            order.OrderDate = DateTime.UtcNow;
            order.IsGuestOrder = true;
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> DeleteAsync(Guid id)
        {
            var existing = await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (existing == null) return null;
            dbContext.Orders.Remove(existing);
            await dbContext.SaveChangesAsync();
            return existing;
            
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await dbContext.Orders.OrderByDescending(x => x.OrderDate).ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public Task<List<Order>> GetOrdersByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Order?> UpdateAsync(Guid Id, Order order)
        {
            var existing = await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == Id);
            if (existing == null) return null;
            existing.OrderDate = order.OrderDate;
            existing.IsGuestOrder = order.IsGuestOrder;
            existing.Status = order.Status;
            existing.PaymentMethod = order.PaymentMethod;
            existing.ShippingAddress = order.ShippingAddress;
            existing.Subtotal = order.Subtotal;
            existing.DeliveryFee = order.DeliveryFee;
            existing.TotalAmount = order.TotalAmount;
            existing.IsPaid = order.IsPaid;
            existing.OrderNumber = order.OrderNumber;
            existing.items = order.items;
            dbContext.Orders.Update(existing);
            await dbContext.SaveChangesAsync();
            return existing;

        }
    }
}

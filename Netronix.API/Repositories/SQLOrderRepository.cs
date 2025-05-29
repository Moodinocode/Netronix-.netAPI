using Microsoft.EntityFrameworkCore;
using Netronix.API.Data;
using Netronix.API.Models.Domains;
using Netronix.API.Models.DTOs;

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
           // order.Subtotal = order.items.Sum(item => item.product.Price * item.Quantity); 
            //order.TotalAmount = order.Subtotal + order.DeliveryFee; 
            order.OrderNumber = await dbContext.Orders.CountAsync() + 1; 
            //order.Status = Order.OrderStatus.OrderPlaced;
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
            existing.items = order.items;
            //existing.Subtotal = order.items.Sum(item => item.product.Price * item.Quantity);
            existing.DeliveryFee = order.DeliveryFee;
           // existing.TotalAmount = existing.Subtotal + existing.DeliveryFee; 
            existing.ShippingAddress = order.ShippingAddress;
            existing.CustomerId = order.CustomerId;
            existing.IsGuestOrder = order.IsGuestOrder;
            existing.PaymentMethod = order.PaymentMethod;
            existing.IsPaid = order.IsPaid;
            existing.Status = order.Status;
            dbContext.Orders.Update(existing);
            await dbContext.SaveChangesAsync();
            return existing;

        }
    }
}


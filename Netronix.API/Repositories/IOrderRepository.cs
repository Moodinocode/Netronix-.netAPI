using Netronix.API.Models.Domains;

namespace Netronix.API.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(Guid id);
        Task<Order> CreateAsync(Order order);
        Task<Order?> UpdateAsync(Guid Id,Order order);
        Task<Order?> DeleteAsync(Guid id);
        Task<List<Order>> GetOrdersByUserIdAsync(Guid userId);
    }
}

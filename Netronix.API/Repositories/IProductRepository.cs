using Netronix.API.Models.Domains;

namespace Netronix.API.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetBestSellersAsync();
        Task<Product?> GetByIdAsync(Guid id);
        Task<List<Product>> GetProductsByCategoryAsync(string category);

        Task<List<Tag>> GetTagsAsync();
        Task<Product> AddProductAsync(Product product);
        Task<Product?> UpdateProductAsync(Product product);
        Task<Product?> DeleteProductAsync(Guid id);

    }
}
